using System;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _01.MatrixOfPalindromes
{
    class Program
    {
        static void Main()
        {
            int[] rowsColumns = Console.ReadLine()
                                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

            int rows = rowsColumns[0];
            int columns = rowsColumns[1];

            string[,] matrix = new string[rows, columns];

            char[] alphabet = new char[26];
            int index = 0;
            for (int i = 97; i <= 122; i++)
            {
                alphabet[index] = (char) i;
                index++;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = $"{alphabet[row]}{alphabet[column + row]}{alphabet[row]}";
                    Console.Write(matrix[row, column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
