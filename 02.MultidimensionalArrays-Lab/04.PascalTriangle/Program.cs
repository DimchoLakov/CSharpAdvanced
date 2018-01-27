using System;
using System.Diagnostics;
using System.Resources;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];

            for (int row = 0; row < triangle.Length; row++)
            {
                triangle[row] = new long[row + 1];
                long firstElement = triangle[row][0];
                long lastElement = triangle[row].Length - 1;
                triangle[row][firstElement] = 1;
                triangle[row][lastElement] = 1;

                if (row > 1)
                {
                    for (int jRow = 1; jRow < triangle[row].Length - 1; jRow++)
                    {
                        triangle[row][jRow] = triangle[row - 1][jRow - 1] + triangle[row - 1][jRow];
                    }
                }
            }

            foreach (long[] ints in triangle)
            {
                Console.WriteLine(string.Join(" ", ints));
            }
        }
    }
}
