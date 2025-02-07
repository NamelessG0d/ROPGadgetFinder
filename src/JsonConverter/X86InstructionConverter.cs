using Gee.External.Capstone.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ROPGadgetFinder.JsonConverter
{
    public class X86InstructionConverter : JsonConverter<X86Instruction>
    {
        public override X86Instruction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException("Deserialization is not supported for X86Instruction.");
        }

        public override void Write(Utf8JsonWriter writer, X86Instruction value, JsonSerializerOptions options)
        {
            writer.WriteStringValue($"{value.Address.ToString("X8")} : {value.Mnemonic} {value.Operand}");
        }
    }
}
