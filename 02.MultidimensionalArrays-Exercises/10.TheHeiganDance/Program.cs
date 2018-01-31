using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace _10.TheHeiganDance
{
    class Program
    {
        private static int[,] matrix;
        private static int heroRow;
        private static int heroCol;
        private static int playerHitPoints = 18500;
        private static double bossHitPoints = 3000000;
        private static double damageToBoss;
        private static bool isCloudActive = false;
        private static string lastSpell;
        static void Main()
        {
            InitializeMatrix();

            ReadPlayerDamageToBoss();

            Fight();

            PrintResult();
        }

        static void PrintResult()
        {
            string bossState = bossHitPoints <= 0 ? "Defeated!" : $"{bossHitPoints:f2}";
            string playerState = playerHitPoints <= 0 ? $"Killed by {lastSpell}" : $"{playerHitPoints}";
            Console.WriteLine($"Heigan: {bossState}");
            Console.WriteLine($"Player: {playerState}");
            Console.WriteLine($"Final position: {heroRow}, {heroCol}");
        }

        static void Fight()
        {
            while (true)
            {
                if (playerHitPoints >= 0)
                {
                    bossHitPoints -= damageToBoss;
                }

                if (isCloudActive)
                {
                    playerHitPoints -= 3500;
                    isCloudActive = false;
                }

                if (playerHitPoints <= 0 || bossHitPoints <= 0)
                {
                    break;
                }

                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string spell = tokens[0];
                int hitRow = int.Parse(tokens[1]);
                int hitCol = int.Parse(tokens[2]);

                BossAttacks(spell, hitRow, hitCol);
            }
        }

        static void BossAttacks(string spell, int hitRow, int hitCol)
        {
            int startRow = hitRow - 1;
            int endRow = hitRow + 1;

            int startCol = hitCol - 1;
            int endCol = hitCol + 1;

            for (int r = startRow; r <= endRow; r++)
            {
                for (int c = startCol; c <= endCol; c++)
                {
                    if (r == heroRow && c == heroCol)
                    {
                        if (heroRow - 1 < startRow && heroRow - 1 >= 0)
                        {
                            heroRow = heroRow - 1;
                            return;
                        }
                        if (heroRow + 1 > endRow && heroRow + 1 < 15)
                        {
                            heroRow = heroRow + 1;
                            return;
                        }
                        if (heroCol - 1 < startCol && heroCol - 1 >= 0)
                        {
                            heroCol = heroCol - 1;
                            return;
                        }
                        if (heroCol + 1 > endCol && heroCol + 1 < 15)
                        {
                            heroCol = heroCol + 1;
                            return;
                        }
                        if (spell == "Cloud")
                        {
                            playerHitPoints -= 3500;
                            lastSpell = "Plague Cloud";
                            isCloudActive = true;
                            return;
                        }
                        if (spell == "Eruption")
                        {
                            playerHitPoints -= 6000;
                            lastSpell = "Eruption";
                            return;
                        }
                    }
                }
            }
        }
        static void ReadPlayerDamageToBoss()
        {
            damageToBoss = double.Parse(Console.ReadLine());
        }

        static void InitializeMatrix()
        {
            matrix = new int[15, 15];
            heroRow = matrix.GetLength(0) / 2;
            heroCol = matrix.GetLength(1) / 2;
        }
    }
}
