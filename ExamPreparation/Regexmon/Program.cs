using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regexmon
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string bojomonPattern = @"([a-zA-Z]+)\-([a-zA-Z]+)";
            string didimonPattern = @"([^a-zA-Z\-]+)";

            string currentPattern = didimonPattern;

            while (true)
            {
                Match match = Regex.Match(input, currentPattern);

                if (match.ToString() == "")
                {
                    break;
                }

                Console.WriteLine(match.ToString());

                int index = match.Index;
                input = input.Remove(0, index);

                if (currentPattern == didimonPattern)
                {
                    currentPattern = bojomonPattern;
                }
                else
                {
                    currentPattern = didimonPattern;
                }
            }
        }
    }
}
