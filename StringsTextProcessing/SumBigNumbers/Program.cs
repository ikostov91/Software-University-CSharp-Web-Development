
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            int maxLength = Math.Max(firstNumber.Length, secondNumber.Length);

            firstNumber = firstNumber.PadLeft(maxLength, '0');
            secondNumber = secondNumber.PadLeft(maxLength, '0');

            string result = SumBigNumbers(firstNumber, secondNumber);

            Console.WriteLine(result);
        }

        private static string SumBigNumbers(string firstNumber, string secondNumber)
        {
            string result = null;
            int sum = 0, digit = 0, numberInMind = 0;

            for (int i = secondNumber.Length - 1; i >= 0; i--)
            {
                sum  = int.Parse(firstNumber[i].ToString()) + int.Parse(secondNumber[i].ToString()) + numberInMind;

                if (sum > 9)
                {
                    digit = sum % 10;
                    numberInMind = sum / 10;
                }
                else
                {
                    digit = sum;
                    numberInMind = 0;
                }

                result = digit + result;

                if (i == 0 && numberInMind != 0)
                {
                    result = numberInMind + result;
                }
            }

            return result.TrimStart('0');
        }
    }
}
