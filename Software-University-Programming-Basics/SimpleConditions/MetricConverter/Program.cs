using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricConverter
{
    class Program
    {
        static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            string sourceMetric = Console.ReadLine().ToLower();
            string destMetric = Console.ReadLine().ToLower();
            if (sourceMetric == "cm")
            {
                length /= 100;
            }
            else if (sourceMetric == "mi")
            {
                length /= 0.000621371192;
            }
            else if (sourceMetric == "in")
            {
                length /= 39.3700787;
            }
            else if (sourceMetric == "km")
            {
                length *= 1000;
            }
            else if (sourceMetric == "ft")
            {
                length /= 3.2808399;
            }
            else if (sourceMetric == "mm")
            {
                length /= 1000;
            }
            else if (sourceMetric == "m")
            {
                length /= 1;
            }
            else if (sourceMetric == "yd")
            {
                length /= 1.0936133;
            }

            if (destMetric == "m")
            {
                length /= 1;
            }
            else if (destMetric == "mm")
            {
                length *= 1000;
            }
            else if (destMetric == "cm")
            {
                length *= 100;
            }
            else if (destMetric == "mi")
            {
                length *= 0.000621371192;
            }
            else if (destMetric == "in")
            {
                length *= 39.3700787;
            }
            else if (destMetric == "km")
            {
                length /= 1000;
            }
            else if (destMetric == "ft")
            {
                length *= 3.2808399;
            }
            else if (destMetric == "yd")
            {
                length *= 1.0936133;
            }
            Console.WriteLine(length);
        }
    }
}
