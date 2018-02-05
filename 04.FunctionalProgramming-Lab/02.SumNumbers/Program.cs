using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main()
        {
            Func<string, int> intParser = ParseInt;
            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseInt).ToArray();

            int numbersCount = numbers.Length;
            int sum = numbers.Sum();

            Console.WriteLine(numbersCount);
            Console.WriteLine(sum);
        }

        static int ParseInt(string numberAsString)
        {
            return int.Parse(numberAsString);
        }
    }
}
