using System;
using System.Collections.Generic;

namespace _05.HotPotato
{
    class Program
    {
        static void Main()
        {
            Queue<string> children = new Queue<string>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            int tossTimes = int.Parse(Console.ReadLine());

            while (children.Count > 1)
            {
                for (int i = 0; i < tossTimes - 1; i++)
                {
                    children.Enqueue(children.Dequeue());
                }
                Console.WriteLine($"Removed {children.Dequeue()}");
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
