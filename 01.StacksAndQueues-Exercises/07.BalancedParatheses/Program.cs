using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.BalancedParatheses
{
    class Program
    {
        static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> queue = new Stack<char>();

            List<int> usedIndexes = new List<int>(input.Length);

            char[] openingBrackets = new char[] { '(', '{', '[' };
            char[] closingBrackets = new char[] { ')', '}', ']' };

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            for (int i = 0; i < input.Length; i++)
            {
                char currentElement = input[i];
                if (openingBrackets.Contains(currentElement))
                {
                    queue.Push(currentElement);
                }
                else if (closingBrackets.Contains(currentElement))
                {
                    char lastElement = queue.Pop();

                    int openIndex = Array.IndexOf(openingBrackets, lastElement);
                    int closeIndex = Array.IndexOf(closingBrackets, currentElement);

                    if (openIndex != closeIndex)
                    {
                        Console.WriteLine($"NO");
                        Environment.Exit(0);
                    }
                }
            }


            if (queue.Count > 0)
            {
                Console.WriteLine($"NO");
            }
            else
            {
                Console.WriteLine($"YES");
            }
        }
    }
}
