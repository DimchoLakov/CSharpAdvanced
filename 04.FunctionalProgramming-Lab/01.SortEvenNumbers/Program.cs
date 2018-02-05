using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine(string.Join(", ", Console.ReadLine()
            //    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .OrderBy(x => x)
            //    .Where(x => x % 2 == 0).ToList()));

            Func<string, int> intParser = int.Parse;
            Func<int, bool> isNumberEven = n => n % 2 == 0;

            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(intParser)
                .Where(isNumberEven)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
