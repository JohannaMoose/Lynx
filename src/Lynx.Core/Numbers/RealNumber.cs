using System;

namespace Lynx.Core.Numbers
{
    /// <summary>
    /// Class representing a real number
    /// </summary>
    public class RealNumber : Number
    {
        /// <summary>
        /// Creates a new instance of the RealNumber class
        /// </summary>
        protected RealNumber() { }

        /// <summary>
        /// Creates a new instance of the RealNumber class
        /// </summary>
        /// <param name="number">The number the class should represent</param>
        public RealNumber(double number)
        {
            Value = number;
        }

        /// <summary>
        /// Get the value the object represents
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Return this object
        /// </summary>
        /// <returns>
        /// The real number
        /// </returns>
        public RealNumber GetRealNumber()
        {
            return this;
        }

        /// <summary>
        /// Regenerates the number if it isn't fixed. 
        /// Does nothig for a real number
        /// </summary>
        public void Regenerate(){ }
    }
}