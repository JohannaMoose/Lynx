using System;
using Lynx.Core.Numbers;

namespace Lynx.Core.Operators
{
    /// <summary>
    /// Base operator class
    /// </summary>
    public abstract class BaseOperator : Operator
    {
        /// <summary>
        /// Creates a new instance of the BaseOperator class with the two numbers to handle
        /// </summary>
        protected BaseOperator() { }

        /// <summary>
        /// Creates a new instance of the BaseOperator class with the two numbers to handle
        /// </summary>
        /// <param name="left">The left number to add</param>
        /// <param name="right">The rigth number to add</param>
        /// <exception cref="ArgumentNullException">Thrown if either of the numbers are null</exception>
        protected BaseOperator(Number left, Number right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left), "The left number can't be null");
            if (right == null)
                throw new ArgumentNullException(nameof(right), "The right number can't be null");

            LeftSide = left;
            RightSide = right;
        }

        /// <summary>
        /// Get the left side of the operator
        /// </summary>
        public Number LeftSide { get; private set; }

        /// <summary>
        /// Get the right side of the operator
        /// </summary>
        public Number RightSide { get; private set; }

        /// <summary>
        /// Calculate the result of the operator and returns that value as an appropiate number
        /// </summary>
        /// <returns>
        /// The number that represent the calculation
        /// </returns>
        public Number Calculate()
        {
            return GetRealNumber();
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
        public RealNumber GetRealNumber()
        {
            return calculate(LeftSide.GetRealNumber().Value, RightSide.GetRealNumber().Value);
        }

        /// <summary>
        /// Do the operation the class is handling
        /// </summary>
        /// <param name="left">The left number value</param>
        /// <param name="right">The right number value</param>
        /// <returns>
        /// The result of the operation
        /// </returns>
        protected abstract RealNumber calculate(double left, double right);

        /// <summary>
        /// Regenerates the number if it isn't fixed
        /// </summary>
        public void Regenerate()
        {
            LeftSide.Regenerate();
            RightSide.Regenerate();
        }
    }
}