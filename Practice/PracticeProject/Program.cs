using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstX1 = double.Parse(Console.ReadLine());
            double firstY1 = double.Parse(Console.ReadLine());
            double firstX2 = double.Parse(Console.ReadLine());
            double firstY2 = double.Parse(Console.ReadLine());

            double secondX1 = double.Parse(Console.ReadLine());
            double secondY1 = double.Parse(Console.ReadLine());
            double secondX2 = double.Parse(Console.ReadLine());
            double secondY2 = double.Parse(Console.ReadLine());

            double firstLineLength = CalculateLength(firstX1, firstY1, firstX2, firstY2);
            double secondLineLength = CalculateLength(secondX1, secondY1, secondX2, secondY2);

            if (secondLineLength > firstLineLength)
            {
                double closestPoint = GetClosestPoint(secondX1, secondY1, secondX2, secondY2);

                if (closestPoint == secondX1)
                {
                    PrintLineCoordinates(secondX1, secondY1, secondX2, secondY2);
                }
                else
                {
                    PrintLineCoordinates(secondX2, secondY2, secondX1, secondY1);
                }
            }
            else
            {
                double closestPoint = GetClosestPoint(firstX1, firstY1, firstX2, firstY2);

                if (closestPoint == firstX1)
                {
                    PrintLineCoordinates(firstX1, firstY1, firstX2, firstY2);
                }
                else
                {
                    PrintLineCoordinates(firstX2, firstY2, firstX1, firstY1);
                }
            }
        }

        private static void PrintLineCoordinates(double X1, double Y1, double X2, double Y2)
        {
            Console.WriteLine($"({X1}, {Y1})({X2}, {Y2})");
        }

        private static double CalculateLength(double X1, double Y1, double X2, double Y2)
        {
            double sideOne = Math.Abs(X1 - X2);
            double sideTwo = Math.Abs(Y1 - Y2);
            double length = Math.Sqrt(Math.Pow(sideOne, 2) + Math.Pow(sideTwo, 2));

            return length;
        }

        static double GetClosestPoint(double x1, double y1, double x2, double y2)
        {
            double firstPointDistance = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double secondPointDistance = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));

            if (secondPointDistance < firstPointDistance)
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
