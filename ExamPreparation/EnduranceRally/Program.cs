using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] participants = Console.ReadLine().Split(' ');
            double[] trackLayout = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (var participant in participants)
            {
                double fuel = participant[0];
                var reached = trackLayout.Length - 1;

                for (int i = 0; i < trackLayout.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        fuel += trackLayout[i];
                    }
                    else
                    {
                        fuel -= trackLayout[i];
                    }

                    if (fuel <= 0)
                    {
                        reached = i;
                        break;
                    }
                }

                if (reached == trackLayout.Length - 1 && fuel > 0)
                {
                    Console.WriteLine($"{participant} - fuel left {fuel:F2}");
                }
                else
                {
                    Console.WriteLine($"{participant} - reached {reached}");
                }
            }
        }
    }
}
