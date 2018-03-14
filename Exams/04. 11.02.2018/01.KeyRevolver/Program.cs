using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            List<int> bullets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> locks = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Queue<int> locksQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);

            int valueOfIntelligence = int.Parse(Console.ReadLine());

            int shootCounter = 0;
            int bulletCount = 0;

            while (locksQueue.Count > 0 && bulletsStack.Count > 0)
            {
                int bullet = bulletsStack.Pop();
                int safeLock = locksQueue.Peek();

                if (bullet <= safeLock)
                {
                    Console.WriteLine($"Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Ping!");
                }

                shootCounter++;
                if (shootCounter >= gunBarrelSize)
                {
                    shootCounter = 0;
                    if (bulletsStack.Count != 0)
                    {
                        Console.WriteLine($"Reloading!");
                    }
                }
                bulletCount++;
            }

            int money = valueOfIntelligence - (bulletCount * bulletPrice);

            if (locksQueue.Count > bulletsStack.Count)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${money}");
            }
        }
    }
}
