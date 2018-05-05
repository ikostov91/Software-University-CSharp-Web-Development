using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            CalculatePrintFactorial(n);
        }

        static void CalculatePrintFactorial(int n)
        {
            BigInteger fact = 1;

            for (int i = 2; i <= n; i++)
            {
                fact = fact * i;
            }

            Console.WriteLine(fact);
        }
    }
}
