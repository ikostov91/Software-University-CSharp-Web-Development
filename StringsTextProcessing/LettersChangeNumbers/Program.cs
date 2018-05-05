using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0;

            foreach (var item in input)
            {
                decimal currentResult = CalculateResult(item);
                sum += currentResult;
            }

            Console.WriteLine($"{sum:F2}");
        }

        private static decimal CalculateResult(string item)
        {
            decimal result = 0;

            int number = int.Parse(item.Substring(1, item.Length - 2));

            if (item[0] >= 65 && item[0] <= 90)             // Upper Case Letters
            {
                result += (decimal)number / (item[0] - 64);
            }
            else if (item[0] >= 97 && item[0] <= 122)       // Lower Case Letters
            {
                result += (decimal)number * (item[0] - 96);
            }

            if (item[item.Length - 1] >= 65 && item[item.Length - 1] <= 90)
            {
                result -= item[item.Length - 1] - 64;
            }
            else if (item[item.Length - 1] >= 97 && item[item.Length - 1] <= 122)
            {
                result += item[item.Length - 1] - 96;
            }

            return result;
        }
    }
}
