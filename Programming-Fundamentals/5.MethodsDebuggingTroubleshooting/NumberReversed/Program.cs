using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberReversed
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double reversedNumber = ReverseNumber(number);
            Console.WriteLine(reversedNumber);
        }

        static double ReverseNumber(double number)
        {
            string numberStr = new string(number.ToString().Reverse().ToArray());
            double reversedNmb = double.Parse(numberStr);
            return reversedNmb;
        }
    }
}
