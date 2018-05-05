using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            DetonateNumbers(numbers, bomb);
            int sum = SumElements(numbers);

            Console.WriteLine(sum);
        }

        private static int SumElements(List<int> numbers)
        {
            return numbers.Sum(x => Convert.ToInt32(x));
        }

        private static void DetonateNumbers(List<int> numbers, int[] bomb)
        {
            int bombNumber = bomb[0];
            int range = bomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    numbers.RemoveRange(i - range, 2 * range + 1);
                }
            }
        }
    }
}
