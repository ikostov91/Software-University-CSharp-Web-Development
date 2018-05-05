using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int workingDaysCounter = 0;
            DateTime[] holidays = new DateTime[11];

            holidays[0] = new DateTime(endDate.Year, 1, 1);
            holidays[1] = new DateTime(endDate.Year, 3, 3);
            holidays[2] = new DateTime(endDate.Year, 5, 1);
            holidays[3] = new DateTime(endDate.Year, 5, 6);
            holidays[4] = new DateTime(endDate.Year, 5, 24);
            holidays[5] = new DateTime(endDate.Year, 9, 6);
            holidays[6] = new DateTime(endDate.Year, 9, 22);
            holidays[7] = new DateTime(endDate.Year, 11, 1);
            holidays[8] = new DateTime(endDate.Year, 12, 24);
            holidays[9] = new DateTime(endDate.Year, 12, 25);
            holidays[10] = new DateTime(endDate.Year, 12, 26);

            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                bool isWorkingDay = CheckDate(i, holidays);

                if (isWorkingDay == true)
                {
                    workingDaysCounter++;
                }
            }

            Console.WriteLine(workingDaysCounter);
        }

        private static bool CheckDate(DateTime i, DateTime[] holidays)
        {
            if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            for (int j = 0; j < holidays.Length; j++)
            {
                if (i.DayOfYear == holidays[j].DayOfYear)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
