using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main()
        {
            int[] tokens = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = tokens[0];
            int s = tokens[1];
            int x = tokens[2];
            
            int[] numbersToAdd = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] actualNumsToAdd = numbersToAdd.Take(n).ToArray();

            Stack<int> numbers = new Stack<int>(actualNumsToAdd);

            for (int i = 0; i < s; i++)
            {
                if (numbers.Count == 0)
                {
                    break;
                }
                numbers.Pop();
            }

            int[] currentStack = numbers.ToArray();
            if (currentStack.Contains(x))
            {
                Console.WriteLine($"true");
                return;
            }

            Console.WriteLine(currentStack.OrderBy(e => e).FirstOrDefault());
        }
    }
}
