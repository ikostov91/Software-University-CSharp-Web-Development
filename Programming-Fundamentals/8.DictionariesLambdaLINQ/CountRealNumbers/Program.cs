using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> numbersCount = new SortedDictionary<double, int>();

            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbersCount.ContainsKey(numbers[i]))
                {
                    numbersCount[numbers[i]] += 1;
                }
                else
                {
                    numbersCount.Add(numbers[i], 1);
                }
            }

            foreach (var number in numbersCount)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
