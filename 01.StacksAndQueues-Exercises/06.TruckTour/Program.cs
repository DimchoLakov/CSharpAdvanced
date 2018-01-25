using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    class Program
    {
        static void Main()
        {
            int petrolPumpsCount = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < petrolPumpsCount; i++)
            {
                int[] pump = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                queue.Enqueue(pump);
            }

            for (int currentPumpIndex = 0; currentPumpIndex < petrolPumpsCount; currentPumpIndex++)
            {
                int fuel = 0;

                bool isFuelEnough = true;

                for (int pumpsPassed = 0; pumpsPassed < petrolPumpsCount; pumpsPassed++)
                {
                    int[] currentPump = queue.Dequeue();

                    int fuelFromPump = currentPump[0];
                    int distanceToNextPump = currentPump[1];

                    queue.Enqueue(currentPump);

                    fuel += fuelFromPump - distanceToNextPump;

                    if (fuel < 0)
                    {
                        currentPumpIndex += pumpsPassed;
                        isFuelEnough = false;
                        break;
                    }
                }

                if (isFuelEnough)
                {
                    Console.WriteLine(currentPumpIndex);
                    break;
                }
            }
        }
    }
}
