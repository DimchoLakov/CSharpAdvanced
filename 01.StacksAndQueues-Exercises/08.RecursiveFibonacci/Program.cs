using System;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        private static long[] memoFibNumbers;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            memoFibNumbers = new long[n + 1];

            Console.WriteLine(GetFibonacci(n));
        }

        static long GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memoFibNumbers[n] == 0)
            {
                memoFibNumbers[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            }

            return memoFibNumbers[n];
        }
    }
}
