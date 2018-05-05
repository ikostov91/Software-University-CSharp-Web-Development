using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double nextPairSum = 0, previousPairSum = 0;

            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double maxDifference = 0;
            previousPairSum = firstNumber + secondNumber;

            for (int i = 0; i < n - 1; i++)
            {
                double number = double.Parse(Console.ReadLine());
                double number2 = double.Parse(Console.ReadLine());
                nextPairSum = number + number2;

                if (nextPairSum == previousPairSum)
                {
                    continue;
                }
                else
                {
                    double difference = Math.Abs(nextPairSum - previousPairSum);
                    if (difference > maxDifference)
                    {
                        maxDifference = difference;
                    }
                }

                previousPairSum = nextPairSum;
            }

            if (maxDifference == 0)
            {
                Console.WriteLine("Yes,value = {0}", previousPairSum);
            }
            else
            {
                Console.WriteLine("No,maxdiff = {0}", maxDifference);
            }
        }
    }
}
