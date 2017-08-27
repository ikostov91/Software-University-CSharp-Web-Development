using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());

            int    side = 0, height = 0;
            double area = 0;

            side = Math.Abs(x2 - x3);
            Console.WriteLine(side);
            height = Math.Abs(y1 - y2);
            Console.WriteLine(height);

            area = (double)(side * height) / 2;

            Console.WriteLine(area);
        }
    }
}
