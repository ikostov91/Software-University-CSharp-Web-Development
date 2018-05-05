using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine();
            if (figureType == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double area = side * side;
                Console.WriteLine("{0:F3}",area);
            }
            else if (figureType == "rectangle")
            {
                double firstSide = double.Parse(Console.ReadLine());
                double secondSide = double.Parse(Console.ReadLine());
                double area = firstSide * secondSide;
                Console.WriteLine("{0:F3}", area);
            }
            else if (figureType == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = Math.PI * radius * radius;
                Console.WriteLine("{0:F3}", area);
            }
            else if (figureType == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = (side * height) / 2;
                Console.WriteLine("{0:F3}", area);
            }
        }
    }
}
