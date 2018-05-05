using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTriangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            double triangleBase = double.Parse(Console.ReadLine());
            double triangleHeight = double.Parse(Console.ReadLine());

            double triangleArea = CalculateArea(triangleBase, triangleHeight);
            Console.WriteLine(triangleArea);
        }

        static double CalculateArea(double triangleBase, double triangleHeight)
        {
            double area = (triangleBase * triangleHeight) / 2;

            return area;
        }
    }
}
