using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = new List<int>();

            string[] input = Console.ReadLine().Split('|').ToArray();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int[] numbers = (input[i])
                                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                for (int j = 0; j < numbers.Length; j++)
                {
                    result.Add(numbers[j]);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
