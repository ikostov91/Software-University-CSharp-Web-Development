using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if (((x >= 2 && x <= 12) && (y >= -3 && y <= 1)) || ((x >= 4 && x <= 10) && (y >= -5 && y <= 3)))
            {
                Console.WriteLine("in");
            }
            else
            {
                Console.WriteLine("out");
            }

            //Alternative solution: Two bools for the two rectangles equal to conditions in the above "if"
        }
    }
}
