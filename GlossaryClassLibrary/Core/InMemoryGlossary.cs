using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlossaryClassLibrary.Core.Exeptions;

namespace GlossaryClassLibrary.Core
{
    public class InMemoryGlossary : IGlossary
    {
        private List<Term> terms;

        public InMemoryGlossary()
        {
            terms = new List<Term>();
        }

        public Term? Find(string name)
        {
            var possibleTerm = terms.Where(term => term.Name == name).ToList();

            if (possibleTerm.Count == 0) return null;
            else return possibleTerm.First();
        }

        public int GetCount()
        {
            return terms.Count();
        }

        public List<Term> GetTerms()
        {
            return terms;
        }

        public Term Register(RegisterTermRequest request)
        {
            if (request.Name == null || request.Name.Trim() == "") throw new ArgumentNullException();
            if (request.Meaning == null || request.Meaning.Trim() == "") throw new ArgumentNullException();

            if (terms.Select(term => term.Name == request.Name).Count() != 0) throw new TermAlreadyRegisteredException();

            var registeredTerm = new Term(request.Name, request.Meaning);
            terms.Add(registeredTerm);

            return registeredTerm;
        }

        public Term Update(string name, UpdateTermRequest request)
        {
            if (request.Meaning == null || request.Meaning.Trim() == "") throw new ArgumentNullException();

            Term updatedTerm = new Term(name, request.Meaning);
            List<Term> foundTerm = terms.Where(term => term.Name == name).ToList();

            if (foundTerm.Count() == 0) terms.Add(updatedTerm);
            else
            {
                terms.Remove(foundTerm.First());
                terms.Add(updatedTerm);
            }

            return updatedTerm;
        }
    }
}
