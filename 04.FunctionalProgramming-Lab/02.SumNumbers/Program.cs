using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int numbersCount = numbers.Length;
            int sum = numbers.Sum();

            Console.WriteLine(numbersCount);
            Console.WriteLine(sum);
        }
    }
}
