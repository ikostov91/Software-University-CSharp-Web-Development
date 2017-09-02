using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            decimal floorWidth = decimal.Parse(Console.ReadLine());
            decimal floorLength = decimal.Parse(Console.ReadLine());
            decimal triangleSide = decimal.Parse(Console.ReadLine());
            decimal triangleHeight = decimal.Parse(Console.ReadLine());
            decimal pricePerTile = decimal.Parse(Console.ReadLine());
            decimal workerPrice = decimal.Parse(Console.ReadLine());

            decimal floorArea = floorWidth * floorLength;
            decimal tileArea = triangleHeight * triangleSide / 2;

            decimal tilesNeeded = Math.Ceiling(floorArea / tileArea) + 5;
            decimal tilesPrice = pricePerTile * tilesNeeded;

            decimal totalMoneyNeeded = workerPrice + tilesPrice;

            if (totalMoneyNeeded <= money)
            {
                Console.WriteLine("{0:F2} lv left.", money - totalMoneyNeeded);
            }
            else
            {
                Console.WriteLine("You'll need {0:F2} lv more.", totalMoneyNeeded - money);
            }
        }
    }
}
