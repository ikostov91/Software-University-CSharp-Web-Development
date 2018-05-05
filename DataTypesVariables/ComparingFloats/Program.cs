using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingFloats
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            const double eps = 0.000001;
            bool areEqual = Math.Abs(a - b) <= eps;

            Console.WriteLine(areEqual);
        }
    }
}
