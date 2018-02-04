using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToList();

            Func<List<int>, int> customMin = GetMin;

            Console.WriteLine(customMin(numbers));
        }

        private static int GetMin(List<int> numbers)
        {
            int min = int.MaxValue;

            foreach (var number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }

            return min;
        }
    }
}
