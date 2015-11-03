using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lynx.Core;
using Lynx.Core.Conditions;

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

        public static LessThan ParseLessThan(string text, IReadOnlyDictionary<string, Variable> variables)
        {
            var parts = text.Split(new[] { "<" }, StringSplitOptions.RemoveEmptyEntries);
            var left = TextParser.ParseText(parts[0].Trim(), variables);
            var right = TextParser.ParseText(parts[1].Trim(), variables);

            return new LessThan(left, right);
        }

        public static LessThan ParseLessOrEqual(string text, IReadOnlyDictionary<string, Variable> variables)
        {
            var parts = text.Split(new[] {"<="}, StringSplitOptions.RemoveEmptyEntries);
            var left = TextParser.ParseText(parts[0].Trim(), variables);
            var right = TextParser.ParseText(parts[1].Trim(), variables);
          
            return new LessThan(left, right, true);
        }
    }
}