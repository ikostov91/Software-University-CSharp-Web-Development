using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            //  [\[]([^' '\[]+)<(?<firstNumber>[0-9]+)REGEH(?<secondNumber>[0-9]+)>([^' '\]]+)[\]]
            string pattern = @"\[[a-zA-Z]+<([0-9]+)REGEH([0-9]+)>[a-zA-Z]+\]";

            MatchCollection matches = Regex.Matches(input, pattern);

            List<int> indexes = new List<int>();

            foreach (Match match in matches)
            {
                int firstIndex = int.Parse(match.Groups[1].Value);
                indexes.Add(firstIndex);
                int secondIndex = int.Parse(match.Groups[2].Value);
                indexes.Add(secondIndex);
            }

            string result = "";
            int position = 0;

            foreach (var index in indexes)
            {
                int totalIndexSum = 0;

                for (int i = 0; i < position; i++)
                {
                    totalIndexSum += indexes[i];
                }

                totalIndexSum += index;

                result = result + GetCharacter(input, totalIndexSum);

                position++;
            }

            Console.WriteLine(result);
        }

        private static char GetCharacter(string input, int totalIndexSum)
        {
            if (totalIndexSum >= input.Length)
            {
                while (totalIndexSum >= input.Length)
                {
                    totalIndexSum -= input.Length - 1;
                }

                return input[totalIndexSum];
            }

            return input[totalIndexSum];
        }
    }
}
