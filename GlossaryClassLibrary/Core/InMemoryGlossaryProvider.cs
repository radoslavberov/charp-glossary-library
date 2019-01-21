using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlossaryClassLibrary.Core
{
    public class InMemoryGlossaryProvider
    {
        private static InMemoryGlossary glossary;

        public static InMemoryGlossary Get()
        {
            if (glossary == null) glossary = new InMemoryGlossary();
            return glossary;
        }
    }
}
