using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnonymouseVox
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] placeholders = Console.ReadLine().Split(new char[] { '}', '{' }, StringSplitOptions.RemoveEmptyEntries);

            string pattern = @"(?<start>[A-Za-z]+)(?<placeholder>.+)(?<end>\1)";
            int index = 0;

            string result = string.Empty;
            
            Regex rgx = new Regex(pattern);
            
            while (input != string.Empty)
            {
                Match match = rgx.Match(input);

                string currentInput = input;
                int length = match.Index + match.ToString().Length;

                currentInput = currentInput.Remove(match.Groups["placeholder"].Index, match.Groups["placeholder"].ToString().Length);
                currentInput = currentInput.Insert(match.Groups["placeholder"].Index, placeholders[index]);
                result = result + currentInput.Substring(0, match.Groups["start"].Index + match.Groups["start"].Length + placeholders[index].Length + match.Groups["end"].Length);
                index += 1;
                input = input.Remove(0, length);
            }

            Console.WriteLine(result);
        }
    }
}
