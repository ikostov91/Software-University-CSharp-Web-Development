using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());
            decimal studioStayPrice = 0.00m;
            decimal apartmentStayPrice = 0.00m;
            decimal discountStudio = 0.00m;
            decimal discountApartment = 0.00m;

            switch (month)
            {
                case "may":
                case "october":
                    studioStayPrice = nights * 50.0m;
                    apartmentStayPrice = nights * 65.0m;

                    if (nights > 14)
                    {
                        discountStudio = studioStayPrice * 0.3m;
                        discountApartment = apartmentStayPrice * 0.1m;
                    }
                    else if (nights > 7)
                    {
                        discountStudio = studioStayPrice * 0.05m;
                    }
                    break;

                case "june":
                case "september":
                    studioStayPrice = nights * 75.20m;
                    apartmentStayPrice = nights * 68.70m;

                    if (nights > 14)
                    {
                        discountStudio = studioStayPrice * 0.2m;
                        discountApartment = apartmentStayPrice * 0.1m;
                    }
                    break;

                case "july":
                case "august":
                    studioStayPrice = nights * 76.0m;
                    apartmentStayPrice = nights * 77.0m;

                    if (nights > 14)
                    {
                        discountApartment = apartmentStayPrice * 0.1m;
                    }
                    break;

                default:
                    break;
            }

            Console.WriteLine("Apartment: {0:F2} lv.", apartmentStayPrice - discountApartment);
            Console.WriteLine("Studio: {0:F2} lv.", studioStayPrice - discountStudio);
        }
    }
}
