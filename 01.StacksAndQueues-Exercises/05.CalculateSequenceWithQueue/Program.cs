using System;
using System.Collections.Generic;

namespace _05.CalculateSequenceWithQueue
{
    class Program
    {
        static void Main()
        {
            Queue<long> helpQueue = new Queue<long>();
            Queue<long> mainQueue = new Queue<long>();

            long n = long.Parse(Console.ReadLine());
            
            helpQueue.Enqueue(n);
            mainQueue.Enqueue(n);

            while (mainQueue.Count < 50)
            {
                long s1 = helpQueue.Dequeue();
                long firstItem = s1 + 1;
                long secondItem = s1 * 2 + 1;
                long thirdItem = s1 + 2;

                helpQueue.Enqueue(firstItem);
                helpQueue.Enqueue(secondItem);
                helpQueue.Enqueue(thirdItem);

                mainQueue.Enqueue(firstItem);
                if (mainQueue.Count == 50)
                {
                    break;
                }
                mainQueue.Enqueue(secondItem);
                mainQueue.Enqueue(thirdItem);
            }

            Console.WriteLine(string.Join(" ", mainQueue));
        }
    }
}
