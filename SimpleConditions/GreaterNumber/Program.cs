using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterNumber
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter two integers:");
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            if (number1 > number2)
            {
                Console.WriteLine("Greater number: " + number1);
            }
            else
            {
                Console.WriteLine("Greater number: " + number2);
            }
        }
    }
}
