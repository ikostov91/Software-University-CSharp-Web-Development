using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentSequence = 0, maxSequence = 0, previousNumber = 0;

            for (int i = 0; i < n; i++)
            {
                int nextNumber = int.Parse(Console.ReadLine());

                if (nextNumber > previousNumber)
                {
                    currentSequence++;

                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                    }
                }
                else
                {
                    currentSequence = 1;
                }

                previousNumber = nextNumber;
            }
            Console.WriteLine(maxSequence);
        }
    }
}
