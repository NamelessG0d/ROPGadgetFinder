using Gee.External.Capstone.X86;
using Gee.External.Capstone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using static System.Collections.Specialized.BitVector32;
using CompilerTools.ROPGadgetFinder.Structs;
using System.Collections.Concurrent;

namespace CompilerTools.ROPGadgetFinder
{
    internal class Dissassembler : IDisposable
    {
        private bool disposed;

        public static List<Binary> executables { get; private set; } = new();
        public static Action<string>? logger { get; set; }

        private CapstoneX86Disassembler capstoneDisassembler { get; set; }
        private Binary executable { get; set; }

        private Dissassembler(Binary binary) 
        {
            const X86DisassembleMode disassembleMode = X86DisassembleMode.Bit64;
            capstoneDisassembler = CapstoneDisassembler.CreateX86Disassembler(disassembleMode);
            capstoneDisassembler.EnableInstructionDetails = true;
            capstoneDisassembler.DisassembleSyntax = DisassembleSyntax.Intel;

            executable = binary;
        }

        ~Dissassembler()
        {
            Dispose(disposing: false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                capstoneDisassembler.Dispose();
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        internal List<Gadget> SearchGadgets(List<InstructionPattern> pattern)
        {
            List<Gadget> result = new();

            foreach (var section in executable.ExecutableSections)
            {
                var instructions = capstoneDisassembler.Disassemble(section.Value, section.Key).ToList();

                for (int i = 0; i <= instructions.Count - pattern.Count; i++)
                {
                    bool isMatch = true;
                    for (int j = 0; j < pattern.Count; j++)
                    {
                        if (instructions[i + j].Id != pattern[j].id || !instructions[i + j].HasDetails)
                        {
                            isMatch = false;
                            break;
                        }

                        if (pattern[j].ExplicitlyReadRegisters != null &&
                            !pattern[j].ExplicitlyReadRegisters!.All(r => instructions[i + j].Details.ExplicitlyReadRegisters.Select(r => r.Id).Contains(r)))
                        {
                            isMatch = false;
                            break;
                        }

                        if (pattern[j].ExplicitlyReadRegistersCount != null &&
                            instructions[i + j].Details.ExplicitlyReadRegisters.Length != pattern[j].ExplicitlyReadRegistersCount)
                        {
                            isMatch = false;
                            break;
                        }

                        if (pattern[j].ExplicitlyWrittenRegisters != null &&
                            !pattern[j].ExplicitlyWrittenRegisters!.All(r => instructions[i + j].Details.ExplicitlyWrittenRegisters.Select(r => r.Id).Contains(r)))
                        {
                            isMatch = false;
                            break;
                        }

                        if (pattern[j].ExplicitlyWrittenRegistersCount != null &&
                            instructions[i + j].Details.ExplicitlyWrittenRegisters.Length != pattern[j].ExplicitlyWrittenRegistersCount)
                        {
                            isMatch = false;
                            break;
                        }
                    }
                    if (isMatch)
                    {
                        var gadget = instructions.Skip(i).Take(pattern.Count).ToList();
                        result.Add(new Gadget() { Binary = executable, Instructions = gadget, VirtualAddress = gadget[0].Address });
                    }
                }
            }
            return result;
        }

        internal static bool LoadBinaries(string path)
        {
            try
            {
                var files = FilePathResolver.GetMatchingFiles(path);

                ConcurrentBag<Binary> results = new ConcurrentBag<Binary>();
                int total = files.Count();
                int processedCount = 0;

                Parallel.ForEach(files, file =>
                {
                    results.Add(new Binary(file));

                    int count = Interlocked.Increment(ref processedCount);
                    logger?.Invoke($"Processed {count} out of {total} binaries.");
                });

                executables = results.ToList();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        internal static List<Gadget> ScanExecutables(List<InstructionPattern> pattern)
        {
            ConcurrentBag<Gadget> results = new ConcurrentBag<Gadget>();
            int total = executables.Count;
            int processedCount = 0;

            Parallel.ForEach(executables, executable =>
            {
                using (Dissassembler dissassembler = new Dissassembler(executable))
                {
                    var gadgets = dissassembler.SearchGadgets(pattern);
                    foreach (var gadget in gadgets)
                    {
                        results.Add(gadget);
                    }
                }

                int count = Interlocked.Increment(ref processedCount);
                logger?.Invoke($"Processed {count} out of {total} binaries.");
            });

            return results.ToList();
        }
    }
}
