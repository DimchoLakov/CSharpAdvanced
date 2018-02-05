using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            
            Action<string> printName = x => Console.WriteLine(string.Format($"Sir {x}"));

            for (int i = 0; i < names.Length; i++)
            {
                printName(names[i]);
            }
        }
    }
}
