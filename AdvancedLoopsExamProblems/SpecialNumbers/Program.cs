using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int currentNumber = 0;

            for (int i = 1111; i <= 9999; i++)
            {
                currentNumber = i;

                bool isSpecial = true;

                while (currentNumber != 0)
                {
                    int currentDigit = currentNumber % 10;
                    currentNumber /= 10;

                    if (currentDigit == 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    else if (number % currentDigit != 0)
                    {
                        isSpecial = false;
                    }
                }

                if (isSpecial == true)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
