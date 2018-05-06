using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            int studioPerNight = 0, doublePerNight = 0, suitePerNight = 0;
            double studioPrice = 0, doublePrice    = 0, suitePrice     = 0,
                   studioDisc  = 0, doubleDisc     = 0, suiteDisc      = 0, freeNight = 0;

            switch (month)
            {
                case "May":
                case "October":

                    studioPerNight = 50;
                    doublePerNight = 65;
                    suitePerNight = 75;

                    if (nightsCount > 7)
                    {
                        studioDisc = 0.05;

                        if (month == "October")
                        {
                            freeNight = 1;
                        }
                    }         
                    break;

                case "June":
                case "September":

                    studioPerNight = 60;
                    doublePerNight = 72;
                    suitePerNight = 82;

                    if (month == "September" && nightsCount > 7)
                    {
                        freeNight = 1;
                    }
                    else if (nightsCount > 14)
                    {
                        doubleDisc = 0.10;
                    }
                    break;

                case "July": 
                case "August":
                case "December":

                    studioPerNight = 68;
                    doublePerNight = 77;
                    suitePerNight = 89;

                    if (nightsCount > 14)
                    {
                        suiteDisc = 0.15;
                    }
                    break;
            }

            studioPrice = (studioPerNight - studioPerNight * studioDisc) * (nightsCount - freeNight);
            doublePrice = (doublePerNight - doublePerNight * doubleDisc) * nightsCount;
            suitePrice = (suitePerNight - suitePerNight * suiteDisc) * nightsCount;

            Console.WriteLine("Studio: {0:F2} lv.", studioPrice);
            Console.WriteLine("Double: {0:F2} lv.", doublePrice);
            Console.WriteLine("Suite: {0:F2} lv.", suitePrice);
        }
    }
}
