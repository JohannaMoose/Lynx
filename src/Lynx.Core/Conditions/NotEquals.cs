using System;

namespace Lynx.Core.Conditions
{
    /// <summary>
    /// Class representing an equals condition
    /// </summary>
    public class NotEquals : Condition
    {
        /// <summary>
        /// Creates a new instance of the Equals class
        /// </summary>
        /// <param name="left">The number to the left of the equals sign</param>
        /// <param name="right">The number to the right of the equals sign</param>
        /// <exception cref="ArgumentNullException">Thrown if either of the numbers are null</exception>
        public NotEquals(Number left, Number right)
        {
            if(left == null)
                throw new ArgumentNullException(nameof(left), "The left number can't be null");
            if(right == null)
                throw new ArgumentNullException(nameof(right), "The right number can't be null");

            Left = left;
            Right = right; 
        }

        /// <summary>
        /// Get the left number of the equals sign
        /// </summary>
        public Number Left { get; private set; }

        /// <summary>
        /// Get the right number of the equals sign
        /// </summary>
        public Number Right { get; private set; }

        /// <summary>
        /// Get flag to indicate if the condition the object represnt is fullfilled 
        /// </summary>
        public bool ConditionMeet => !Left.GetRealNumber().Value.Equals(Right.GetRealNumber().Value);
    }
}