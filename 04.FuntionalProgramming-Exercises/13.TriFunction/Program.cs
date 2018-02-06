using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.TriFunction
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            Func<string, int, bool> filter = (name, sum) => name.ToCharArray().Sum(x => x) >= sum;

            string result = names.FirstOrDefault(name => filter(name, n));
            Console.WriteLine(result);
        }
    }
}
