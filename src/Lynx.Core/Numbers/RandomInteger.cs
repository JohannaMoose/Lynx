using System;

namespace Lynx.Core.Numbers
{
    /// <summary>
    /// Class representing a random integer
    /// </summary>
    public class RandomInteger : Number
    {
        private readonly int _lowerBoundery;
        private readonly int _upperBoundery;
        private int _value;
        private static Random _valueGenerator;

        /// <summary>
        /// Creates a new instance of the RandomInteger class
        /// </summary>
        protected RandomInteger() { }

        /// <summary>
        /// Creates a new instance of the RandomInteger class
        /// </summary>
        /// <param name="lowerBoundery">The lower, inclusive bound</param>
        /// <param name="upperBoundery">The upper, none incusive bound</param>
        public RandomInteger(int lowerBoundery, int upperBoundery)
        {
            _lowerBoundery = lowerBoundery;
            _upperBoundery = upperBoundery;
            Regenerate();
        }

        private static Random valueGenerator => _valueGenerator ?? (_valueGenerator = new Random());

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
            return new RealNumber(_value);
        }

        /// <summary>
        /// Regenerates the number this number represents
        /// </summary>
        public void Regenerate()
        {
            _value = valueGenerator.Next(_lowerBoundery, _upperBoundery);
        }
    }
}