using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            string firstString = input[0];
            string secondString = input[1];

            int result = GetSumOfCodes(firstString, secondString);

            Console.WriteLine(result);
        }

        private static int GetSumOfCodes(string firstString, string secondString)
        {
            int sum = 0;
            int minLength = Math.Min(firstString.Length, secondString.Length);
            int maxLength = Math.Max(firstString.Length, secondString.Length);

            for (int i = 0; i < minLength; i++)
            {
                sum += (int)firstString[i] * (int)secondString[i];
            }

            if (firstString.Length == minLength)
            {
                for (int i = minLength; i < secondString.Length; i++)
                {
                    sum += (int)secondString[i];
                }
            }
            else
            {
                for (int i = minLength; i < firstString.Length; i++)
                {
                    sum += (int)firstString[i];
                }
            }

            return sum;
        }
    }
}
