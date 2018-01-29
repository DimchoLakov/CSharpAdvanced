using System;
using System.Linq;

namespace _07.LegoBlocks
{
    class Program
    {
        private static int[][] firstJaggedArray;
        private static int[][] secondJaggedArray;
        private static int[,] matrix;
        private static int n;
        static void Main()
        {
            ReadJaggedArrays();

            ReverseSecondJaggedArray();

            CreateMatrix();

            bool isMatrix = IsMatrixPossible();

            if (isMatrix)
            {
                PrintMatrix();
            }

            int cells = GetCellsCount();
            Console.WriteLine($"The total number of cells is: {cells}");
        }

        static int GetCellsCount()
        {
            int cells = 0;
            for (int i = 0; i < firstJaggedArray.Length; i++)
            {
                cells += firstJaggedArray[i].Length;
            }
            for (int i = 0; i < secondJaggedArray.Length; i++)
            {
                cells += secondJaggedArray[i].Length;
            }
            return cells;
        }

        static void CreateMatrix()
        {
            int firstLength = firstJaggedArray[0].Length;
            int secondLength = secondJaggedArray[0].Length;
            int columns = firstLength + secondLength;
            matrix = new int[n, columns];
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] firstArr = firstJaggedArray[row].ToArray();
                int[] secondArr = secondJaggedArray[row].ToArray();

                int curentIndex = 0;

                for (int col = 0; col < firstArr.Length; col++)
                {
                    matrix[row, col] = firstArr[col];
                    curentIndex++;
                }

                for (int col = 0; col < secondArr.Length; col++)
                {
                    matrix[row, curentIndex] = secondArr[col];
                    curentIndex++;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write($"[");
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    Console.Write($"{matrix[row, col]}, ");
                }
                Console.WriteLine($"{matrix[row, matrix.GetLength(1) - 1]}]");
            }
            Environment.Exit(0);
        }

        static bool IsMatrixPossible()
        {
            int[] arraysLengths = new int[n];

            for (int i = 0; i < n; i++)
            {
                arraysLengths[i] = firstJaggedArray[i].Length + secondJaggedArray[i].Length;
            }
            int firstLength = arraysLengths[0];
            bool areEqual = arraysLengths.All(x => x == firstLength);
            return areEqual;
        }

        static void ReverseSecondJaggedArray()
        {
            for (int i = 0; i < secondJaggedArray.Length; i++)
            {
                for (int j = 0; j < secondJaggedArray[i].Length / 2; j++)
                {
                    int temp = secondJaggedArray[i][j];
                    secondJaggedArray[i][j] = secondJaggedArray[i][secondJaggedArray[i].Length - 1 - j];
                    secondJaggedArray[i][secondJaggedArray[i].Length - 1 - j] = temp;
                }
            }
        }

        static void PrintJaggedArrays()
        {
            for (int i = 0; i < firstJaggedArray.Length; i++)
            {
                for (int j = 0; j < firstJaggedArray[i].Length; j++)
                {
                    Console.Write(firstJaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 30));
            for (int i = 0; i < secondJaggedArray.Length; i++)
            {
                for (int j = 0; j < secondJaggedArray[i].Length; j++)
                {
                    Console.Write(firstJaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ReadJaggedArrays()
        {
            n = int.Parse(Console.ReadLine());

            firstJaggedArray = new int[n][];
            secondJaggedArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                firstJaggedArray[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                secondJaggedArray[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }
        }
    }
}
