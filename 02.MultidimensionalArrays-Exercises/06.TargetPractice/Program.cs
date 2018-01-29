using System;
using System.Linq;
using System.Text;

namespace _06.TargetPractice
{
    class Program
    {
        private static char[,] matrix;
        private static string snake;
        private static int[] shotParameters;
        private static int rowsLength;
        private static int colsLength;
        static void Main()
        {
            CreateMatrix();

            snake = Console.ReadLine();

            shotParameters = GetShotParameters();

            FillMatrixWithSnakes();

            ShootSnakes();
            
            LandSymbols();

            PrintFinalMatrix();
        }

        static void PrintFinalMatrix()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.Append(matrix[row, col]);
                }
                sb.AppendLine();
            }
            string result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }

        static void LandSymbols()
        {
            for (int col = 0; col < colsLength; col++)
            {
                int emptyCells = 0;
                for (int row = rowsLength - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == ' ')
                    {
                        emptyCells++;
                    }
                    else if (emptyCells > 0)
                    {
                        matrix[row + emptyCells, col] = matrix[row, col];
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        static void ShootSnakes()
        {
            int impactRow = shotParameters[0];
            int impactCol = shotParameters[1];
            int radius = shotParameters[2];

            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < colsLength; col++)
                {
                    int a = impactRow - row;
                    int b = impactCol - col;
                    double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

                    if (distance <= radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        static void FillMatrixWithSnakes()
        {
            int snakeIndex = 0;
            int snakeLength = snake.Length;
            int rowEvenOrOdd = 2;
            for (int row = rowsLength - 1; row >= 0; row--)
            {
                if (rowEvenOrOdd % 2 == 0)
                {
                    for (int col = colsLength - 1; col >= 0; col--)
                    {
                        if (snakeIndex == snakeLength)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < colsLength; col++)
                    {
                        if (snakeIndex == snakeLength)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                    }
                }
                rowEvenOrOdd++;
            }
        }

        static int[] GetShotParameters()
        {
            int[] shotParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            return shotParams;
        }

        static void CreateMatrix()
        {
            int[] dimensions = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            matrix = new char[rows, columns];

            rowsLength = matrix.GetLength(0);
            colsLength = matrix.GetLength(1);
        }
    }
}
