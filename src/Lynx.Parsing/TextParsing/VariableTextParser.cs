using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Lynx.Core;
using Lynx.Core.Conditions;
using Lynx.Core.Numbers;
using Lynx.Parsing.TextParsing.Conditions;
using static System.String;

namespace Lynx.Parsing.TextParsing
{
    internal class VariableTextParser
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
            return Regex.IsMatch(text, @"^[a-ö]+\:.*");
        }

        /// <summary>
        /// Parses the text in a string builder for the part that the parser can interpret, 
        /// read from the front. 
        /// </summary>
        /// <param name="text">The text to parse.
        ///     The StringBuilder will be affected, the parsed text will remove the text that it parsed</param>
        /// <param name="variables">The variables that are active for the current parsing</param>
        /// <returns>
        /// The resulting number of the parse
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the text can't be parsed by the parser</exception>
        public Number Parse(StringBuilder text, Dictionary<string, Variable> variables)
        {
            var currentText = text.ToString();
            if (!CanParse(currentText))
                throw new ArgumentException("VariableTextParser can not parse this text");

            var variableData = Regex.Match(currentText, @"^[a-ö]+\:.*");
                text.Remove(0, variableData.Value.Length);
            return createVariable(variableData.Value, variables);
        }

        private static Variable createVariable(string text, Dictionary<string, Variable>variables)
        {
            var designation = Regex.Match(text, "^[a-ö]+").Value;
            var value = getValue(text, variables);
            var variable = new Variable(designation, value);

            variables.Add(designation, variable);

            var conditions = getConditions(text, variables, value, designation);
            variable.SetConditions(conditions.ToArray());

            return variable;
        }

        private static Number getValue(string text, IReadOnlyDictionary<string, Variable> variables)
        {
            var valueSpan = Regex.Match(text, @"\[([0-9]+),([0-9]+)\]?");

            if (valueSpan.Success)
            {
                var random = new RandomInteger(Convert.ToInt32(valueSpan.Groups[1].Value),
                Convert.ToInt32(valueSpan.Groups[2].Value));
                return random;
            }
            else
            {
                var valueText = Regex.Match(text, @"^[a-ö]+\:(.*)(&&)?");
                return TextParser.ParseText(valueText.Groups[1].Value.Trim(), variables);
            }
        }

        private static readonly Dictionary<Func<string, bool>, Func<string, IReadOnlyDictionary<string, Variable>, Condition>> ConditionFactory = 
            new Dictionary<Func<string, bool>, Func<string, IReadOnlyDictionary<string, Variable>, Condition>>
        {
                {LessThanTextParser.IsLessThan, LessThanTextParser.ParseLessThan},
                {LessThanTextParser.IsLessOrEqual, LessThanTextParser.ParseLessOrEqual},
                {EqualsTextParser.IsEqual, EqualsTextParser.ParseEquals },
                {NotEqualsTextParser.IsNotEqual, NotEqualsTextParser.ParseEquals }
        }; 

        private static IEnumerable<Condition> getConditions(string text, IReadOnlyDictionary<string, Variable> variables, Number value, string designation)
        {
            var conditions = Regex.Match(text, "&&(.*||)");
            if (!conditions.Success)
                return new List<Condition>();

            var singleConditions = conditions.Groups[1].Value.Split(new[] {"||", "(", ")"}, StringSplitOptions.RemoveEmptyEntries);

            return (from condition in singleConditions.Where(x => !IsNullOrWhiteSpace(x))
                    let parse = ConditionFactory.SingleOrDefault(x => x.Key(condition))
                    select parse.Value(condition, variables)
                    ).ToList(); 
        } 
    }
}