using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOpeartions
{
    class Program
    {
        static void Main()
        {
            int[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int n = tokens[0];
            int s = tokens[1];
            int x = tokens[2];

            int[] numbersToAdd = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] actualNumsToAdd = numbersToAdd.Take(n).ToArray();

            Queue<int> queue = new Queue<int>(actualNumsToAdd);

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            int[] currentQueue = queue.ToArray();
            if (currentQueue.Contains(x))
            {
                Console.WriteLine($"true");
                return;
            }

            Console.WriteLine(currentQueue.OrderBy(e => e).FirstOrDefault());
        }
    }
}
