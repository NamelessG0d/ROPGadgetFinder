using Gee.External.Capstone.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerTools.ROPGadgetFinder.Structs
{
    public struct InstructionPattern
    {
        public X86InstructionId id { get; set; }
        public List<X86RegisterId>? ExplicitlyReadRegisters { get; set; }
        public int? ExplicitlyReadRegistersCount { get; set; }

        public List<X86RegisterId>? ExplicitlyWrittenRegisters { get; set; }
        public int? ExplicitlyWrittenRegistersCount { get; set; }

        public override string ToString()
        {
            string str = id.ToString();

            if (ExplicitlyReadRegisters != null && ExplicitlyReadRegisters.Any())
            {
                str += $" | Read: {string.Join(", ", ExplicitlyReadRegisters)}";
            }

            if (ExplicitlyReadRegistersCount.HasValue)
            {
                str += $" | ReadLen: {ExplicitlyReadRegistersCount.Value}";
            }

            if (ExplicitlyWrittenRegisters != null && ExplicitlyWrittenRegisters.Any())
            {
                str += $" | Written: {string.Join(", ", ExplicitlyWrittenRegisters)}";
            }

            if (ExplicitlyWrittenRegistersCount.HasValue)
            {
                str += $" | WrittenLen: {ExplicitlyWrittenRegistersCount.Value}";
            }

            return str;
        }
    }
}
