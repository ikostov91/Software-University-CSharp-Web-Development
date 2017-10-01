using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCharsStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = "Software University";
            char second = 'B';
            char third = (char)121;
            char fourth = '\u0065';
            string fifth = "I love programming";

            Console.WriteLine($"{first}\n{second}\n{third}\n{fourth}\n{fifth}");
        }
    }
}
