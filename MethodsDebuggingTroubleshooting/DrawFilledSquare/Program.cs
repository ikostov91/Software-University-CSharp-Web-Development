using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFilledSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintRow(n);
            PrintMiddleRow(n);
            PrintRow(n);
        }

        static void PrintRow(int number)
        {
            Console.WriteLine(new string('-', number * 2));
        }

        static void PrintMiddleRow(int number)
        {
            for (int i = 1; i <= number - 2; i++)
            {
                Console.Write('-');
                for (int j = 1; j < number; j++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine('-');
            }
        }
    }
}
