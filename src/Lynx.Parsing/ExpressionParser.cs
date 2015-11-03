using System;
using Lynx.Core;
using Lynx.Parsing.TextParsing;

namespace Lynx.Parsing
{
    /// <summary>
    /// Parser for expressions
    /// </summary>
    public static class ExpressionParser
    {
        /// <summary>
        /// Parses text into an expression that the text represents
        /// </summary>
        /// <param name="text">The text to parse</param>
        /// <returns>
        /// The resulting Expression
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the text contains anything that the parser can't handle</exception>
        public static Expression FromText(string text)
        {
            return new TextParser().ParseExpression(text);
        }
    }
}