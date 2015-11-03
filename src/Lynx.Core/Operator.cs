namespace Lynx.Core
{
    /// <summary>
    /// Class representing a mathematical number
    /// </summary>
    public interface Operator : Number
    {
        /// <summary>
        /// Get the left side of the operator
        /// </summary>
        Number LeftSide { get; }

        /// <summary>
        /// Get the right side of the operator
        /// </summary>
        Number RightSide { get; }

        /// <summary>
        /// Calculate the result of the operator and returns that value as an appropiate number
        /// </summary>
        /// <returns>
        /// The number that represent the calculation
        /// </returns>
        Number Calculate();
    }
}