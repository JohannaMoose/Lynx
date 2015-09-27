namespace Lynx.Core
{
    /// <summary>
    /// Class representing a mathematical expression
    /// </summary>
    public class Expression
    {
        /// <summary>
        /// Get/Set the left side of the expression
        /// </summary>
        public Number LeftSide { get; set; }

        /// <summary>
        /// Get/Set the right side of the expression
        /// </summary>
        public Number RightSide { get; set; }
    }
}