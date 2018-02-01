using System;
using System.Linq;

namespace _11.ParkingSystem
{
    class Program
    {
        private static int[][] matrix;
        private static int rows;
        static void Main()
        {
            CreateMatrix();

            ParkCars();
        }

        static void ParkCars()
        {
            string input = Console.ReadLine();

            while (!input.Equals("stop"))
            {
                int[] tokens = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int entryRow = tokens[0];
                int targetRow = tokens[1];
                int targetColumn = tokens[2];

                int rowCounter = Math.Abs(targetRow - entryRow) + 1;
                int columnCounter = targetColumn;
                int moves = 0;

                if (matrix[targetRow] == null)
                {
                    matrix[targetRow] = new int[rows];
                }
                int colLength = matrix[targetRow].Length;
                if (matrix[targetRow][targetColumn] == 1)
                {
                    int nextLeftIndex = FindNextLeft(targetRow, targetColumn);
                    int nextRightIndex = FindNextRight(targetRow, targetColumn, colLength);

                    int leftDiff = targetColumn - nextLeftIndex;
                    int rightDiff = nextRightIndex - targetColumn;

                    if (leftDiff == rightDiff && nextLeftIndex > 0)
                    {
                        matrix[targetRow][nextLeftIndex] = 1;
                        columnCounter = nextLeftIndex;
                    }
                    else if (leftDiff == rightDiff && nextRightIndex > 0)
                    {
                        matrix[targetRow][nextRightIndex] = 1;
                        columnCounter = nextRightIndex;
                    }
                    else if (nextLeftIndex > 0 && nextRightIndex == -1)
                    {
                        matrix[targetRow][nextLeftIndex] = 1;
                        columnCounter = nextLeftIndex;
                    }
                    else if (nextLeftIndex == -1 && nextRightIndex > 0)
                    {
                        matrix[targetRow][nextRightIndex] = 1;
                        columnCounter = nextRightIndex;
                    }
                    else if (leftDiff > rightDiff && nextRightIndex > 0)
                    {
                        matrix[targetRow][nextRightIndex] = 1;
                        columnCounter = nextRightIndex;
                    }
                    else if (leftDiff < rightDiff && nextLeftIndex > 0)
                    {
                        matrix[targetRow][nextLeftIndex] = 1;
                        columnCounter = nextLeftIndex;
                    }
                    else
                    {
                        Console.WriteLine($"Row {targetRow} full");
                        input = Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    matrix[targetRow][targetColumn] = 1;
                }

                moves = rowCounter + columnCounter;
                Console.WriteLine(moves);
                input = Console.ReadLine();
            }
        }

        static int FindNextRight(int targetRow, int targetColumn, int columnLength)
        {
            for (int col = targetColumn + 1; col < columnLength; col++)
            {
                if (matrix[targetRow][col] == 0)
                {
                    return col;
                }
            }
            return -1;
        }

        static int FindNextLeft(int targetRow, int targetColumn)
        {
            for (int col = targetColumn - 1; col >= 1; col--)
            {
                if (matrix[targetRow][col] == 0)
                {
                    return col;
                }
            }
            return -1;
        }

        static void CreateMatrix()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            rows = dimensions[1];

            matrix = new int[dimensions[0]][];
        }
    }
}
