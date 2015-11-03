using System;
using Lynx.Core;
using Lynx.Core.Numbers;

namespace Lynx.Parsing.TextParsing.Operators
{
    /// <summary>
    /// Creates absolut numbers from text
    /// </summary>
    internal class AbsolutTextCreator : OperatorCreator
    {
        /// <summary>
        /// Get the number of numbers that is needed for creating a number with this parser
        /// </summary>
        public int NbrsForCreate => 1;

        /// <summary>
        /// Create the number this parser handles with the numbers
        /// </summary>
        /// <param name="nbrs">The numbers this number will use to be created</param>
        /// <returns>The create number</returns>
        /// <exception cref="ArgumentException">Thrown if the numbers given as arguments aren't of the correct numbers</exception>
        /// <exception cref="NotSupportedException">Thrown if the parser doesn't support a create</exception>
        public Number CreateForNbrs(params Number[] nbrs)
        {
            if(nbrs.Length != 1)
                throw  new ArgumentException("Absolut number can only have one number, more or less was provided");

            return new AbsoluteNumber(nbrs[0]);
        }
    }
}