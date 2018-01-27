using System;
using System.Linq;

namespace _03.GroupNumbers
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                            .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse).ToArray();

            int[][] jaggedArray = new int[3][];

            int[] sizes = new int[3];

            foreach (int number in numbers)
            {
                sizes[Math.Abs(number % 3)]++;
            }

            for (int index = 0; index < jaggedArray.Length; index++)
            {
                int arrLength = sizes[index];
                jaggedArray[index] = new int[arrLength];
            }

            int[] indexes = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int remainder = Math.Abs(currentNumber % 3);
                jaggedArray[remainder][indexes[remainder]] = currentNumber;
                indexes[remainder]++;
            }

            foreach (int[] ints in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", ints));
            }
        }
    }
}
