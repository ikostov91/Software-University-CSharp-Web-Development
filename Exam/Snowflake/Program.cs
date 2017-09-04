using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowFlake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int outsideDots = 0, insideDots = n;

            for (int i = 1; i <= n; i++)
            {
                if (i == n)
                {
                    Console.WriteLine("{0}*****{1}", new string('.', outsideDots), new string('.', outsideDots));
                }
                else
                {
                    Console.WriteLine("{0}*{1}*{2}*{3}", new string('.', outsideDots), new string('.', insideDots),
                                                         new string('.', insideDots), new string('.', outsideDots));
                }
                outsideDots++;
                insideDots--;
            }

            outsideDots -= 1;
            insideDots += 1;

            Console.WriteLine("{0}", new string('*', 2 * n + 3));

            for (int i = 1; i <= n; i++)
            {
                if (i == 1)
                {
                    Console.WriteLine("{0}*****{1}", new string('.', outsideDots), new string('.', outsideDots));
                }
                else
                {
                    Console.WriteLine("{0}*{1}*{2}*{3}", new string('.', outsideDots), new string('.', insideDots),
                                                         new string('.', insideDots), new string('.', outsideDots));
                }
                outsideDots--;
                insideDots++;
            }
        }
    }
}
