using System;

namespace Lynx.Core.Numbers
{
    /// <summary>
    /// Class representing a real number
    /// </summary>
    public class RealNumber : Number, IEquatable<double>, IEquatable<int>
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

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(double other)
        {
            return Value.Equals(other);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(int other)
        {
            return Value.Equals(other);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}