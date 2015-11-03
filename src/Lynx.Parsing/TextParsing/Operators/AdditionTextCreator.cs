using System;
using Lynx.Core;
using Lynx.Core.Operators;

namespace Lynx.Parsing.TextParsing.Operators
{
    internal class AdditionTextCreator : OperatorCreator
    {
        /// <summary>
        /// Get the number of numbers that is needed for creating a number with this parser
        /// </summary>
        public int NbrsForCreate => 2; 

        /// <summary>
        /// Create the number this parser handles with the numbers
        /// </summary>
        /// <param name="nbrs">The numbers this number will use to be created</param>
        /// <returns>The create number</returns>
        /// <exception cref="ArgumentException">Thrown if the numbers given as arguments aren't of the correct numbers</exception>
        /// <exception cref="NotSupportedException">Thrown if the parser doesn't support a create</exception>
        public Number CreateForNbrs(params Number[] nbrs)
        {
            if(nbrs.Length != 2)
                throw new ArgumentException("Addition needs exactly two numbers to add, more or less were provided");

            return new Addition(nbrs[1], nbrs[0]);
        }
    }
}