using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            string hallName = string.Empty;
            double price = 0, discount = 0, perPerson = 0, totalPrice = 0;

            if (groupSize <= 50)
            {
                hallName = "Small Hall";
                price += 2500;
            }
            else if (groupSize > 50 && groupSize <= 100)
            {
                hallName = "Terrace";
                price += 5000;
            }
            else if (groupSize > 100 && groupSize <= 120)
            {
                hallName = "Great Hall";
                price += 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            if (package == "Normal")
            {
                price += 500;
                discount = 0.05;
            }
            else if (package == "Gold")
            {
                price += 750;
                discount = 0.10;
            }
            else if (package == "Platinum")
            {
                price += 1000;
                discount = 0.15;
            }

            totalPrice = price - (price * discount);
            perPerson = totalPrice / (double)groupSize;

            Console.WriteLine("We can offer you the {0}", hallName);
            Console.WriteLine("The price per person is {0:F2}$", perPerson);
        }
    }
}
