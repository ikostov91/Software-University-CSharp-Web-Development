using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Some tests in Judge fail - Wrong result

            double firstX1 = double.Parse(Console.ReadLine());
            double firstY1 = double.Parse(Console.ReadLine());
            double firstX2 = double.Parse(Console.ReadLine());
            double firstY2 = double.Parse(Console.ReadLine());
            double secondX1 = double.Parse(Console.ReadLine());
            double secondY1 = double.Parse(Console.ReadLine());
            double secondX2 = double.Parse(Console.ReadLine());
            double secondY2 = double.Parse(Console.ReadLine());

            double firstLineLength = CalculateLine(firstX1, firstY1, firstX2, firstY2);
            double secondLineLength = CalculateLine(secondX1, secondY1, secondX2, secondY2);

            if (secondLineLength > firstLineLength)
            {
                double closest = GetClosesToCenter(secondX1, secondY1, secondX2, secondY2);
                if (closest == firstX2)
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", secondX2, secondY2, secondX1, secondY1);
                }
                else
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", secondX1, secondY1, secondX2, secondY2);
                }
            }
            else
            {
                double closest = GetClosesToCenter(firstX1, firstY1, firstX2, firstY2);
                if (closest == firstX2)
                {
                    Console.WriteLine("({0}{1})({2}{3})", firstX2, firstY2, firstX1, firstY1);
                }
                else
                {
                    Console.WriteLine("({0}{1})({2}{3})", firstX1, firstY1, firstX2, firstY2);
                }
            }
        }

        static double CalculateLine(double x1, double y1, double x2, double y2)
        {
            double sideOne = Math.Abs(x1 - x2);
            double sideTwo = Math.Abs(y1 - y2);
            double lineLength = Math.Sqrt(sideOne * sideOne + sideTwo * sideTwo);
            return lineLength;
        }

        static double GetClosesToCenter(double x1, double y1, double x2, double y2)
        {
            double pointOneDistance = Math.Sqrt(x1 * x1 + y1 * y1);
            double pointTwoDistance = Math.Sqrt(x2 * x2 + y2 * y2);

            if (pointTwoDistance < pointOneDistance)
            {
                return x2;
            }
            else
            {
                return x1;
            }
        }
    }
}
