using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAfter5Days
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());

            int currentMonthDays = 0;

            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11: currentMonthDays = 30; break;
                case 2:  currentMonthDays = 28; break;
                default: currentMonthDays = 31; break;
            }

            int newDays = days + 5;

            if (newDays > currentMonthDays)
            {
                newDays -= currentMonthDays;
                if (month == 12)
                {
                    month = 1;
                }
                else
                {
                    month++;
                }
            }

            Console.WriteLine("{0}.{1:D2}", newDays, month);
        }
    }
}
