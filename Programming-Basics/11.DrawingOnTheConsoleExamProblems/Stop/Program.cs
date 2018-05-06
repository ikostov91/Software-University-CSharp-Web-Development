using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dots = n + 1, dashes = 2 * n + 1;

            Console.WriteLine("{0}{1}{2}", new string('.', dots), new string('_', dashes), new string('.', dots));

            dashes = dashes - 2;

            for (int i = 1; i <= n; i++)
            {
                dots -= 1;

                Console.Write("{0}//{1}\\\\{2}", new string('.', dots), new string('_', dashes), new string('.', dots));

                dashes += 2;

                Console.WriteLine();
            }

            int firstMiddleLineDashes = 2 * n - 3;
            int secondMiddleLineDashes = 2 * (2 * n - 3) + 5;

            Console.WriteLine("//{0}STOP!{1}\\\\", new string('_', firstMiddleLineDashes), new string('_', firstMiddleLineDashes));
            Console.WriteLine("\\\\{0}//", new string('_', secondMiddleLineDashes));

            dots = 1;
            dashes = secondMiddleLineDashes - 2;

            for (int i = 1; i <= n - 1; i++)
            {
                Console.WriteLine("{0}\\\\{1}//{2}", new string('.', dots), new string('_', dashes), new string('.', dots));

                dots++;
                dashes -= 2;
            }
        }
    }
}

//2 * n - 1 - 2
