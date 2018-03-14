using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Sneaking
{
    class Program
    {
        private static List<List<char>> matrix = new List<List<char>>();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix.Add(input.ToList());
            }

            int samsRow = 0;
            int samsCol = 0;

            int nikoRow = 0;
            int nikoCol = 0;
            bool isNikoFound = false;
            bool isSamFound = false;

            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        samsRow = row;
                        samsCol = col;
                        isNikoFound = true;
                    }

                    if (matrix[row][col] == 'N')
                    {
                        nikoRow = row;
                        nikoCol = col;
                        isSamFound = true;
                    }

                    if (isSamFound && isNikoFound)
                    {
                        break;
                    }
                }
            }

            string commands = Console.ReadLine();
            bool hasSamDied = false;
            for (int i = 0; i < commands.Length; i++)
            {
                for (int row = 0; row < matrix.Count; row++)
                {
                    if (matrix[row].Contains('b'))
                    {
                        int index = matrix[row].IndexOf('b');
                        if (index == matrix[row].Count - 1)
                        {
                            matrix[row][index] = 'd';
                            if (samsRow == row && samsCol < index)
                            {
                                hasSamDied = true;
                            }
                        }
                        else
                        {
                            matrix[row][index] = '.';
                            matrix[row][index + 1] = 'b';
                        }
                        if (samsRow == row && samsCol > index)
                        {
                            hasSamDied = true;
                        }
                    }
                    else if (matrix[row].Contains('d'))
                    {
                        int index = matrix[row].IndexOf('d');
                        if (index == 0)
                        {
                            matrix[row][index] = 'b';
                            if (samsRow == row && samsCol > index)
                            {
                                hasSamDied = true;
                            }
                        }
                        else
                        {
                            matrix[row][index] = '.';
                            matrix[row][index - 1] = 'd';
                        }
                        if (samsRow == row && samsCol < index)
                        {
                            hasSamDied = true;
                        }
                    }
                }

                if (hasSamDied)
                {
                    matrix[samsRow][samsCol] = 'X';
                    Console.WriteLine($"Sam died at {samsRow}, {samsCol}");
                    PrintMatrix();
                    return;
                }

                switch (commands[i])
                {
                    case 'U':
                        matrix[samsRow][samsCol] = '.';
                        matrix[samsRow - 1][samsCol] = 'S';
                        samsRow -= 1;
                        break;
                    case 'D':
                        matrix[samsRow][samsCol] = '.';
                        matrix[samsRow + 1][samsCol] = 'S';
                        samsRow += 1;

                        break;
                    case 'L':
                        matrix[samsRow][samsCol] = '.';
                        matrix[samsRow][samsCol - 1] = 'S';
                        samsCol -= 1;
                        break;
                    case 'R':
                        matrix[samsRow][samsCol] = '.';
                        matrix[samsRow][samsCol + 1] = 'S';
                        samsCol += 1;
                        break;
                    case 'W':
                        continue;
                        break;
                }

                if (samsRow == nikoRow)
                {
                    matrix[nikoRow][nikoCol] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    PrintMatrix();
                    return;
                }
            }
        }

        static void PrintMatrix()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Count; col++)
                {
                    sb.Append(matrix[row][col]);
                }

                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
