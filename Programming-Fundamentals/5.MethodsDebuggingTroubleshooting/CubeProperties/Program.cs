using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();
            double result;

            if (parameter == "face")
            {
                result = CalculateFaceDiagonal(side);
            }
            else if (parameter == "space")
            {
                result = CalculateSpaceDiagonal(side);
            }
            else if (parameter == "volume")
            {
                result = CalculateVolume(side);
            }
            else
            {
                result = CalculateArea(side);
            }

            Console.WriteLine("{0:F2}", result);
        }

        static double CalculateFaceDiagonal(double side)
        {
            double faceDiagonal = Math.Sqrt(2 * side * side);
            return faceDiagonal;
        }

        static double CalculateSpaceDiagonal(double side)
        {
            double spaceDiagonal = Math.Sqrt(3 * side * side);
            return spaceDiagonal;
        }

        static double CalculateVolume(double side)
        {
            double volume = side * side * side;
            return volume;
        }

        static double CalculateArea(double side)
        {
            double area = 6 * side * side;
            return area;
        }
    }
}
