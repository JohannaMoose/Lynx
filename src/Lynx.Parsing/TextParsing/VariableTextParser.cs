using System;
using System.Text;
using System.Text.RegularExpressions;
using Lynx.Core;
using Lynx.Core.Numbers;

namespace Lynx.Parsing.TextParsing
{
    internal class VariableTextParser : Parser
    {
        /// <summary>
        /// Checks to see if the parser can parse the text from the start, not the entire text
        /// </summary>
        /// <param name="text">The text to check</param>
        /// <returns>
        /// True if the parser can parse the text, false otherwise
        /// </returns>
        public bool CanParse(string text)
        {
            return Regex.IsMatch(text, @"^[a-ö]+");
        }

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
        public Number Parse(StringBuilder text, Number leftNumber)
        {
            var currentText = text.ToString();
            if (!CanParse(currentText))
                throw new ArgumentException("VariableTextParser can not parse this text");

            var variableData = Regex.Match(currentText, @"^[a-ö]+\:.*");
            if (variableData.Success)
            {
                text.Remove(0, variableData.Value.Length);
                return createVariable(variableData.Value);
            }
            else
            {
                variableData = Regex.Match(currentText, @"^[a-ö]+");
                text.Remove(0, variableData.Value.Length);
                return new Variable(variableData.Value);
            }
        }

        private Variable createVariable(string text)
        {
            var designation = Regex.Match(text, "^[a-ö]+");
            var value = getValue(text);

            return new Variable(designation.Value, value);
        }

        private static RandomInteger getValue(string text)
        {
            var valueSpan = Regex.Match(text, @"\[([0-9]+),([0-9]+)\]?");
            var random = new RandomInteger(Convert.ToInt32(valueSpan.Groups[1].Value),
                Convert.ToInt32(valueSpan.Groups[2].Value));
            return random;
        }
    }
}