using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPerGreenLight = int.Parse(Console.ReadLine());
            Queue<string> carsStopped = new Queue<string>();
            int totalCarsThatPassed = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                if (input == "green")
                {
                    int carsThatCanPass = Math.Min(carsPerGreenLight, carsStopped.Count);

                    for (int i = 0; i < carsThatCanPass; i++)
                    {
                        Console.WriteLine($"{carsStopped.Dequeue()} passed!");
                        totalCarsThatPassed += 1;
                    }
                }
                else
                {
                    carsStopped.Enqueue(input);
                }
            }

            Console.WriteLine($"{totalCarsThatPassed} cars passed the crossroads.");
        }
    }
}
