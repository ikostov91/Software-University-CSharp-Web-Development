using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = @"http://softuni.bg/forum/4371/exam-problem-02-letters-change-numbers
                         https://github.com/ikostov91
                         423423423434242
                         httpdadsa//www.nakow.com
                         http://alabala.com/trololo";

            var pattern = @"(\w+)\:\/\/([a-z0-9._-]+)(.*)";

            Regex.Matches(text, pattern);

            foreach (Match m in Regex.Matches(text, pattern))
            {
                Console.WriteLine("URL found: " + m);
                Console.WriteLine("Protocol: " + m.Groups[1]);
                Console.WriteLine("Host: " + m.Groups[2]);
                Console.WriteLine("Resource: " + m.Groups[3]);
            }
        }
    }
}
