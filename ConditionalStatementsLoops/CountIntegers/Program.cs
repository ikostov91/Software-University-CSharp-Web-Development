using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = 0;

            while (true)
            {
                var input = Console.ReadLine();

                int number;

                bool isInt = Int32.TryParse(input, out number);

                if (isInt == false)
                { 
                    break;
                }

                numbersCount++;
            }

            Console.WriteLine(numbersCount);
        }
    }
}
