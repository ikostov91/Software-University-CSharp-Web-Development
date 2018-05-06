using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int currentLength = 1;
            int bestLength = 1;
            int currentStart = 0;
            int bestStart = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    currentLength += 1;

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestStart = currentStart;
                    }
                }
                else
                {
                    currentLength = 1;
                    currentStart = i;
                }
            }

            PrintLongestSequence(numbers, bestStart, bestLength);
        }

        private static void PrintLongestSequence(int[] numbers, int bestStart, int bestLength)
        {
            for (int i = bestStart; i < bestStart + bestLength; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

