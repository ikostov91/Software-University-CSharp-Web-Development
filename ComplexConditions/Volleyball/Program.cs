using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int weekendsHomeTown = int.Parse(Console.ReadLine());

            double playInHolidays = holidays * 2 / 3.0;
            double weekendsInSofia = 48 - weekendsHomeTown;
            double playInSofia = weekendsInSofia * 3 / 4.0;
            double totalPlayTime = playInHolidays + playInSofia + weekendsHomeTown;

            if (year == "leap")
            {
                totalPlayTime = totalPlayTime + (totalPlayTime * 15 / 100);
            }

            Console.WriteLine(Math.Floor(totalPlayTime));
        }
    }
}
