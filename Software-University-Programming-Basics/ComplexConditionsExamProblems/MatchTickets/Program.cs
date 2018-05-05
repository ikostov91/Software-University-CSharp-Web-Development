using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string category = Console.ReadLine().ToLower();
            int group = int.Parse(Console.ReadLine());
            decimal transportMoney = 0.00m;
            decimal ticketsMoney = 0.00m;
            decimal moneyNeeded = 0.00m;

            if (group < 5)
            {
                transportMoney = budget * 0.75m;
            }
            else if (group >= 5 && group < 10)
            {
                transportMoney = budget * 0.60m;
            }
            else if (group >= 10 && group < 25)
            {
                transportMoney = budget * 0.50m;
            }
            else if (group >= 25 && group < 50)
            {
                transportMoney = budget * 0.40m;
            }
            else if (group >= 50)
            {
                transportMoney = budget * 0.25m;
            }

            if (category == "vip")
            {
                ticketsMoney = group * 499.99m;
            }
            else if (category == "normal")
            {
                ticketsMoney = group * 249.99m;
            }

            moneyNeeded = ticketsMoney + transportMoney;

            if (moneyNeeded <= budget)
            {
                Console.WriteLine("Yes! You have {0:f2} leva left.", budget - moneyNeeded);
            }
            else
            {
                Console.WriteLine("Not enough money! You need {0:f2} leva.", moneyNeeded - budget);
            }
        }
    }
}
