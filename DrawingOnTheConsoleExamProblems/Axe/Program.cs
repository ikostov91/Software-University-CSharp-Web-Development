using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int handleLength = 3 * n, insideAxe = 0, outsideAxe = (handleLength + 1 + (n - 4)) / 2;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}*{1}*{2}", new string('-', handleLength), new string('-', insideAxe), new string('-', outsideAxe));

                insideAxe++;
                outsideAxe--;
            }

            insideAxe -= 1;
            outsideAxe = insideAxe;
            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}{1}*{2}", new string('*', handleLength + 1), new string('-', insideAxe), new string('-', outsideAxe));
            }

            for (int i = 1; i <= n / 2; i++)
            {
                if (i == n / 2)
                {
                    Console.WriteLine("{0}{1}{2}", new string('-', handleLength), new string('*', insideAxe + 2), new string('-', outsideAxe));
                }
                else
                {
                    Console.WriteLine("{0}*{1}*{2}", new string('-', handleLength), new string('-', insideAxe), new string('-', outsideAxe));
                }

                handleLength--;
                insideAxe += 2;
                outsideAxe--;
            }
        }
    }
}
