using System;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isShortEnough = x => x.Length <= n;

            foreach (string name in names)
            {
                if (isShortEnough(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
