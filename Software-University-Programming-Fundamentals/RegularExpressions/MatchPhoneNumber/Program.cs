﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?:^| )\+359(-| )2(\1)[0-9]{3}(\1)[0-9]{4}\b";

            MatchCollection matchedPhoneNumbers = Regex.Matches(input, pattern);

            var phoneMatches = matchedPhoneNumbers.Cast<Match>().Select(a => a.Value.Trim()).ToArray();

            Console.WriteLine(String.Join(", ", phoneMatches));
        }
    }
}