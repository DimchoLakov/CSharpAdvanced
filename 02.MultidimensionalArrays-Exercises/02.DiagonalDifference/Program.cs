using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class Program
    {
        static void Main()
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                int[] values = Console.ReadLine()
                                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

                for (int column = 0; column < sizeOfMatrix; column++)
                {
                    matrix[row, column] = values[column];
                    if (row == column)
                    {
                        primaryDiagonalSum += matrix[row, column];
                    }
                }
            }

            for (int r = 0, c = sizeOfMatrix - 1; r < sizeOfMatrix; r++, c--)
            {
                secondaryDiagonalSum += matrix[r, c];
            }
            int diff = Math.Abs(secondaryDiagonalSum - primaryDiagonalSum);
            Console.WriteLine(diff);
        }
    }
}
