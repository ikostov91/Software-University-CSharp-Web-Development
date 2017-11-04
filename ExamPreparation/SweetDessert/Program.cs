using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDessert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal moneyAvailable = decimal.Parse(Console.ReadLine());
            ulong guests = ulong.Parse(Console.ReadLine());
            decimal bananasPrice = decimal.Parse(Console.ReadLine());
            decimal eggsPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());

            ulong numberOfPortions = guests;

            while (numberOfPortions % 6 != 0)
            {
                numberOfPortions += 1;
            }

            ulong setsOfSixPortions = numberOfPortions / 6;
            decimal moneyNeeded = setsOfSixPortions * (2 * bananasPrice + 4 * eggsPrice + 0.2m * berriesPrice);

            if (moneyAvailable >= moneyNeeded)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {moneyNeeded:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(moneyNeeded - moneyAvailable):F2}lv more.");
            }
        }
    }
}
