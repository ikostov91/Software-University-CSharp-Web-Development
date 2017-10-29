using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\b[a-z0-9]+(?:[.\-_][a-z]+)*@[a-z]+(?:[.\-_][a-z]+)*\b";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match email in matches)
            {
                Console.WriteLine(email);
            }
        }
    }
}
