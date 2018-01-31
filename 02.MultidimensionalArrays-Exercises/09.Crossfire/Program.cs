using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.Crossfire
{
    class Program
    {
        private static List<List<int>> matrix;

        static void Main()
        {
            InitializeMatrix();

            ExecuteCommands();

            PrintMatrix();
        }

        static void ExecuteCommands()
        {
            string input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                int[] tokens = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int impactRow = tokens[0];
                int impactCol = tokens[1];
                int radius = tokens[2];

                DestroyCells(impactRow, impactCol, radius);

                input = Console.ReadLine();
            }
        }

        static void DestroyCells(int impactRow, int impactCol, int radius)
        {
            if (impactRow >= 0 && impactRow < matrix.Count)
            {
                int startColIndex = Math.Max(0, impactCol - radius);
                int endColIndex = Math.Min(impactCol + radius, matrix[impactRow].Count - 1);
                for (int col = startColIndex; col <= endColIndex; col++)
                {
                    matrix[impactRow][col] = 0;
                }
            }

            if (impactCol >= 0 && impactCol < matrix[0].Count)
            {
                int startRowIndex = Math.Max(0, impactRow - radius);
                int endRowIndex = Math.Min(impactRow + radius, matrix.Count - 1);
                for (int row = startRowIndex; row <= endRowIndex; row++)
                {
                    if (impactCol < matrix[row].Count)
                    {
                        matrix[row][impactCol] = 0;
                    }
                }
            }

            List<int> rowsToRemove = new List<int>();
            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row].RemoveAll(x => x == 0);
                if (matrix[row].Count == 0)
                {
                    rowsToRemove.Add(row);
                }
            }
            for (int i = 0; i < rowsToRemove.Count; i++)
            {
                matrix.RemoveAt(rowsToRemove[i]);
            }
        }

        static void PrintMatrix()
        {
            int rowsLength = matrix.Count;
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < rowsLength; row++)
            {
                int columnsLength = matrix[row].Count;
                for (int col = 0; col < columnsLength; col++)
                {
                    sb.Append(matrix[row][col] + " ");
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }

        static void InitializeMatrix()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rowsLength = dimensions[0];
            int columnsLength = dimensions[1];

            matrix = new List<List<int>>();

            int number = 1;

            for (int row = 0; row < rowsLength; row++)
            {
                matrix.Add(new List<int>());
                for (int i = 0; i < columnsLength; i++)
                {
                    matrix[row].Add(number);
                    number++;
                }
            }
        }
    }
}
