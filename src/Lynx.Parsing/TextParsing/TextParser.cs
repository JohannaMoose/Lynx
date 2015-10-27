using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lynx.Core;

namespace Lynx.Parsing.TextParsing
{
    internal class TextParser
    {
        private static readonly List<Parser> Parsers = new List<Parser>
        {
            new AdditionTextParser(),
            new VariableTextParser()
        };

        StringBuilder _text;

        readonly List<Variable> _variables = new List<Variable>(); 

        public Expression ParseExpression(string text)
        {
            var expression = new Expression();
            _text = new StringBuilder(text);
            Number left = null;

            while (_text.Length > 0)
            {
                var nextPart = ParseNextValue(left, _text);
                left = nextPart;

                var part = nextPart as Variable;
                if (part?.Value != null)
                {
                    _variables.Add(part);
                }else if (part != null)
                {
                    var variable = _variables.SingleOrDefault(x => x.Designation == part.Designation);
                    left = variable; 
                }

                if (_text.Length > 0 && _text.ToString(0, 1) == "=")
                {
                    expression.LeftSide = left;
                    _text.Remove(0, 1);
                }

                removePadding();
            }

            expression.RightSide = left; 

            return expression;
        }

        private void removePadding()
        {
            var current = _text.ToString().Trim();
            _text.Clear();
            _text.Append(current);
        }

        public static Number ParseNextValue(Number leftNumber, StringBuilder text)
        {
            var currentText = text.ToString();
            return (
                from parser in Parsers
                where parser.CanParse(currentText)
                select parser.Parse(text, leftNumber, null)
                ).FirstOrDefault();
        }
    }
}