using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            long pumpsNo = long.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();
            long startPump = 0, petrol = 0;

            for (int i = 0; i < pumpsNo; i++)
            {
                int[] pumpInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumps.Enqueue(pumpInfo);
            }

            for (int currentStart = 0; currentStart < pumpsNo - 1; currentStart++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpsPassed = 0; pumpsPassed < pumpsNo; pumpsPassed++)
                {
                    int[] currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);
                    int pumpFuel = currentPump[0];
                    int nextPumpDistance = currentPump[1];

                    fuel += pumpFuel - nextPumpDistance;

                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        isSolution = false;
                        break;
                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }
        }
    }
}
