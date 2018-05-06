using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBase10BaseN
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            BigInteger convertTo = BigInteger.Parse(input[0]);
            BigInteger originalNumber = BigInteger.Parse(input[1]);

            string result = null;

            while (originalNumber != 0)
            {
                BigInteger remainder = originalNumber % convertTo;
                originalNumber = originalNumber / convertTo;
                result = remainder.ToString() + result;
            }

            Console.WriteLine(result);

            // Algorithm
            // num stores a value in base 10
            // solution will have digits in an array
            //index = 0;
            //while (num != 0)
            //{
            //    remainder = num % K;  // assume K > 1
            //    num = num / K;  // integer division
            //    digit[index] = remainder;
            //    index++;
            //}
        }
    }
}
