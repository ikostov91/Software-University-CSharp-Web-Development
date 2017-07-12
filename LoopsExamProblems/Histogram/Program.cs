using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countP1 = 0, countP2 = 0, countP3 = 0, countP4 = 0, countP5 = 0;
            double p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number < 200)
                {
                    countP1++;
                }
                else if (number >= 200 && number < 400)
                {
                    countP2++;
                }
                else if (number >= 400 && number < 600)
                {
                    countP3++;
                }
                else if (number >= 600 && number < 800)
                {
                    countP4++;
                }
                else if (number >= 800)
                {
                    countP5++;
                }
            }

            p1 = (double)countP1 / n * 100;
            p2 = (double)countP2 / n * 100;
            p3 = (double)countP3 / n * 100;
            p4 = (double)countP4 / n * 100;
            p5 = (double)countP5 / n * 100;

            Console.WriteLine("{0:F2}%", p1);
            Console.WriteLine("{0:F2}%", p2);
            Console.WriteLine("{0:F2}%", p3);
            Console.WriteLine("{0:F2}%", p4);
            Console.WriteLine("{0:F2}%", p5);
        }
    }
}
