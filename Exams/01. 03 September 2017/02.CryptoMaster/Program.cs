using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _02.CryptoMaster
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int longestSequence = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {

                    int currentCount = 1;
                    int currentNum = i % numbers.Length;
                    int next = (currentNum + step) % numbers.Length;
                    while (numbers[currentNum] < numbers[next])
                    {
                        currentCount++;
                        currentNum = next;
                        next = (next + step) % numbers.Length;
                    }

                    if (currentCount > longestSequence)
                    {
                        longestSequence = currentCount;
                    }
                }
            }
            Console.WriteLine(longestSequence);
        }
    }
}
