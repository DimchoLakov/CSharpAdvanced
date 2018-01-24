using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReveseNumbersWithStack
{
    class Program
    {
        static void Main()
        {
            Stack<int> numbersStack = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (numbersStack.Count != 0)
            {
                Console.Write($"{numbersStack.Pop()} ");
            }
        }
    }
}
