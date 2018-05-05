using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleArea
{
    class Program
    {
        static void Main()
        {
            var x = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var area = x * height / 2;
            Console.WriteLine("Triangle area = " + Math.Round(area, 2));
        }
    }
}
