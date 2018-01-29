using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.RubiksMatrix
{
    class Program
    {
        private static int[,] matrix;
        static void Main()
        {
            CreateMatrix();

            ExecuteCommands();

            StringBuilder result = RearrangeMatrix();

            Console.WriteLine(result.ToString());
        }

        static StringBuilder RearrangeMatrix()
        {
            StringBuilder sb = new StringBuilder();
            int expectedNum = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != expectedNum)
                    {
                        sb.Append(SwapElements(row, col, expectedNum));
                    }
                    else
                    {
                        sb.Append($"No swap required{Environment.NewLine}");
                    }
                    expectedNum++;
                }
            }

            return sb;
        }

        static string SwapElements(int row, int col, int expectedValue)
        {
            for (int rowIndex = row; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    if (matrix[rowIndex, colIndex] == expectedValue)
                    {
                        var temp = matrix[rowIndex, colIndex];
                        matrix[rowIndex, colIndex] = matrix[row, col];
                        matrix[row, col] = temp;

                        return $"Swap ({row}, {col}) with ({rowIndex}, {colIndex}){Environment.NewLine}";
                    }
                }
            }

            return string.Empty;
        }

        static void ExecuteCommands()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                MoveElements(tokens);
             }
        }

        static void CreateMatrix()
        {
            int[] matrixSize = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse).ToArray();

            int rowsLength = matrixSize[0];
            int columnsLength = matrixSize[1];

            matrix = new int[rowsLength, columnsLength];

            int elementForMatrix = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elementForMatrix;
                    elementForMatrix++;
                }
            }
        }

        static void MoveElements(string[] tokens)
        {
            string command = tokens[1];
            int rowOrColIndex = int.Parse(tokens[0]);
            int movesCount = int.Parse(tokens[2]);

            int jumps = movesCount % matrix.Length;
            
            switch (command)
            {
                case "up":
                    jumps = movesCount % matrix.GetLength(0);
                    if (jumps == 0)
                    {
                        return;
                    }
                    MoveColumnUp(rowOrColIndex, jumps);

                    break;
                case "down":
                    jumps = movesCount % matrix.GetLength(0);
                    if (jumps == 0)
                    {
                        return;
                    }
                    MoveColumnDown(rowOrColIndex, jumps);

                    break;
                case "left":
                    jumps = movesCount % matrix.GetLength(1);
                    if (jumps == 0)
                    {
                        return;
                    }
                    MoveRowLeft(rowOrColIndex, jumps);

                    break;
                case "right":
                    jumps = movesCount % matrix.GetLength(1);
                    if (jumps == 0)
                    {
                        return;
                    }
                    MoveRowRight(rowOrColIndex, jumps);

                    break;
            }
        }

        static void MoveRowRight(int rowOrColIndex, int moves)
        {
            int rowIndex = rowOrColIndex;
            int columnIndex = moves;
            Queue<int> rowElements = new Queue<int>();
            int columnLength = matrix.GetLength(1);

            for (int i = 0; i < moves; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    rowElements.Enqueue(matrix[rowIndex, columnIndex]);
                    columnIndex++;
                    if (columnIndex > columnLength - 1)
                    {
                        columnIndex = 0;
                    }
                }

                columnIndex = moves;
                bool hasColumnIndexDecreased = false;

                for (int j = 0; j < columnLength; j++)
                {
                    if (columnIndex + 1 > columnLength - 1)
                    {
                        columnIndex = 0;
                        hasColumnIndexDecreased = true;
                    }
                    if (hasColumnIndexDecreased)
                    {
                        columnIndex--;
                    }

                    hasColumnIndexDecreased = false;
                    matrix[rowIndex, columnIndex + 1] = rowElements.Dequeue();
                    columnIndex++;
                }
            }
        }

        static void MoveRowLeft(int rowOrColIndex, int moves)
        {
            int rowIndex = rowOrColIndex;
            int columnIndex = moves;
            Queue<int> rowElements = new Queue<int>();
            int columnLength = matrix.GetLength(1);

            for (int i = 0; i < moves; i++)
            {
                for (int j = 0; j < columnLength; j++)
                {
                    rowElements.Enqueue(matrix[rowIndex, columnIndex]);
                    columnIndex--;
                    if (columnIndex < 0)
                    {
                        columnIndex = columnLength - 1;
                    }
                }

                columnIndex = moves;
                bool hasColumnIndexDecreased = false;

                for (int j = 0; j < columnLength; j++)
                {
                    if (columnIndex - 1 < 0)
                    {
                        columnIndex = columnLength - 1;
                        hasColumnIndexDecreased = true;
                    }
                    if (hasColumnIndexDecreased)
                    {
                        columnIndex++;
                    }

                    hasColumnIndexDecreased = false;
                    matrix[rowIndex, columnIndex - 1] = rowElements.Dequeue();
                    columnIndex--;
                }
            }
        }

        static void MoveColumnDown(int rowOrColIndex, int moves)
        {
            int columnIndex = rowOrColIndex;
            int rowIndex = moves;
            Queue<int> colElements = new Queue<int>();
            int rowLength = matrix.GetLength(0);

            for (int i = 0; i < moves; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    colElements.Enqueue(matrix[rowIndex, columnIndex]);
                    rowIndex++;
                    if (rowIndex > rowLength - 1)
                    {
                        rowIndex = 0;
                    }
                }

                rowIndex = moves;
                bool hasRowIndexIncreased = false;

                for (int j = 0; j < rowLength; j++)
                {
                    if (rowIndex + 1 > rowLength - 1)
                    {
                        rowIndex = 0;
                        hasRowIndexIncreased = true;
                    }
                    if (hasRowIndexIncreased)
                    {
                        rowIndex--;
                    }

                    hasRowIndexIncreased = false;
                    matrix[rowIndex + 1, columnIndex] = colElements.Dequeue();
                    rowIndex++;
                }
            }
        }

        static void MoveColumnUp(int rowOrColIndex, int moves)
        {
            int columnIndex = rowOrColIndex;
            int rowIndex = moves;
            Queue<int> colElements = new Queue<int>();
            int rowLength = matrix.GetLength(0);

            for (int i = 0; i < moves; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    colElements.Enqueue(matrix[rowIndex, columnIndex]);
                    rowIndex--;
                    if (rowIndex < 0)
                    {
                        rowIndex = rowLength - 1;
                    }
                }

                rowIndex = moves;
                bool hasRowIndexDecreased = false;

                for (int j = 0; j < rowLength; j++)
                {
                    if (rowIndex - 1 < 0)
                    {
                        rowIndex = rowLength - 1;
                        hasRowIndexDecreased = true;
                    }
                    if (hasRowIndexDecreased)
                    {
                        rowIndex++;
                    }

                    hasRowIndexDecreased = false;
                    matrix[rowIndex - 1, columnIndex] = colElements.Dequeue();
                    rowIndex--;
                }
            }
        }
    }
}
