using System;

namespace Lynx.Core.Numbers
{
    /// <summary>
    /// Number representing absolute numbers
    /// </summary>
    public class AbsoluteNumber : Number
    {
        /// <summary>
        /// Creates a new instance of the AbsoluteNumber class
        /// </summary>
        protected AbsoluteNumber() { }

        /// <summary>
        /// Creates a new instance of the AbsoluteNumber class
        /// </summary>
        /// <param name="nbr">The number that should be inside the absolute number</param>
        /// <exception cref="ArgumentNullException">Thrown if the number is null</exception>
        public AbsoluteNumber(Number nbr)
        {
            if(nbr == null)
                throw new ArgumentNullException(nameof(nbr),"The number can't be null");

            InnerValue = nbr;
        }

        /// <summary>
        /// Get the value that is inside the absolut signs
        /// </summary>
        public Number InnerValue { get; private set; }

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
            var raw = InnerValue.GetRealNumber().Value; 
            return new RealNumber(Math.Abs(raw));
        }

        /// <summary>
        /// Regenerates the number if it isn't fixed
        /// </summary>
        public void Regenerate()
        {
            InnerValue.Regenerate();
        }
    }
}