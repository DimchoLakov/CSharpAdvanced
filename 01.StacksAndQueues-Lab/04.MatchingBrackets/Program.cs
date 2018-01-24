using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main()
        {
            string expression = Console.ReadLine();

            Stack<int> indexesStack = new Stack<int>();
            Stack<string> exprStack = new Stack<string>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indexesStack.Push(i);
                }
                if (expression[i] == ')')
                {
                    int openBracketIndex = indexesStack.Peek();
                    string miniExpr = expression.Substring(indexesStack.Pop(), i - openBracketIndex + 1);
                    exprStack.Push(miniExpr);
                }
            }
            string[] exprArray = exprStack.ToArray();
            exprStack.Clear();
            foreach (string str in exprArray)
            {
                exprStack.Push(str);
            }

            while (exprStack.Count != 0)
            {
                Console.WriteLine(exprStack.Pop());
            }
        }
    }
}
