using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesToKilometres
{
    class Program
    {
        static void Main(string[] args)
        {
            double miles = double.Parse(Console.ReadLine());

            double kilometres = miles * 1.60934;

            Console.WriteLine(Math.Round(kilometres, 2));
        }
    }
}
