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
        /// <param name="value">The value the variable should hold</param>
        /// <exception cref="ArgumentNullException">Thrown if the designation is null, empty or just whitespace</exception>
        public Variable(string designation, Number value = null)
        {
            if(string.IsNullOrWhiteSpace(designation))
                throw new ArgumentNullException(nameof(designation), "The designation was null, empty or just white space and that is not allowd");

            Designation = designation;
            Value = value; 
        }

        /// <summary>
        /// Get the designation of the variable 
        /// </summary>
        public string Designation { get; private set; }

        /// <summary>
        /// The value the variable represents
        /// </summary>
        public Number Value { get; private set; }

        /// <summary>
        /// Get/Set the value that the variable represents. 
        /// It won't update after the first value is set
        /// </summary>
        /// <param name="number">The value to assign to the variable</param>
        public void SetValue(Number number)
        {
            if(Value == null)
                Value = number; 
        }

        /// <summary>
        /// Get the number that is represented by the number 
        /// </summary>
        /// <returns>
        /// The real number
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the number can't be represented as a real number
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if the variable doesn't have a value set</exception>
        public RealNumber GetRealNumber()
        {
            return Value.GetRealNumber();
        }

        /// <summary>
        /// Regenerates the number if it isn't fixed
        /// </summary>
        public void Regenerate()
        {
            Value.Regenerate();
        }
    }
}