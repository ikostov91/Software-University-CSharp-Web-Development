using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());

            int peshoHealth = 100, goshoHealth = 100, round = 0;

            do
            {
                round++;

                if (round % 2 == 0)
                {
                    peshoHealth -= goshoDamage;

                    if (peshoHealth <= 0)
                    {
                        break;
                    }

                    Console.WriteLine("Gosho used Thunderous fist and reduced Pesho to {0} health.", peshoHealth);
                }
                else
                {
                    goshoHealth -= peshoDamage;

                    if (goshoHealth <= 0)
                    {
                        break;
                    }

                    Console.WriteLine("Pesho used Roundhouse kick and reduced Gosho to {0} health.", goshoHealth);
                }
               
                if (round % 3 == 0)
                {
                    peshoHealth += 10;
                    goshoHealth += 10;
                }

            } while (true);

            if (peshoHealth <= 0)
            {
                Console.WriteLine("Gosho won in {0}th round.", round);
            }
            else
            {
                Console.WriteLine("Pesho won in {0}th round.", round);
            }
        }
    }
}
