using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumReversedNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers[i];
                int left = number;
                int reversed = 0;
                while (left > 0)
                {
                    int remainder = left % 10;
                    reversed = reversed * 10 + remainder;
                    left /= 10;
                }

                numbers[i] = reversed;
            }

            SumReversedNumbers(numbers);
        }

        private static void SumReversedNumbers(List<int> numbers)
        {
            Console.WriteLine(numbers.Sum());
        }
    }
}
