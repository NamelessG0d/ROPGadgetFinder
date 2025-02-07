using Gee.External.Capstone.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompilerTools.ROPGadgetFinder.Structs
{
    public struct Gadget
    {
        [JsonInclude]
        public long VirtualAddress { get; set; }
        [JsonInclude]
        public List<X86Instruction> Instructions { get; set; }
        [JsonIgnore]
        public Binary Binary { get; set; }
    }
}
