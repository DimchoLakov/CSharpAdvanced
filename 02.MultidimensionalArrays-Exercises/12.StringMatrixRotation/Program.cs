using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.StringMatrixRotation
{
    class Program
    {
        private static int degrees;
        private static List<List<char>> matrix;
        private static Queue<string> queue = new Queue<string>();
        private static int longestString;
        private static StringBuilder sb = new StringBuilder();
        static void Main()
        {
            ReadInput();

            CreateMatrix();

            RotateMatrix();

            PrintMatrix();
        }

        static void PrintMatrix()
        {
            Console.WriteLine(sb.ToString());
        }

        static void RotateMatrix()
        {
            switch (degrees)
            {
                case 90:
                    RotateNinetyDegrees();
                    break;
                case 180:
                    RotateHundredEightyDegrees();
                    break;
                case 270:
                    RotateTwoHundredSeventyDegrees();
                    break;
                default:
                    RotateZeroDegrees();
                    break;
            }
        }

        static void RotateTwoHundredSeventyDegrees()
        {
            int currentRow = 0;
            int colsLength = matrix[currentRow].Count;
            for (int col = colsLength - 1; col >= 0; col--)
            {
                int rowsLength = matrix.Count;
                for (int row = 0; row < rowsLength; row++)
                {
                    sb.Append(matrix[row][col]);
                }
                sb.AppendLine();
            }
        }

        static void RotateHundredEightyDegrees()
        {
            int rowsLength = matrix.Count;
            for (int row = rowsLength - 1; row >= 0; row--)
            {
                int colsRow = matrix[row].Count;
                for (int col = colsRow - 1; col >= 0; col--)
                {
                    sb.Append(matrix[row][col]);
                }
                sb.AppendLine();
            }
        }

        static void RotateNinetyDegrees()
        {
            int rowIndex = matrix.Count - 1;
            for (int col = 0; col < matrix[rowIndex].Count; col++)
            {
                for (int row = matrix.Count - 1; row >= 0; row--)
                {
                    sb.Append(matrix[row][col]);
                }
                sb.AppendLine();
                rowIndex--;
                if (rowIndex < 0)
                {
                    rowIndex = matrix.Count - 1;
                }
            }
        }

        static void RotateZeroDegrees()
        {
            int rowsLength = matrix.Count;
            for (int row = 0; row < rowsLength; row++)
            {
                sb.AppendLine(string.Join("", matrix[row]));
            }
        }

        static void CreateMatrix()
        {
            matrix = new List<List<char>>();
            int index = 0;

            while (queue.Count > 0)
            {
                string str = queue.Dequeue();
                
                matrix.Add(str.ToCharArray().ToList());
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                if (matrix[i].Count < longestString)
                {
                    for (int j = matrix[i].Count; j < longestString; j++)
                    {
                        matrix[i].Add(' ');
                    }
                }
            }
        }

        static void ReadInput()
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            degrees = int.Parse(input[1]) % 360;

            longestString = 0;
            string line = Console.ReadLine();
            while (!line.Equals("END"))
            {
                if (line.Length > longestString)
                {
                    longestString = line.Length;
                }
                queue.Enqueue(line);
                line = Console.ReadLine();
            }
        }
    }
}
