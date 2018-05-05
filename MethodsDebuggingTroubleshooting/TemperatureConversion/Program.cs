using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double fahrenheit = double.Parse(Console.ReadLine());

            double celcius = ConvertTemperature(fahrenheit);
            Console.WriteLine("{0:F2}", celcius);
        }

        static double ConvertTemperature(double fahrenheit)
        {
            double celcius = (fahrenheit - 32) * 5 / 9;

            return celcius;
        }
    }
}
