using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistaneBetweenPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            Point firstPoint = ReadPoint();
            Point secondPoint = ReadPoint();

            double result = GetEuclideanDistance(firstPoint, secondPoint);

            Console.WriteLine($"{result:F3}");
        }

        static Point ReadPoint()
        {
            double[] pointCoordinates = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Point point = new Point
            {
                X = pointCoordinates[0],
                Y = pointCoordinates[1]
            };

            return point;
        }

        static double GetEuclideanDistance(Point firstPoint, Point secondPoint)
        {
            double euclDist = Math.Sqrt(Math.Pow((firstPoint.X - secondPoint.X),2) + Math.Pow((firstPoint.Y - secondPoint.Y),2));

            return euclDist;
        }
    }
}
