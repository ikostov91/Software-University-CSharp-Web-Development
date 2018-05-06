using System;
using System.Collections.Generic;
using System.Linq;

namespace FIndEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lowerLimit = range[0];
            int upperLimit = range[1];

            string evenOdd = Console.ReadLine();

            Predicate<int> predicate;

            switch (evenOdd)
            {
                case "odd":
                    predicate = n => n % 2 != 0;
                    break;
                case "even":
                    predicate = n => n % 2 == 0;
                    break;
                default:
                    predicate = null;
                    break;
            }

            Queue<int> filteredNumbers = GetNumbers(lowerLimit, upperLimit, predicate);

            Console.WriteLine(String.Join(" ", filteredNumbers));
        }

        private static Queue<int> GetNumbers(int lowerLimit, int upperLimit, Predicate<int> predicate)
        {
            Queue<int> filteredNumbers = new Queue<int>();

            for (int i = lowerLimit; i <= upperLimit; i++)
            {
                if (predicate(i))
                {
                    filteredNumbers.Enqueue(i);
                }
            }

            return filteredNumbers;
        }
    }
}
