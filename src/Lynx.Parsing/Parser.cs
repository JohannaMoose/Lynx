using System;
using System.Text;
using Lynx.Core;

namespace Lynx.Parsing
{
    /// <summary>
    /// Contract for Parsers
    /// </summary>
    public interface Parser
    {
        /// <summary>
        /// Checks to see if the parser can parse the text from the start, not the entire text
        /// </summary>
        /// <param name="text">The text to check</param>
        /// <returns>
        /// True if the parser can parse the text, false otherwise
        /// </returns>
        bool CanParse(string text);

        /// <summary>
        /// Parses the text in a string builder for the part that the parser can interpret, 
        /// read from the front. 
        /// </summary>
        /// <param name="text">The text to parse.
        ///  The StringBuilder will be affected, the parsed text will remove the text that it parsed</param>
        /// <param name="leftNumber">The number that is to the left of the text currently parsing</param>
        /// <returns>
        /// The resulting number of the parse
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the text can't be parsed by the parser</exception>
        Number Parse(StringBuilder text, Number leftNumber);
    }
}