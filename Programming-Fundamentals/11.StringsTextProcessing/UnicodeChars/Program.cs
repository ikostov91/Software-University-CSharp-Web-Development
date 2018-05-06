using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            foreach (var character in input)
            {
                result.Append("\\u" + ((int)character).ToString("x4"));
            }

            Console.WriteLine(result);
        }
    }
}
