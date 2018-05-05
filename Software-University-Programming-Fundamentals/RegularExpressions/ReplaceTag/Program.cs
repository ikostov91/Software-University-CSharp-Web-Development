using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReplaceTag
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();

            string input = Console.ReadLine();

            while (input != "end")
            {
                text.Append(input);

                input = Console.ReadLine();
            }

            string pattern = @"<a(.*?)>(.*?)<\/a>";
            string fromSB = text.ToString();

            Regex regex = new Regex(pattern);
            string result = regex.Replace(fromSB, m => "[URL" + m.Groups[1] + "]" + m.Groups[2] + "[/URL]");

            Console.WriteLine(result);
        }
    }
}
