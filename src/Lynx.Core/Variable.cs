using System;
using Lynx.Core.Numbers;

namespace Lynx.Core
{
    /// <summary>
    /// Class representing a mathematical variable
    /// </summary>
    public class Variable : Number
    {
        /// <summary>
        /// Creates a new instance of the Variable class
        /// </summary>
        protected Variable() { }

        /// <summary>
        /// Creates a new instance of the Variable class
        /// </summary>
        /// <param name="designation">The designation of the variable</param>
        /// <exception cref="ArgumentNullException">Thrown if the designation is null, empty or just whitespace</exception>
        public Variable(string designation)
        {
            if(string.IsNullOrWhiteSpace(designation))
                throw new ArgumentNullException(nameof(designation), "The designation was null, empty or just white space and that is not allowd");

            Designation = designation;
        }

        /// <summary>
        /// Get the designation of the variable 
        /// </summary>
        public string Designation { get; private set; }

        /// <summary>
        /// Get the number that is represented by the number 
        /// </summary>
        /// <returns>
        /// The real number
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the number can't be represented as a real number
        /// </exception>
        public RealNumber GetRealNumber()
        {
            throw new NotImplementedException();
        }

        public void Regenerate()
        {
            throw new NotImplementedException();
        }
    }
}