using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyReplaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();

            string keysInput = Console.ReadLine();
            string text = Console.ReadLine();

            string keysPattern = @"(?<start>[A-Za-z]+).*?\|(?<end>[A-Za-z]+)";
            
            string startKey = null, endKey = null;

            foreach (Match m in Regex.Matches(keysInput, keysPattern))
            {
                startKey = m.Groups["start"].Value;
                endKey = m.Groups["end"].Value;
            }

            string stringsPattern = startKey + @"(?<substring>.*?)" + endKey;

            MatchCollection matchedStrings = Regex.Matches(text, stringsPattern);

            if (matchedStrings.Count == 0)
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                foreach (Match m in matchedStrings)
                {
                    strings.Add(m.Groups["substring"].Value);
                }
            }

            Console.WriteLine(String.Join("", strings));
        }
    }
}
