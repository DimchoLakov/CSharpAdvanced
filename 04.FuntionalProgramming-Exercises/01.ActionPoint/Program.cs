using System;
using System.Runtime.InteropServices;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            Action<string[]> printNames = x => Console.WriteLine(string.Join(Environment.NewLine, names));
            printNames(names);
        }
    }
}
