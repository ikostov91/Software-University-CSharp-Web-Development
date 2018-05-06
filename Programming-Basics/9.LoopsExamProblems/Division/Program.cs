using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countP1 = 0, countP2 = 0, countP3 = 0;
            double p1 = 0, p2 = 0, p3 = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    countP1++;
                }

                if (number % 3 == 0)
                {
                    countP2++;
                }

                if (number % 4 == 0)
                {
                    countP3++;
                }
            }

            p1 = countP1 * 100.0 / n;         //(double)countP1 / n * 100
            p2 = countP2 * 100.0 / n;
            p3 = countP3 * 100.0 / n;

            Console.WriteLine("{0:F2}%", p1);
            Console.WriteLine("{0:F2}%", p2);
            Console.WriteLine("{0:F2}%", p3);
        }
    }
}
