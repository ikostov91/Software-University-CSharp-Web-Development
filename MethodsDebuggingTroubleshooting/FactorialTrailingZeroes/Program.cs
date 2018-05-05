using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = CalculateFactorial(n);
            int trailingZeroes = CalculateTrailingZeroes(factorial);
            Console.WriteLine(trailingZeroes);
        }

        static BigInteger CalculateFactorial(int n)
        {
            BigInteger fact = 1;

            for (int i = 2; i <= n; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        static int CalculateTrailingZeroes(BigInteger factorial)
        {
            string numberStr = factorial.ToString();
            char[] numberArray = numberStr.ToCharArray();

            int count = 0;

            for (int i = numberArray.Length - 1; i >= 0; i--)
            {
                if (numberArray[i] == '0')
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }
    }
}
