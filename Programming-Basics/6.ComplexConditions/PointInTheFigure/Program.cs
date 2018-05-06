using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInTheFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if ((x > 0 && x < 3 * h) && (y > 0 && y < h))
            {
                Console.WriteLine("inside");
            }
            else if ((x > h && x < 2 * h) && (y > h && y < 4 * h))
            {
                Console.WriteLine("inside");
            }
            else if ((x > h && x < 2 * h) && y == h)
            {
                Console.WriteLine("inside");
            }
            else if (y == 0 && (x >= 0 && x <= 3 * h)) 
            {
                Console.WriteLine("border");
            }
            else if (((x >= 0 && x <= h) || (x >= 2 * h && x <= 3 * h)) && y == h)
            {
                Console.WriteLine("border");
            }
            else if ((x >= h && x <= 2 * h) && (y == 4 * h))
            {
                Console.WriteLine("border");
            }
            else if ((x == h || x == 2 * h) && (y >= h && y <= 4 * h))
            {
                Console.WriteLine("border");
            }
            else if ((x == 0 || x == 3 * h) && (y >= 0 && y <= h))
            {
                Console.WriteLine("border");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}
