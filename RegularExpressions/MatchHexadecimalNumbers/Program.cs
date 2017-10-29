using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\b(0x)?([A-F0-9]+)\b";

            MatchCollection matchedHexes = Regex.Matches(input, pattern);

            var matches = matchedHexes.Cast<Match>().Select(a => a.Value).ToArray();

            Console.WriteLine(String.Join(" ", matches));
        }
    }
}
