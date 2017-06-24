using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelsiusToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            var tempC = double.Parse(Console.ReadLine());
            var tempF = tempC * (9 / 5.0) + 32;
            Console.WriteLine(Math.Round(tempF, 2));
        }
    }
}
