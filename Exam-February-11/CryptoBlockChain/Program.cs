using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace CryptoBlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string blockChain = String.Empty;

            for (int i = 0; i < rows; i++)
            {
                string currentLine = Console.ReadLine();
                blockChain += currentLine;
            }

            string pattern = @"\{[^0-9]*(?<numbers>[0-9]{3,})[^0-9]*\}|\[[^0-9]*(?<numbers>[0-9]{3,})[^0-9]*\]";

            MatchCollection matches = Regex.Matches(blockChain, pattern);
            string result = "";

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Groups["numbers"].Length % 3 != 0)
                    {
                        continue;
                    }

                    string numbersSequence = match.Groups["numbers"].ToString();

                    for (int i = 0; i < numbersSequence.Length; i += 3)
                    {
                        string currentNumber = "";
                        for (int j = i; j < i + 3; j++)
                        {
                            currentNumber += numbersSequence[j];
                        }
                        int character = int.Parse(currentNumber) - match.Length;

                        result += (char)character;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
