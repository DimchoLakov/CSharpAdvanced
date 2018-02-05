using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> getMinNumber = x =>
            {
                int minNumber = int.MaxValue;
                for (int i = 0; i < x.Length; i++)
                {
                    if (minNumber > x[i])
                    {
                        minNumber = x[i];
                    }
                }
                return minNumber;
            };

            Console.WriteLine(getMinNumber(numbers));
        }
    }
}
