using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sideParts = n / 2, middlePart = 2 * n - 2 * sideParts - 4;

            Console.WriteLine("/{0}\\{1}/{2}\\", new string('^', sideParts), new string('_', middlePart), new string('^', sideParts));

            for (int i = 1; i <= n - 2; i++)
            {
                if (i == n - 2)
                {
                    Console.WriteLine("|{0}{1}{2}|", new string(' ', n / 2 + 1), new string('_', middlePart), new string(' ', n / 2 + 1));
                }
                else
                {
                    Console.WriteLine("|{0}|", new string(' ', 2 * n - 2));
                }                
            }

            Console.WriteLine("\\{0}/{1}\\{2}/", new string('_', sideParts), new string(' ', middlePart), new string('_', sideParts));
        }
    }
}
