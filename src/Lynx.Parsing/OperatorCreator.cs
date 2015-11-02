using System;
using Lynx.Core;

namespace Lynx.Parsing
{
    /// <summary>
    /// Contract for Parsers
    /// </summary>
    public interface OperatorCreator
    {
        /// <summary>
        /// Get the number of numbers that is needed for creating a number with this parser
        /// </summary>
        int NbrsForCreate { get; }

        /// <summary>
        /// Create the number this parser handles with the numbers
        /// </summary>
        /// <param name="nbrs">The numbers this number will use to be created</param>
        /// <returns>The create number</returns>
        /// <exception cref="ArgumentException">Thrown if the numbers given as arguments aren't of the correct numbers</exception>
        /// <exception cref="NotSupportedException">Thrown if the parser doesn't support a create</exception>
        Number CreateForNbrs(params Number[] nbrs);
    }
}