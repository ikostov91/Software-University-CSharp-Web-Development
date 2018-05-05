using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Circle firstCircle = new Circle();
            firstCircle.X = input[0];
            firstCircle.Y = input[1];
            firstCircle.Radius = input[2];

            input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Circle secondCircle = new Circle();
            secondCircle.X = input[0];
            secondCircle.Y = input[1];
            secondCircle.Radius = input[2];

            bool CheckIfCirclesIntersect = Intersect(firstCircle, secondCircle);

            if (CheckIfCirclesIntersect)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static bool Intersect(Circle c1, Circle c2)
        {
            double distanceBetweenCenters = CalculateDistance(c1.X, c1.Y, c2.X, c2.Y);

            if (distanceBetweenCenters <= (c1.Radius + c2.Radius))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double side1 = Math.Abs(y2 - y1);
            double side2 = Math.Abs(x2 - x1);
            double distance = Math.Sqrt(side1 * side1 + side2 * side2);

            return distance;
        }
    }

    public class Circle
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }
    }
}
