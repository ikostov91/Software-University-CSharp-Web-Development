using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string destination = string.Empty;
            string campOrHotel = string.Empty;
            decimal moneySpent = 0.00M;

            if (budget <= 100.00M)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        campOrHotel = "Camp";
                        moneySpent = budget * 0.3M;
                        break;
                    case "winter":
                        campOrHotel = "Hotel";
                        moneySpent = budget * 0.7M;
                        break;
                }
            }
            else if (budget > 100.00M && budget <= 1000.00M)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        campOrHotel = "Camp";
                        moneySpent = budget * 0.4M;
                        break;
                    case "winter":
                        campOrHotel = "Hotel";
                        moneySpent = budget * 0.8M;
                        break;
                }
            }
            else if (budget > 1000.00M)
            {
                destination = "Europe";
                campOrHotel = "Hotel";
                moneySpent = budget * 0.9M;
            }

            Console.WriteLine("Somewhere in " + destination);
            Console.WriteLine("{0} - {1:f2}", campOrHotel, moneySpent);
        }
    }
}
