using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;

            while (true)
            {
                number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    break;
                }

                Console.WriteLine("The number is not even.");
            }

            Console.WriteLine("Even number entered: {0}", number);
        }
    }
}
