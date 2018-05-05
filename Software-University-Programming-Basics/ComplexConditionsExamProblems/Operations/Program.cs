using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal number1 = decimal.Parse(Console.ReadLine());
            decimal number2 = decimal.Parse(Console.ReadLine());
            char action = char.Parse(Console.ReadLine());
            decimal result = 0.00M;
            string evenOdd = string.Empty;

            if (number2 == 0 && (action == '/' || action == '%'))
            {
                Console.WriteLine("Cannot divide {0} by zero", number1);
            }
            else
            {
                switch (action)
                {
                    case '+':
                        result = number1 + number2;
                        if (result % 2 == 0)
                        {
                            evenOdd = "even";
                        }
                        else
                        {
                            evenOdd = "odd";
                        }
                        Console.WriteLine("{0} + {1} = {2} - {3}", number1, number2, result, evenOdd);
                        break;

                    case '-':
                        result = number1 - number2;
                        if (result % 2 == 0)
                        {
                            evenOdd = "even";
                        }
                        else
                        {
                            evenOdd = "odd";
                        }
                        Console.WriteLine("{0} - {1} = {2} - {3}", number1, number2, result, evenOdd);
                        break;

                    case '*':
                        result = number1 * number2;
                        if (result % 2 == 0)
                        {
                            evenOdd = "even";
                        }
                        else
                        {
                            evenOdd = "odd";
                        }
                        Console.WriteLine("{0} * {1} = {2} - {3}", number1, number2, result, evenOdd);
                        break;

                    case '/':
                            result = number1 / number2;
                            Console.WriteLine("{0} / {1} = {2:f2}", number1, number2, result);
                        break;

                    case '%':
                            result = number1 % number2;
                            Console.WriteLine("{0} % {1} = {2}", number1, number2, result);       
                        break;
                }
            }
            
        }
    }
}
