using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, bool> isNameValid = text => text.Length <= nameLength;

            PrintNames(names, n => n.Length <= nameLength);
        }

        private static void PrintNames(List<string> names, Func<string, bool> Filter)
        {
            Console.WriteLine(String.Join(Environment.NewLine, names.Where(n => Filter(n))));
        }
    }
}
