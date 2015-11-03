using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Lynx.Core;
using Lynx.Core.Conditions;

namespace Lynx.Parsing.TextParsing.Conditions
{
    internal static class NotEqualsTextParser
    {
        public static bool IsNotEqual(string str)
        {
            return Regex.IsMatch(str, @".*!=.*");
        }

        public static NotEquals ParseEquals(string text, IReadOnlyDictionary<string, Variable> variables)
        {
            var parts = text.Split(new[] { "!=" }, StringSplitOptions.RemoveEmptyEntries);
            var left = TextParser.ParseText(parts[0].Trim(), variables);
            var right = TextParser.ParseText(parts[1].Trim(), variables);

            return new NotEquals(left, right);
        }
    }
}