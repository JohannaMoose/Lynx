using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Lynx.Core;
using Lynx.Core.Conditions;
using Lynx.Core.Numbers;

namespace Lynx.Parsing.TextParsing.Conditions
{
    internal class LessThanTextParser
    {
        public static bool IsLessThan(string text)
        {
            return Regex.IsMatch(text, @".*<[^=].*");
        }

        public static bool IsLessOrEqual(string text)
        {
            return Regex.IsMatch(text, @".*<=.*");
        }

        public static LessThan ParseLessThan(string text, IReadOnlyDictionary<string, Variable> variables, Number value, string designation)
        {
            return null;
        }

        public static LessThan ParseLessOrEqual(string text, IReadOnlyDictionary<string, Variable> variables, Number value, string designation)
        {
            var parts = text.Split(new[] {"<="}, StringSplitOptions.RemoveEmptyEntries);
            Number left = null, right = null;
            foreach (var part in parts.Select(part => part.Trim()))
            {
                if (part == designation)
                {
                    if (left == null)
                        left = value;
                    else
                        right = value;
                }
                else if (variables.ContainsKey(part))
                {
                    var variable = variables.Single(x => x.Key == part).Value;
                    if (left == null)
                        left = variable;
                    else
                        right = variable;
                }
                else
                {
                    var nbr = new RealNumber(Convert.ToDouble(part));
                    if (left == null)
                        left = nbr;
                    else
                        right = nbr;
                }
            }

            return new LessThan(left, right, true);
        }
    }
}