using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.RadioactiveMutantVampireBunnies
{
    class Program
    {
        private static char[,] lair;
        private static int rowsLength;
        private static int columnsLength;
        private static int[] playerLocation = new int[2];
        private static char[] commands;
        private static int rowDead;
        private static int colDead;
        private static int rowWon;
        private static int colWon;
        private static List<int[]> bunnies;
        static void Main()
        {
            CreateMatrix();

            FillMatrix();

            ExecuteCommands();
        }

        static void ExecuteCommands()
        {
            commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                char direction = commands[i];
                string state = MovePlayer(direction);

                FindBunnies();

                bool isDead = SpreadBunnies();

                if (isDead)
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {rowDead} {colDead}");
                    Environment.Exit(0);
                }

                switch (state)
                {
                    case "won":
                        PrintMatrix();
                        Console.WriteLine($"won: {rowWon} {colWon}");
                        Environment.Exit(0);
                        break;
                    case "dead":
                        PrintMatrix();
                        Console.WriteLine($"dead: {rowDead} {colDead}");
                        Environment.Exit(0);
                        break;
                    case "continue":
                        break;
                }
            }
        }

        static void FindBunnies()
        {
            bunnies = new List<int[]>();
            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < columnsLength; col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        bunnies.Add(new int[] {row, col});
                    }
                }
            }
        }

        static bool SpreadBunnies()
        {
            bool hasDied = false;
            for (int i = 0; i < bunnies.Count; i++)
            {
                if (Spread(bunnies[i]))
                {
                    hasDied = true;
                }
            }

            return hasDied;
        }

        static bool Spread(int[] bunns)
        {
            int r = bunns[0];
            int c = bunns[1];
            bool isDead = false;
            try
            {
                if (lair[r - 1, c] == 'P')
                {
                    isDead = true;
                    rowDead = r - 1;
                    colDead = c;
                }
                lair[r - 1, c] = 'B';
            }
            catch (IndexOutOfRangeException)
            {

            }
            try
            {
                if (lair[r + 1, c] == 'P')
                {
                    isDead = true;
                    rowDead = r + 1;
                    colDead = c;
                }
                lair[r + 1, c] = 'B';
            }
            catch (IndexOutOfRangeException)
            {

            }
            try
            {
                if (lair[r, c + 1] == 'P')
                {
                    isDead = true;
                    rowDead = r;
                    colDead = c + 1;
                }
                lair[r, c + 1] = 'B';
            }
            catch (IndexOutOfRangeException)
            {

            }
            try
            {
                if (lair[r, c - 1] == 'P')
                {
                    isDead = true;
                    rowDead = r;
                    colDead = c - 1;
                }
                lair[r, c - 1] = 'B';
            }
            catch (IndexOutOfRangeException)
            {

            }
            return isDead;
        }

        static string MovePlayer(int direction)
        {
            string currentState = string.Empty;
            switch (direction)
            {
                case 'L':
                    currentState = MoveLeft();
                    break;
                case 'R':
                    currentState = MoveRight();
                    break;
                case 'U':
                    currentState = MoveUp();
                    break;
                case 'D':
                    currentState = MoveDown();
                    break;
            }

            return currentState;
        }

        static string MoveRight()
        {
            int playerRow = playerLocation[0];
            int playerCol = playerLocation[1];

            if (playerCol + 1 > columnsLength - 1)
            {
                lair[playerRow, playerCol] = '.';
                rowWon = playerRow;
                colWon = playerCol;
                return "won";
            }
            if (lair[playerRow, playerCol + 1] == 'B')
            {
                lair[playerRow, playerCol] = '.';
                rowDead = playerRow;
                colDead = playerCol + 1;
                return "dead";
            }
            lair[playerRow, playerCol] = '.';
            lair[playerRow, playerCol + 1] = 'P';
            playerLocation[0] = playerRow;
            playerLocation[1] = playerCol + 1;
            return "continue";
        }

        static string MoveLeft()
        {
            int playerRow = playerLocation[0];
            int playerCol = playerLocation[1];

            if (playerCol - 1 < 0)
            {
                lair[playerRow, playerCol] = '.';
                rowWon = playerRow;
                colWon = playerCol;
                return "won";
            }
            if (lair[playerRow, playerCol - 1] == 'B')
            {
                lair[playerRow, playerCol] = '.';
                rowDead = playerRow;
                colDead = playerCol - 1;
                return "dead";
            }
            lair[playerRow, playerCol] = '.';
            lair[playerRow, playerCol - 1] = 'P';
            playerLocation[0] = playerRow;
            playerLocation[1] = playerCol - 1;
            return "continue";
        }

        static string MoveDown()
        {
            int playerRow = playerLocation[0];
            int playerCol = playerLocation[1];

            if (playerRow + 1 > rowsLength - 1)
            {
                lair[playerRow, playerCol] = '.';
                rowWon = playerRow;
                colWon = playerCol;
                return "won";
            }
            if (lair[playerRow + 1, playerCol] == 'B')
            {
                lair[playerRow, playerCol] = '.';
                rowDead = playerRow + 1;
                colDead = playerCol;
                return "dead";
            }
            lair[playerRow, playerCol] = '.';
            lair[playerRow + 1, playerCol] = 'P';
            playerLocation[0] = playerRow + 1;
            playerLocation[1] = playerCol;
            return "continue";
        }

        static string MoveUp()
        {
            int playerRow = playerLocation[0];
            int playerCol = playerLocation[1];

            if (playerRow - 1 < 0)
            {
                lair[playerRow, playerCol] = '.';
                rowWon = playerRow;
                colWon = playerCol;
                return "won";
            }
            if (lair[playerRow - 1, playerCol] == 'B')
            {
                lair[playerRow, playerCol] = '.';
                rowDead = playerRow - 1;
                colDead = playerCol;
                return "dead";
            }
            lair[playerRow, playerCol] = '.';
            lair[playerRow - 1, playerCol] = 'P';
            playerLocation[0] = playerRow - 1;
            playerLocation[1] = playerCol;
            return "continue";
        }
        
        static void PrintMatrix()
        {
            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < columnsLength; col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void FillMatrix()
        {
            for (int row = 0; row < rowsLength; row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < elements.Length; col++)
                {
                    lair[row, col] = elements[col];
                    if (lair[row, col] == 'P')
                    {
                        playerLocation[0] = row;
                        playerLocation[1] = col;
                    }
                }
            }
        }

        static void CreateMatrix()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            rowsLength = dimensions[0];
            columnsLength = dimensions[1];

            lair = new Char[rowsLength, columnsLength];
        }
    }
}
