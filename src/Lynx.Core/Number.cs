using System;
using Lynx.Core.Numbers;

namespace Lynx.Core
{
    /// <summary>
    /// Contract for all numbers in the system
    /// </summary>
    public interface Number
    {
        /// <summary>
        /// Get the number that is represented by the number 
        /// </summary>
        /// <returns>
        /// The real number
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the number can't be represented as a real number
        /// </exception>
        RealNumber GetRealNumber();

        /// <summary>
        /// Regenerates the number if it isn't fixed
        /// </summary>
        void Regenerate();
    }
}