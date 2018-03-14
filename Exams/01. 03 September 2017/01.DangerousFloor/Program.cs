using System;
using System.Linq;

namespace _01.DangerousFloor
{
    class Program
    {
        private static char[,] matrix = new char[8, 8];
        private static char[] pieces = new char[] { 'K', 'R', 'B', 'Q', 'P' };
        static void Main()
        {
            for (int row = 0; row < 8; row++)
            {
                char[] pieces = Console.ReadLine()
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < pieces.Length; col++)
                {
                    matrix[row, col] = pieces[col];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input
                    .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string first = tokens[0];
                string second = tokens[1];

                char figure = first[0];
                int currentRow = (int)char.GetNumericValue(first[1]);
                int currentCol = (int)char.GetNumericValue(first[2]);

                int finalRow = (int)char.GetNumericValue(second[0]);
                int finalCol = (int)char.GetNumericValue(second[1]);

                IsMovePossible(figure, currentRow, currentCol, finalRow, finalCol);

                input = Console.ReadLine();
            }
        }

        static void IsMovePossible(char figure, int currentRow, int currentCol, int finalRow, int finalCol)
        {
            bool isPieceAllowed = IsThereSuchPiece(figure, currentRow, currentCol);
            if (!isPieceAllowed)
            {
                Console.WriteLine($"There is no such a piece!");
                return;
            }
            switch (figure)
            {
                case 'K':
                    bool isKingsMoveValid = CheckKingsMove(currentRow, currentCol, finalRow, finalCol);
                    if (!isKingsMoveValid)
                    {
                        PrintInvalidMove();
                    }
                    else
                    {
                        try
                        {
                            matrix[currentRow, currentCol] = 'x';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                        }
                        try
                        {
                            matrix[finalRow, finalCol] = 'K';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                            matrix[currentRow, currentCol] = 'K';
                        }
                    }
                    break;
                case 'R':
                    bool isRooksMoveValid = CheckRooksMove(currentRow, currentCol, finalRow, finalCol);
                    if (!isRooksMoveValid)
                    {
                        PrintInvalidMove();
                    }
                    else
                    {
                        try
                        {
                            matrix[currentRow, currentCol] = 'x';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                        }
                        try
                        {
                            matrix[finalRow, finalCol] = 'R';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                            matrix[currentRow, currentCol] = 'R';
                        }
                    }
                    break;
                case 'B':
                    bool isBishopsMoveValid = CheckBishopsMove(currentRow, currentCol, finalRow, finalCol);

                    if (!isBishopsMoveValid)
                    {
                        PrintInvalidMove();
                    }
                    else
                    {
                        try
                        {
                            matrix[currentRow, currentCol] = 'x';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                        }
                        try
                        {
                            matrix[finalRow, finalCol] = 'B';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                            matrix[currentRow, currentCol] = 'B';
                        }
                    }
                    break;
                case 'Q':
                    bool isQueensMoveValid = CheckQueensMove(currentRow, currentCol, finalRow, finalCol);
                    if (!isQueensMoveValid)
                    {
                        PrintInvalidMove();
                    }
                    else
                    {
                        try
                        {
                            matrix[currentRow, currentCol] = 'x';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                        }
                        try
                        {
                            matrix[finalRow, finalCol] = 'Q';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                            matrix[currentRow, currentCol] = 'Q';
                        }
                    }
                    break;
                case 'P':
                    bool isPawnsMoveValid = CheckPawnsMove(currentRow, currentCol, finalRow, finalCol);
                    if (!isPawnsMoveValid)
                    {
                        PrintInvalidMove();
                    }
                    else
                    {
                        try
                        {
                            matrix[currentRow, currentCol] = 'x';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                        }
                        try
                        {
                            matrix[finalRow, finalCol] = 'P';
                        }
                        catch (Exception)
                        {
                            PrintMoveOutOfBoard();
                            matrix[currentRow, currentCol] = 'P';
                        }
                    }
                    break;
            }
        }

        static bool CheckPawnsMove(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            int rowDiff = currentRow - finalRow;
            if (rowDiff == 1 && currentCol == finalCol)
            {
                return true;
            }
            return false;
        }

        static bool CheckQueensMove(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if (CheckRooksMove(currentRow, currentCol, finalRow, finalCol) || CheckBishopsMove(currentRow, currentCol, finalRow, finalCol))
            {
                return true;
            }
            return false;
        }

        static bool CheckBishopsMove(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            int leftDiff = Math.Abs(currentRow - finalRow);
            int rightDiff = Math.Abs(currentCol - finalCol);

            bool leftUpRow = finalRow < currentRow;
            bool leftUpCol = finalCol < currentCol;

            bool rightUpRow = finalRow < currentRow;
            bool rightUpCol = finalCol > currentCol;

            bool rightDownRow = finalRow > currentRow;
            bool rightDownCol = finalCol > currentCol;

            bool leftDownRow = finalRow > currentRow;
            bool leftDownCol = finalCol < currentCol;

            if (leftDiff == rightDiff)
            {
                if ((leftUpRow && leftUpCol) || (rightUpRow && rightUpCol) || (rightDownRow && rightDownCol) || (leftDownRow && leftDownCol))
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckRooksMove(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            if ((currentRow == finalRow && currentCol != finalCol) || (currentRow != finalRow && currentCol == finalCol))
            {
                return true;
            }
            return false;
        }

        static bool CheckKingsMove(int currentRow, int currentCol, int finalRow, int finalCol)
        {
            int rowDiff = Math.Abs(currentRow - finalRow);
            int colDiff = Math.Abs(currentCol - finalCol);
            if (rowDiff > 1 || colDiff > 1)
            {
                return false;
            }
            return true;
        }

        static void PrintMoveOutOfBoard()
        {
            Console.WriteLine($"Move go out of board!");
        }

        static void PrintInvalidMove()
        {
            Console.WriteLine($"Invalid move!");
        }

        static bool IsThereSuchPiece(char figure, int currentRow, int currentCol)
        {
            return matrix[currentRow, currentCol] == figure;
        }
    }
}
