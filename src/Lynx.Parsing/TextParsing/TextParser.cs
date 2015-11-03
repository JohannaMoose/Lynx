using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lynx.Core;
using Lynx.Core.Numbers;
using Lynx.Parsing.TextParsing.Operators;

namespace Lynx.Parsing.TextParsing
{
    internal class TextParser
    {
        public static readonly Dictionary<string, OperatorCreator> Operators = new Dictionary<string, OperatorCreator>
        {
            {"+", new AdditionTextCreator()},
            {"-", new SubtractionTextCreator() },
            { "|", new AbsolutTextCreator() },
            {"*", new MultiplicationTextCreator() },
            {"/", new DivisionTextCreator() }
        };

        public Expression ParseExpression(string text)
        {
            var sb = new StringBuilder(text);

            var variables = getVariables(sb);

            var equalIndex = sb.ToString().IndexOf("=", StringComparison.Ordinal);
            return new Expression
            {
                LeftSide = ParseText(sb.ToString(0, equalIndex), variables),
                RightSide = ParseText(sb.ToString(equalIndex + 1, sb.Length - equalIndex-1), variables)
            };
        }

        private static Dictionary<string, Variable> getVariables(StringBuilder sb)
        {
            var varParser = new VariableTextParser();
            var variables = new Dictionary<string, Variable>();
            while (varParser.CanParse(sb.ToString()))
            {
                varParser.Parse(sb, variables);
                removePadding(sb);
            }

            return variables; 
        }

        private static void removePadding(StringBuilder sb)
        {
            var current = sb.ToString().Trim();
            sb.Clear();
            sb.Append(current);
        }

        public static Number ParseText(string text, IReadOnlyDictionary<string, Variable> variables)
        {
            var postFix = Infix.ToPostfix(text);
            var stack = new Stack<Number>();
            foreach (var val in individualElements(postFix))
            {
                if (Operators.ContainsKey(val))
                {
                    var op = createOperator(val, stack);
                    stack.Push(op);
                }
                else if (variables.ContainsKey(val))
                {
                    var variable = getVariable(variables, val);
                    stack.Push(variable);
                }
                else
                {
                    var nbr = createNbr(val);
                    if(nbr != null)
                        stack.Push(nbr);
                    else 
                        throw new NotSupportedException("The string is not recogniezed as a value");
                }
            }
            return stack.Pop();
        }

        private static IEnumerable<string> individualElements(string postFix)
        {
            return postFix.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim());
        }

        private static Number createOperator(string val, Stack<Number> stack)
        {
            var creator = Operators.Single(x => x.Key == val).Value;
            var nbrs = new List<Number>();
            for (var i = 0; i < creator.NbrsForCreate; i++)
            {
                nbrs.Add(stack.Pop());
            }
            var op = creator.CreateForNbrs(nbrs.ToArray());
            return op;
        }

        private static Variable getVariable(IReadOnlyDictionary<string, Variable> variables, string val)
        {
            var variable = variables.Single(x => x.Key == val).Value;
            return variable;
        }

        private static RealNumber createNbr(string val)
        {
            double nbr;
            var isNbr = double.TryParse(val, out nbr);
            var realNbr = new RealNumber(nbr);
            return isNbr ? realNbr : null; 
        }
    }
}