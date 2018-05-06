using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            bool result = isPrime(number);
            Console.WriteLine(result);
        }

        static bool isPrime(long number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
