using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();

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

            File.WriteAllText("output.txt", leftMost.ToString());
        }
    }
}