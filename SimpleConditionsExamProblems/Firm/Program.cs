using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int projectHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int employees = int.Parse(Console.ReadLine());

            double daysToWork = days * 0.90;
            double overtime = employees * days * 2;
            double workHours = Math.Floor(daysToWork * 8 + overtime);

            if (workHours >= projectHours)
            {
                double hoursLeft = workHours - projectHours;
                Console.WriteLine("Yes!{0} hours left.", hoursLeft);
            }
            else
            {
                double hoursNeeded = projectHours - workHours;
                Console.WriteLine("Not enough time!{0} hours needed.", hoursNeeded);
            }
        }
    }
}
