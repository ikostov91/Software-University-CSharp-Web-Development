using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double tableLength = double.Parse(Console.ReadLine());
            double tableWidth = double.Parse(Console.ReadLine());

            double coverArea = (tableLength + 0.3 * 2) * (tableWidth + 0.3 * 2);
            double kareSide = tableLength / 2;
            double kareArea = kareSide * kareSide;

            double totalCoverArea = coverArea * tables;
            double totalKareArea = kareArea * tables;

            double priceCovers = totalCoverArea * 7;
            double priceKare = totalKareArea * 9;
            double totalPrice = priceCovers + priceKare;

            Console.WriteLine("{0:F2} USD", totalPrice);
            Console.WriteLine("{0:F2} BGN", totalPrice * 1.85);
        }
    }
}
