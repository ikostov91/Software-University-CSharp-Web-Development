using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //int[] numberOccurences = new int[65535];

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    numberOccurences[numbers[i]] += 1;
            //}

            int currentCount = 0;
            int bestCount = 0;
            int leftMost = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (numbers[j] == numbers[i])
                    {
                        currentCount += 1;
                        if (currentCount > bestCount)
                        {
                            bestCount = currentCount;
                            leftMost = numbers[i];
                        }
                    }
                }

                currentCount = 1;
            }

            Console.WriteLine(leftMost);
        }
    }
}
