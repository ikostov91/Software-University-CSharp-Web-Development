using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftuniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());

            decimal totalPrice = 0.0m;

            for (int i = 0; i < ordersCount; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                decimal capsulesCount = decimal.Parse(Console.ReadLine());

                int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                decimal priceForMonth = (daysInMonth * capsulesCount) * pricePerCapsule;
                totalPrice += priceForMonth;

                Console.WriteLine($"The price for the coffee is: ${priceForMonth:F2}");
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
