using System;
using System.Collections.Generic;

namespace _06.TrafficJam
{
    class Program
    {
        static void Main()
        {
            int nCarsCanPass = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            string input = Console.ReadLine();
            int counter = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    int greenLightPasses = Math.Min(carsQueue.Count, nCarsCanPass);
                    for (int i = 0; i < greenLightPasses; i++)
                    {
                        Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
