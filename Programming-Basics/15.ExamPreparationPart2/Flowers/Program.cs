using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            int chrysantemumAmmount = int.Parse(Console.ReadLine());
            int rosesAmmount = int.Parse(Console.ReadLine());
            int tulipsAmmount = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string holiday = Console.ReadLine().ToLower();

            int totalFlowersBought = chrysantemumAmmount + rosesAmmount + tulipsAmmount;
            decimal chrysantemumPrice = 0m, rosesPrice = 0m, tulipsPrice = 0m, bouquetPrice = 0m, arrangeBouquet = 2m;
     

            switch (season)
            {
                case "spring":
                case "summer":
                    if (holiday == "n")
                    {
                        chrysantemumPrice = 2.00m;
                        rosesPrice = 4.10m;
                        tulipsPrice = 2.50m;
                    }
                    else
                    {
                        chrysantemumPrice = 2.00m + (0.15m * 2.00m);
                        rosesPrice = 4.10m + (0.15m * 4.10m);
                        tulipsPrice = 2.50m + (0.15m * 2.50m);
                    }
                   
                    break;
                case "autumn":
                case "winter":
                    if (holiday == "n")
                    {
                        chrysantemumPrice = 3.75m;
                        rosesPrice = 4.50m;
                        tulipsPrice = 4.15m;
                    }
                    else
                    {
                        chrysantemumPrice = 3.75m + (0.15m * 3.75m);
                        rosesPrice = 4.50m + (0.15m * 4.50m);
                        tulipsPrice = 4.15m + (0.15m * 4.15m);
                    }
                    break;
            }

            bouquetPrice = chrysantemumAmmount * chrysantemumPrice + rosesAmmount * rosesPrice + tulipsAmmount * tulipsPrice;

            if (season == "spring" && tulipsAmmount > 7)
            {
                bouquetPrice -= (0.05m * bouquetPrice);
            }

            if (season == "winter" && rosesAmmount >= 10)
            {
                bouquetPrice -= (0.1m * bouquetPrice);
            }

            if (totalFlowersBought > 20)
            {
                bouquetPrice -= (0.2m * bouquetPrice);
            }

            bouquetPrice += arrangeBouquet;

            Console.WriteLine("{0:F2}", bouquetPrice);
        }
    }
}
