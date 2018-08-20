using System;
using System.Collections.Generic;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> isUpperCase = word => Char.IsUpper(word[0]);

            List<string> upperCaseWords = text.Where(isUpperCase).ToList();

            Console.WriteLine(String.Join(Environment.NewLine, upperCaseWords));
        }
    }
}
