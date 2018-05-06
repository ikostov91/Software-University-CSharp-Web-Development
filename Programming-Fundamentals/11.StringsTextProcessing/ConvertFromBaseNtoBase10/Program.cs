using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBaseNtoBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            int[] originalNumber = input[1].Select(c => "" + c).Select(int.Parse).ToArray();
            int convertFrom = int.Parse(input[0]);

            BigInteger result = new BigInteger(0);

            for (int i = 0; i < originalNumber.Length; i++)
            {
                BigInteger currentResult = originalNumber[i] * BigInteger.Pow(convertFrom, originalNumber.Length - i - 1);
                result += currentResult;
            }

            Console.WriteLine(result.ToString());
        }
    }
}
