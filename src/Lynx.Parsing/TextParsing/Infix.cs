using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lynx.Parsing.TextParsing
{
    internal class Infix
    {
        public static string ToPostfix(string str)
        {
            var stack = new Stack<string>();
            var output = new StringBuilder();
            var tree = str.ToCharArray().Select(s => s.ToString()).ToList();

            var inside = false;

            for (var i = 0; i < tree.Count(); i++)
            {
                var c = tree[i];
                if (!isOperator(c))
                    output.Append(c + " ");
                else if (c == ")")
                {
                    while (stack.Count > 0 && stack.Peek() != "(")
                    {
                        output.Append(stack.Pop() + " ");
                    }
                    stack.Pop();
                }
                else if (c == "|" && stack.Contains("|"))
                {
                    while (stack.Count > 0 && stack.Peek() != "|")
                    {
                        output.Append(stack.Pop() + " ");
                    }
                    output.Append(stack.Pop() + " ");
                }
                else if (stack.Count > 0 && !isLowerPrecedence(c, stack.Peek()))
                {
                    stack.Push(c);
                }
                else
                {
                    var processing = c;
                    while (stack.Count > 0 && isLowerPrecedence(c, stack.Peek()))
                    {
                        var s = stack.Pop();
                        if (c != "(")
                            output.Append(s + " ");
                        else
                            processing = s;
                    }
                    stack.Push(processing);
                }
            }

            while (stack.Count > 0)
            {
                output.Append(stack.Pop() + " ");
            }

            return output.ToString();
        }

        private static bool isOperator(string str)
        {
            return TextParser.Operators.ContainsKey(str) || str == "(";
        }

        private static bool isLowerPrecedence(string op1, string op2)
        {
            switch (op1)
            {
                case "+":
                case "-":
                    return !(op2 == "+" || op2 == "-" || op2 == "|");
                case "*":
                case "/":
                    return op2 == "^" || op2 == "(";
                case "^":
                    return op2 == "(";
                case "(":
                    return true;
                default:
                    return false;
            }
        }
    }
}