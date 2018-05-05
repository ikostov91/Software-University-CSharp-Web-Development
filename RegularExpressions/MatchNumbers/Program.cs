using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?:^|(?<=\s))-?[0-9]+(\.[0-9]+)?($|(?=\s))";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match number in matches)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
