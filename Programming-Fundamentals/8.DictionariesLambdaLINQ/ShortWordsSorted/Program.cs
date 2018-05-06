using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console
                .ReadLine()
                .ToLower()
                .Split('.', ',', ':', ';', '(', ')', '[', ']', '&', '"', '\'', '\\', '/', '!', '?', ' ')
                .Where(word => word.Length < 5 && word.Length >= 1)
                .OrderBy(word => word)
                .Distinct()
                .ToList();

            Console.WriteLine(String.Join(", ", input));
        }
    }
}
