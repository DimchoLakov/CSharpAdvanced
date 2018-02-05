using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main()
        {
            int[] boundaries = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerBound = boundaries[0];
            int upperBound = boundaries[1];
            List<int> numbers = new List<int>(upperBound - lowerBound + 1);
            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }
            string oddOrEven = Console.ReadLine();

            Func<int, bool> isEven = x => x % 2 == 0;
            Func<int, bool> isOdd = x => x % 2 != 0;

            if (oddOrEven == "even")
            {
                numbers = numbers.Where(isEven).ToList();
                Console.WriteLine(string.Join(" ", numbers));
            }
            else if (oddOrEven == "odd")
            {
                numbers = numbers.Where(isOdd).ToList();
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
