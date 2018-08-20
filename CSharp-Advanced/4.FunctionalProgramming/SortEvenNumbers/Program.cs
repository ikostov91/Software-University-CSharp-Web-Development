using System;
using System.Collections.Generic;
using System.Linq;

namespace SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToList();

            Func<int, bool> isEven = number => number % 2 == 0;

            var sortedEvenNumber = numbers.Where(isEven).OrderBy(n => n).ToList();

            Console.WriteLine(String.Join(", ", sortedEvenNumber));
        }
    }
}
