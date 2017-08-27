using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int firstDigit = 0, secondDigit   = 0, thirdDigit = 0;
            int rows       = 0, numbersPerRow = 0;

            int temp = number, counter = 0;

            while (temp != 0)
            {
                counter++;
                int digit = temp % 10;
                temp /= 10;
                if (counter == 1)
                {
                    thirdDigit = digit;
                }
                else if (counter == 2)
                {
                    secondDigit = digit;
                }
                else
                {
                    firstDigit = digit;
                }
            }

            rows = firstDigit + secondDigit;
            numbersPerRow = firstDigit + thirdDigit;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= numbersPerRow; j++)
                {
                    if (number % 5 == 0)
                    {
                        number -= firstDigit;
                    }
                    else if (number % 3 == 0)
                    {
                        number -= secondDigit;
                    }
                    else
                    {
                        number += thirdDigit;
                    }
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
