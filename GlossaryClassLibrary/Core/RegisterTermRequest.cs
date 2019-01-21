using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlossaryClassLibrary.Core
{
    public struct RegisterTermRequest
    {
        public RegisterTermRequest(string name, string meaning)
        {
            Name = name;
            Meaning = meaning;
        }
        public string Name { get; }
        public string Meaning { get; }

    }
}
