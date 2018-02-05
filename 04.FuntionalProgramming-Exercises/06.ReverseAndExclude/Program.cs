using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            numbers.Reverse();
            numbers.RemoveAll(num => num % n == 0);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
