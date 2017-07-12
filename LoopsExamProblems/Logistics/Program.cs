using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int loads = int.Parse(Console.ReadLine());
            int totalLoad = 0;
            decimal transferPrice = 0.0m, averagePrice = 0.0m;
            double busTons = 0, truckTons = 0, trainTons = 0,
                   busP    = 0, truckP    = 0, trainP    = 0;

            for (int i = 0; i < loads; i++)
            {
                int loadWeight = int.Parse(Console.ReadLine());
                totalLoad += loadWeight;

                if (loadWeight <= 3)
                {
                    busTons += loadWeight;
                    transferPrice += (loadWeight* 200.0m);
                }
                else if (loadWeight >= 4 && loadWeight <= 11)
                {
                    truckTons += loadWeight;
                    transferPrice += (loadWeight * 175.0m);
                }
                else if (loadWeight >= 12)
                {
                    trainTons += loadWeight;
                    transferPrice += (loadWeight * 120.0m);
                }
            }

            averagePrice = transferPrice / totalLoad;
            busP = (double)busTons / totalLoad * 100;
            truckP = (double)truckTons / totalLoad * 100;
            trainP = (double)trainTons / totalLoad * 100;

            Console.WriteLine("{0:F2}", averagePrice);
            Console.WriteLine("{0:F2}%", busP);
            Console.WriteLine("{0:F2}%", truckP);
            Console.WriteLine("{0:F2}%", trainP);
        }
    }
}
