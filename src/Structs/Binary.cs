using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CompilerTools.ROPGadgetFinder.Structs
{
    public class Binary
    {
        /// <summary>
        /// Initalize a windows binary
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <exception cref="Exception"></exception>
        internal Binary(string path)
        {
            if (!System.IO.Path.Exists(path))
                return;

            Path = path;
            try
            {
                using (MemoryStream ms = new MemoryStream(Data))
                {
                    using (var peReader = new PEReader(ms))
                    {
                        var headers = peReader.PEHeaders;

                        if (headers.PEHeader == null)
                            throw new Exception("Invalid PE header");

                        ImageBase = (long)headers.PEHeader.ImageBase;

                        foreach (var section in headers.SectionHeaders)
                        {
                            if ((section.SectionCharacteristics & SectionCharacteristics.MemExecute) != 0)
                            {
#if DEBUG
                                Console.WriteLine($"[{System.IO.Path.GetFileName(Path)}] Found executable section: {section.Name}");
#endif
                                byte[] sectionBytes = new byte[section.SizeOfRawData];

                                ms.Seek(section.PointerToRawData, SeekOrigin.Begin);
                                ms.Read(sectionBytes, 0, sectionBytes.Length);

                                ExecutableSections.Add(ImageBase + section.VirtualAddress, sectionBytes);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine($"[{System.IO.Path.GetFileName(Path)}] Error: {ex.Message}");
#endif
                throw;
            }
        }

        public string Path { get; private set; }
        public byte[] Data
        {
            get
            {
                return File.ReadAllBytes(Path);
            }
        }

        public long ImageBase { get; private set; }

        /// <summary>
        /// Contains the Virtual Address and the data of all the executable sections of the binary
        /// </summary>
        public Dictionary<long, byte[]> ExecutableSections { get; private set; } = new();

        public override bool Equals(object? obj)
        {
            if (obj is Binary other)
            {
                return string.Equals(Path, other.Path, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Path != null ? StringComparer.OrdinalIgnoreCase.GetHashCode(Path) : 0;
        }
    }
}
