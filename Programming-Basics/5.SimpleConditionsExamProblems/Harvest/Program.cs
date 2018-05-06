using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyard = int.Parse(Console.ReadLine());
            double grapesPerSquareMeter = double.Parse(Console.ReadLine());
            int litersWineNeeded = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double usableAreaVineyard = vineyard * 40 / 100;
            double totalGrapesAmmount = usableAreaVineyard * grapesPerSquareMeter;
            double litersFromAvailableGrapes = totalGrapesAmmount / 2.5;

            if (litersFromAvailableGrapes >= litersWineNeeded)
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.", Math.Floor(litersFromAvailableGrapes));
                double litersLeft = Math.Ceiling(litersFromAvailableGrapes - litersWineNeeded);
                double litersPerWorker = Math.Ceiling(litersLeft / workers);
                Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(litersLeft), Math.Ceiling(litersPerWorker));
            }
            else
            {
                double litersNeeded = litersWineNeeded - litersFromAvailableGrapes;
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor(litersNeeded));
            }
        }
    }
}
