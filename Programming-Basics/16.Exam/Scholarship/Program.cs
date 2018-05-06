using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal income = decimal.Parse(Console.ReadLine());
            decimal averageGrade = decimal.Parse(Console.ReadLine());
            decimal minimumPay = decimal.Parse(Console.ReadLine());

            decimal socialScholarship = 0m, topGradeScholarship = 0m;

            if ((income >= minimumPay || averageGrade <= 4.5m) && averageGrade < 5.5m)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else
            {
                if (income < minimumPay && averageGrade > 4.5m)
                {
                    socialScholarship = 0.35m * minimumPay;
                }

                if (averageGrade >= 5.5m)
                {
                    topGradeScholarship = averageGrade * 25m;
                }

                if (topGradeScholarship > socialScholarship)
                {
                    Console.WriteLine("You get a scholarship for excellent results {0} BGN", Math.Floor(topGradeScholarship));
                }
                else
                {
                    Console.WriteLine("You get a Social scholarship {0} BGN", Math.Floor(socialScholarship));
                }
            }
        }
    }
}
