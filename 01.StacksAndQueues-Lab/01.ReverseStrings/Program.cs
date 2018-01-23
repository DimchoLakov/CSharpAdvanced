using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> charStack = new Stack<char>();

            foreach (char c in input)
            {
                charStack.Push(c);
            }

            while (charStack.Count != 0)
            {
                Console.Write(charStack.Pop());
            }
        }
    }
}
