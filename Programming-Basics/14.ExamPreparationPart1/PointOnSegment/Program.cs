using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOnSegment
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int point = int.Parse(Console.ReadLine());

            int x2 = Math.Max(first,second);
            int x1 = Math.Min(first, second);

            if (point >= x1 && point <= x2)
            {
                Console.WriteLine("in");

                Console.WriteLine("{0}", Math.Min(x2 - point,point - x1));
            }
            else
            {
                Console.WriteLine("out");

                if (point > x2)
                {
                    Console.WriteLine("{0}", point - x2);
                }
                else
                {
                    Console.WriteLine("{0}", x1 - point);
                }
            }
        }
    }
}
