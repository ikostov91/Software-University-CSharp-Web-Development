using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasHat
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dots = n * 2 - 1, dashes = 0;

            Console.WriteLine("{0}/|\\{1}", new string('.', dots), new string('.', dots));
            Console.WriteLine("{0}\\|/{1}", new string('.', dots), new string('.', dots));

            for (int i = 1; i <= n * 2; i++)
            {
                Console.WriteLine("{0}*{1}*{2}*{3}", new string('.', dots), new string('-', dashes), new string('-', dashes), new string('.', dots));
                dots--;
                dashes++;
            }

            Console.WriteLine("{0}", new string('*', n * 4 + 1));

            for (int i = 1; i <= n * 4 + 1; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();

            Console.WriteLine("{0}", new string('*', n * 4 + 1));
        }
    }
}
