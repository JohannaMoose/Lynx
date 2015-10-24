using System;
using Lynx.Core.Numbers;

namespace Lynx.Core.Operators
{
    /// <summary>
    /// Addition operator for two numbers
    /// </summary>
    public class Multiplication : BaseOperator
    {
        /// <summary>
        /// Creates a new instance of the Addition class with the two numbers to add
        /// </summary>
        protected Multiplication() { }

        /// <summary>
        /// Creates a new instance of the Addition class with the two numbers to add
        /// </summary>
        /// <param name="left">The left number to add</param>
        /// <param name="right">The rigth number to add</param>
        /// <exception cref="ArgumentNullException">Thrown if either of the numbers are null</exception>
        public Multiplication(Number left, Number right)
            :base(left, right)
        { }

        /// <summary>
        /// Do the operation the class is handling
        /// </summary>
        /// <param name="left">The left number value</param>
        /// <param name="right">The right number value</param>
        /// <returns>
        /// The result of the operation
        /// </returns>
        protected override RealNumber calculate(double left, double right)
        {
            return new RealNumber(left * right);
        }
    }
}