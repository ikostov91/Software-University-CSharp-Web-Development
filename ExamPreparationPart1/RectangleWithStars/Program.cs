using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleWithStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int middleRows = 0;

            Console.WriteLine(new string('%', n * 2));

            if (n % 2 == 0)
            {
                middleRows = n - 1;
            }
            else
            {
                middleRows = n;
            }

            for (int i = 1; i <= middleRows; i++)
            {
                if (n < 3)
                {
                    Console.WriteLine("%**%");
                }
                else if (i == Math.Ceiling(n / 2.0))
                {
                    Console.WriteLine("%{0}**{1}%", new string(' ',(n * 2 - 4) / 2), new string(' ', (n * 2 - 4) / 2));
                }
                else
                {
                    Console.WriteLine("%{0}%", new string(' ', n * 2 - 2));
                }
            }

            Console.WriteLine(new string('%', n * 2));
        }
    }
}
