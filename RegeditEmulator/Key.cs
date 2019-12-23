using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace RegeditEmulator
{

    public class Key
    {
        public string Name { get; set; }
        public RegistryValueKind Type { get; set; }
        public string Value { get; set; }

        public Key() {
            Name = "(Default)";
            Type = RegistryValueKind.None;
            Value = "(value not set)";
        }

        public Key(string name, RegistryValueKind type, string value) {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}
