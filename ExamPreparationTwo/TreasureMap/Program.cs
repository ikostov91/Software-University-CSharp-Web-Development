using System;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace TreasureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string pattern = @"(#[^#!]*?(?<![A-Za-z0-9])(?<streetName>[a-zA-Z]{4})(?![A-Za-z0-9])[^#!]*?(?<!\d)(?<streetNumber>[0-9]{3})-(?<password>[0-9]{4}|[0-9]{6})(?!\d)[^#!0-9]*?!)|(![^#!]*?(?<![A-Za-z0-9])(?<streetName>[a-zA-Z]{4})(?![A-Za-z0-9])[^#!]*?(?<!\d)(?<streetNumber>[0-9]{3})-(?<password>[0-9]{4}|[0-9]{6})(?!\d)[^#!0-9]*?#)";

            for (int counter = 0; counter < numberOfInputs; counter++)
            {
                string currentInput = Console.ReadLine();

                MatchCollection matches = Regex.Matches(currentInput, pattern);

                Match match;

                if (matches.Count > 0)
                {
                    if (matches.Count % 2 == 0)
                    {
                        match = matches[matches.Count / 2];
                    }
                    else
                    {
                        int index = matches.Count / 2;
                        match = matches[index];
                    }
                }
                else
                {
                    continue;
                }

                string addressName = match.Groups["streetName"].ToString();
                string streetNumber = match.Groups["streetNumber"].ToString();
                string password = match.Groups["password"].ToString();

                Console.WriteLine($"Go to str. {addressName} {streetNumber}. Secret pass: {password}.");
            }
            
        }
    }
}
