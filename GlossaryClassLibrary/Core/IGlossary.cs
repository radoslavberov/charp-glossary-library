using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlossaryClassLibrary.Core
{
    /// <summary>
    /// Provides the methods to store, update and query terms.
    /// </summary>
    public interface IGlossary
    {
        /// <summary>
        /// Adds a term.
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="GlossaryClassLibrary.Core.Exeptions.TermAlreadyRegisteredException">
        /// Throws when the term that is being added already exists.</exception>
        /// <returns>The id of added term</returns>
        Term Register(RegisterTermRequest request);

        /// <summary>
        /// Updates a term.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="request"></param>
        /// <exception cref="GlossaryClassLibrary.Core.Exeptions.TermNotFoundException">Throws when a song by the passed name is not found
        /// </exception>
        /// <returns>The updated term</returns>
        Term Update(string name, UpdateTermRequest request);

        /// <summary>
        /// Finds a term by it`s name.
        /// <param name="name"></param>
        /// <exception cref="GlossaryClassLibrary.Core.Exeptions.TermNotFoundException">Throws when a term is not found.</exception>
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The found term</returns>
        Term? Find(string name);

        /// <summary>
        /// Returns all terms.
        /// </summary>
        /// <returns>A list of all stored terms</returns>
        List<Term> GetTerms();

        /// <summary>
        /// Returns terms count.
        /// </summary>
        /// <returns>All terms</returns>
        int GetCount();
    }  
}
