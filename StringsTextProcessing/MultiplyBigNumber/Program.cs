using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            string result = null;

            if (secondNumber == "0")
            {
                Console.WriteLine("0");
            }
            else
            {
                result = MultiplyBigNumber(firstNumber, secondNumber);
            }

            Console.WriteLine(result);
        }

        private static string MultiplyBigNumber(string firstNumber, string secondNumber)
        {
            string result = null;
            int currentResult = 0, digit = 0, numberInMind = 0;

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                currentResult = int.Parse(firstNumber[i].ToString()) * int.Parse(secondNumber.ToString()) + numberInMind;

                if (currentResult > 9)
                {
                    digit = currentResult % 10;
                    numberInMind = currentResult / 10;
                }
                else
                {
                    digit = currentResult;
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
