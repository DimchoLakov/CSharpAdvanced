using System;
using System.Linq;
using System.Net.Sockets;

namespace _03.SquaresInMatrix
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
                char[] letters = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = letters[col];
                    //Console.WriteLine($"[{row}, {col}] = {(char)matrix[row, col]}");
                }
            }

            int matricesFound = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int topLeft = matrix[row, col];
                    int topRight = matrix[row, col + 1];
                    int botLeft = matrix[row + 1, col];
                    int botRight = matrix[row + 1, col + 1];

                    if (topLeft == topRight && topLeft == botLeft && topLeft == botRight)
                    {
                        matricesFound++;
                    }
                }
            }

            Console.WriteLine(matricesFound);
        }
    }
}
