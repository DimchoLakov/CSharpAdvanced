using System;
using System.Collections.Generic;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Stack<long> fibStack = new Stack<long>();

            fibStack.Push(1);
            fibStack.Push(1);

            int a = 0;
            int b = 0;

            for (int i = 2; i < n; i++)
            {
                long old = fibStack.Pop();
                long next = fibStack.Peek() + old;
                
                fibStack.Push(old);
                fibStack.Push(next);
            }
            Console.WriteLine(fibStack.Pop());
        }
    }
}
