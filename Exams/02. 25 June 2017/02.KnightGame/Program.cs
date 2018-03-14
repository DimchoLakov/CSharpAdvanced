using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace _02.KnightGame
{
    class Program
    {
        private static char[,] matrix;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            InitializeMatrix(n);
            
            int maxAttacks = 1;
            int currentAttacks = 0;
            int maxRow = 0;
            int maxCol = 0;
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            int result = 0;
            
            while (maxAttacks > 0)
            {
                maxAttacks = 0;
                for (int row = 0; row < rowLength; row++)
                {
                    for (int col = 0; col < colLength; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            if (IsKOnBoard(row + 2, col + 1) && IsThereKBotRight(row, col))
                            {
                                currentAttacks++;
                            }

                            if (IsKOnBoard(row + 1, col + 2) && IsThereKBotMidRight(row, col))
                            {
                                currentAttacks++;
                            }

                            if (IsKOnBoard(row + 2, col - 1) && IsThereKBotLeft(row, col))
                            {
                                currentAttacks++;
                            }

                            if (IsKOnBoard(row + 1, col - 2) && IsThereKBotMidLeft(row, col))
                            {
                                currentAttacks++;
                            }

                            if (IsKOnBoard(row - 1, col + 2) && IsThereKTopMidRight(row, col))
                            {
                                currentAttacks++;
                            }

                            if (IsKOnBoard(row - 2, col + 1) && IsThereKTopRight(row, col))
                            {
                                currentAttacks++;
                            }

                            if (IsKOnBoard(row - 1, col - 2) && IsThereKTopMidLeft(row, col))
                            {
                                currentAttacks++;
                            }

                            if (IsKOnBoard(row - 2, col - 1) && IsThereKTopLeft(row, col))
                            {
                                currentAttacks++;
                            }

                            if (currentAttacks > maxAttacks)
                            {
                                maxAttacks = currentAttacks;
                                maxRow = row;
                                maxCol = col;
                            }
                        }

                        currentAttacks = 0;
                    }
                }

                if (maxAttacks > 0)
                {
                    matrix[maxRow, maxCol] = '0';
                    result++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(result);
        }


        static bool IsKOnBoard(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }

        static bool IsThereKBotRight(int row, int col)
        {
            return matrix[row + 2, col + 1] == 'K';
        }

        static bool IsThereKBotMidRight(int row, int col)
        {
            return matrix[row + 1, col + 2] == 'K';
        }

        static bool IsThereKBotLeft(int row, int col)
        {
            return matrix[row + 2, col - 1] == 'K';
        }

        static bool IsThereKBotMidLeft(int row, int col)
        {
            return matrix[row + 1, col - 2] == 'K';
        }

        static bool IsThereKTopMidRight(int row, int col)
        {
            return matrix[row - 1, col + 2] == 'K';
        }

        static bool IsThereKTopRight(int row, int col)
        {
            return matrix[row - 2, col + 1] == 'K';
        }

        static bool IsThereKTopMidLeft(int row, int col)
        {
            return matrix[row - 1, col - 2] == 'K';
        }

        static bool IsThereKTopLeft(int row, int col)
        {
            return matrix[row - 2, col - 1] == 'K';
        }
        static void InitializeMatrix(int i)
        {
            matrix = new char[i, i];
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int row = 0; row < rowLength; row++)
            {
                string inputRow = Console.ReadLine();

                for (int col = 0; col < colLength; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }
        }
    }
}
