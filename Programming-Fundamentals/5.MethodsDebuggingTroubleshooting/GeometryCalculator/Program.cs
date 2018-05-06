using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figureType = Console.ReadLine().ToLower();

            double area = 0;

            switch (figureType)
            {
                case "triangle":
                    double sideTr = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    area = CalculateTriangleArea(sideTr, height);
                    break;
                case "square": 
                    double sideSq = double.Parse(Console.ReadLine());
                    area = CalculateSquareArea(sideSq);
                    break;
                case "rectangle": 
                    double width = double.Parse(Console.ReadLine());
                    double heightRec = double.Parse(Console.ReadLine());
                    area = CalculateRectangleArea(width, heightRec);
                    break;
                case "circle":    
                    double radius = double.Parse(Console.ReadLine());
                    area = CalculateCircleArea(radius);
                    break;
            }

            Console.WriteLine("{0:F2}", area);
        }

        static double CalculateTriangleArea(double side, double height)
        {
            double area = (side * height) / 2;
            return area;
        }

        static double CalculateSquareArea(double side)
        {
            double area = side * side;
            return area;
        }

        static double CalculateRectangleArea(double width, double height)
        {
            double area = width * height;
            return area;
        }

        static double CalculateCircleArea(double radius)
        {
            double area = Math.PI * radius * radius;
            return area;
        }
    }
}
