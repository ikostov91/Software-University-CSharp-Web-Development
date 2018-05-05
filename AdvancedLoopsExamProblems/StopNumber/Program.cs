using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowestNumber = int.Parse(Console.ReadLine());
            int highestNumber = int.Parse(Console.ReadLine());
            int stopNumber = int.Parse(Console.ReadLine());

            for (int i = highestNumber; i >= lowestNumber; i--)
            {
                if (i % 2 == 0 && i % 3 == 0)
                {
                    if (i == stopNumber)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
