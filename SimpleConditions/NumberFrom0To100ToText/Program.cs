using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFrom0To100ToText
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine("zero");
            }
            else if (number == 100)
            {
                Console.WriteLine("one hundred");
            }
            else if (number > 0 && number <= 9)
            {
                if (number == 1)
                {
                    Console.WriteLine("one");
                }
                else if (number == 2)
                {
                    Console.WriteLine("two");
                }
                else if (number == 3)
                {
                    Console.WriteLine("three");
                }
                else if (number == 4)
                {
                    Console.WriteLine("four");

                }
                else if (number == 5)
                {
                    Console.WriteLine("five");
                }
                else if (number == 6)
                {
                    Console.WriteLine("six");
                }
                else if (number == 7)
                {
                    Console.WriteLine("seven");
                }
                else if (number == 8)
                {
                    Console.WriteLine("eight");
                }
                else if (number == 9)
                {
                    Console.WriteLine("nine");
                }
            }
            else if (number >= 10 && number < 20)
            {
                if (number == 10)
                {
                    Console.WriteLine("ten");
                }
                else if (number == 11)
                {
                    Console.WriteLine("eleven");
                }
                else if (number == 12)
                {
                    Console.WriteLine("twelve");
                }
                else if (number == 13)
                {
                    Console.WriteLine("thirteen");

                }
                else if (number == 14)
                {
                    Console.WriteLine("fourteen");
                }
                else if (number == 15)
                {
                    Console.WriteLine("fifteen");
                }
                else if (number == 16)
                {
                    Console.WriteLine("sixteen");
                }
                else if (number == 17)
                {
                    Console.WriteLine("seventeen");
                }
                else if (number == 18)
                {
                    Console.WriteLine("eighteen");
                }
                else if (number == 19)
                {
                    Console.WriteLine("nineteen");
                }
            }
            else if (number >= 20 && number < 100)
            {
                int firstDigit = number % 10;
                string units = string.Empty;
                if (firstDigit == 1)
                {
                    units = "one";
                }
                else if (firstDigit == 2)
                {
                    units = "two";
                }
                else if (firstDigit == 3)
                {
                    units = "three";
                }
                else if (firstDigit == 4)
                {
                    units = "four";
                }
                else if (firstDigit == 5)
                {
                    units = "five";
                }
                else if (firstDigit == 6)
                {
                    units = "six";
                }
                else if (firstDigit == 7)
                {
                    units = "seven";
                }
                else if (firstDigit == 8)
                {
                    units = "eight";
                }
                else if (firstDigit == 9)
                {
                    units = "nine";
                }

                int lastDigit = number / 10;
                string tens = string.Empty;
                if (lastDigit == 2)
                {
                    tens = "twenty";
                }
                else if (lastDigit == 3)
                {
                    tens = "thirty";
                }
                else if (lastDigit == 4)
                {
                    tens = "forty";
                }
                else if (lastDigit == 5)
                {
                    tens = "fifty";
                }
                else if (lastDigit == 6)
                {
                    tens = "sixty";
                }
                else if (lastDigit == 7)
                {
                    tens = "seventy";
                }
                else if (lastDigit == 8)
                {
                    tens = "eighty";
                }
                else if (lastDigit == 9)
                {
                    tens = "ninety";
                }

                if (units == string.Empty)
                {
                    Console.WriteLine("{0}", tens);
                }
                else
                { 
                    Console.WriteLine("{0} {1}", tens, units);
                }
            }
        }
    }
}