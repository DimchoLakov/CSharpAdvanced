using System;
using System.Linq;

namespace _04.MaximumSum
{
    class Program
    {
        static void Main()
        {
            int[] sizeMatrix = Console.ReadLine()
                            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int rowsLength = sizeMatrix[0];
            int columnsLength = sizeMatrix[1];

            int[,] matrix = new int[rowsLength, columnsLength];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int bestSum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int topLeft = matrix[row, col];
                    int topMid = matrix[row, col + 1];
                    int topRight = matrix[row, col + 2];

                    int middleLeft = matrix[row + 1, col];
                    int middleMid = matrix[row + 1, col + 1];
                    int middleRight = matrix[row + 1, col + 2];

                    int botLeft = matrix[row + 2, col];
                    int botMid = matrix[row + 2, col + 1];
                    int botRight = matrix[row + 2, col + 2];

                    int sum = topLeft + topMid + topRight + middleLeft + middleMid + middleRight + botLeft + botMid +
                              botRight;

                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int row = bestRow; row <= bestRow + 2; row++)
            {
                for (int col = bestCol; col <= bestCol + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
