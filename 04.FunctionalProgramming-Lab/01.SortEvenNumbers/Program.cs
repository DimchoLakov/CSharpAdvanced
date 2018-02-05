using System;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .Where(x => x % 2 == 0).ToList()));
        }
    }
}
