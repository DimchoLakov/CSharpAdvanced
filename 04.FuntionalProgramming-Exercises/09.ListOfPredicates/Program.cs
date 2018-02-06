using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main()
        {
            int endOfRange = int.Parse(Console.ReadLine());

            int[] divisors = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            Func<int, bool> isDivisible = CreatePredicate(divisors);
            List<int> result = new List<int>();

            for (int i = 1; i <= endOfRange; i++)
            {
                if (isDivisible(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static Func<int, bool> CreatePredicate(int[] divisors)
        {
            return num =>
            {
                foreach (int div in divisors)
                {
                    if (num % div != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
        }
    }
}
