using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<chars>[^0-9]*)(?<count>[0-9]+)";

            StringBuilder result = new StringBuilder();

            List<char> charactersList = new List<char>();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string charsInMatch = match.Groups["chars"].ToString().ToUpper();
                int count = int.Parse(match.Groups["count"].ToString());

                char[] charArray = charsInMatch.ToCharArray();

                foreach (var item in charArray)
                {
                    charactersList.Add(item);
                }

                for (int i = 0; i < count; i++)
                {
                    result.Append(charsInMatch);
                }
            }

            charactersList = charactersList.Distinct().ToList();

            Console.WriteLine($"Unique symbols used: {charactersList.Count}");
            Console.WriteLine(result);
        }
    }
}
