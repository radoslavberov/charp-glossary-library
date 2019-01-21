# charp-glossary-library
Develop a glossary library

Basic requerements Maintain a collection of terms. For each term - its name and meaning.

Should be able to:
i. Add a term and its meaning.
ii. If a term is already known, indicate error.
iii. Return the meaning of a term.
iv. Update the meaning of a term.
v. Return a list of all terms.
vi. Return the number of terms.

Detailed Requerements

i. Adding terms. 1.1 Should happen with a request object, separate from the term's domain. 1.1.1 
Should contain information information about the term's name and meaning. 1.2 Adding a term creates
a new Term object. 1.2.1 Adding a term that matches the exact term and meaning of another term throws
TermAlreadyExistsException.

ii. Retrieving terms. 2.1 Terms can be retrieved by their unique name. 2.1.1 Retrieveing a term that 
exists returns the nullable Term object. If a Term is not found a null is returned.

iii.Updating terms. 3.1 Terms can be updated by passing a Term object as an argument. 3.1.1 Updating
a Term replaces it in memory. 3.1.2 If an update request contains a Term object that does not match 
any other in memory then the term is inserted instead.

iv. Adding new Terms stores them into list. 4.1 Adding a Term and its Meaning not in the list should add them
into list. 4.2 Updating a Term should store them into list