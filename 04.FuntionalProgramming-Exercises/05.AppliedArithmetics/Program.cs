using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int[], int[]> add = x => x.Select(n => n += 1).ToArray();
            Func<int[], int[]> subtract = x => x.Select(n => n -= 1).ToArray();
            Func<int[], int[]> multiply = x => x.Select(n => n *= 2).ToArray();
            Action<int[]> printNumbers = x => Console.WriteLine(string.Join(" ", x));

            string command = Console.ReadLine();

            while (!command.Equals("end"))
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "print":
                        printNumbers(numbers);
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
