using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlossaryClassLibrary.Core
{
        public struct UpdateTermRequest
        {
            public UpdateTermRequest( string meaning)
            {
                Meaning = meaning;
            }
            public string Meaning { get; }

        }
}
