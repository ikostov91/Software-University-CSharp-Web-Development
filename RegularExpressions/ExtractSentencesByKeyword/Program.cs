using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyword = Console.ReadLine();
            string[] input = Console.ReadLine().Split(new char[] {'!','.','?'}, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"\b" + keyword + @"\b";

            foreach (var sentence in input)
            {
                if (Regex.IsMatch(sentence, pattern))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
