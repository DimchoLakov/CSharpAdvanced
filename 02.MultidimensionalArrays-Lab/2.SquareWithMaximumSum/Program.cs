using System;
using System.Linq;

namespace _2.SquareWithMaximumSum
{
    class Program
    {
        static void Main()
        {
            int[] matrixSizeInput = Console.ReadLine()
                                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse).ToArray();
            int rows = matrixSizeInput[0];
            int columns = matrixSizeInput[1];

            int[,] matrix = new int[rows, columns];

            AssignValuesToIndexes(matrix);

            int sum = 0;
            int rowIndex = 0;
            int columnIndex = 0;
            int[] result = FindSquareMatrixWithMaxSum(matrix, ref sum, ref rowIndex, ref columnIndex);

            PrintResult(matrix, out sum, out rowIndex, out columnIndex, result);
        }

        static void PrintResult(int[,] matrix, out int sum, out int rowIndex, out int columnIndex, int[] result)
        {
            sum = result[0];
            rowIndex = result[1];
            columnIndex = result[2];

            Console.WriteLine($"{matrix[rowIndex, columnIndex]} {matrix[rowIndex, columnIndex + 1]}" +
                              $"{Environment.NewLine}" +
                              $"{matrix[rowIndex + 1, columnIndex]} {matrix[rowIndex + 1, columnIndex + 1]}");

            Console.WriteLine(sum);
        }

        static int[] FindSquareMatrixWithMaxSum(int[,] matrix, ref int sum, ref int rowIndex, ref int columnIndex)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    int tempSum = matrix[row, column] + matrix[row, column + 1] + matrix[row + 1, column] +
                        matrix[row + 1, column + 1];
                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = row;
                        columnIndex = column;
                    }
                }
            }
            return new int[] {sum, rowIndex, columnIndex};
        }

        static void AssignValuesToIndexes(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = numbers[column];
                }
            }
        }
    }
}
