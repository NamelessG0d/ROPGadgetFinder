using CompilerTools.ROPGadgetFinder.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ROPGadgetFinder.Structs
{
    public struct SerializableGadgetGroup
    {
        [JsonInclude]
        public string Binary { get; set; } = "";
        [JsonInclude]
        public List<Gadget> Gadgets { get; set; } = new List<Gadget>();

        // Constructor for easier conversion
        public SerializableGadgetGroup(IGrouping<string, Gadget> group)
        {
            Binary = group.Key;
            Gadgets = group.ToList();
        }
    }
}
