using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, string> ModifyName = name => "Sir " + name;
            Action<string> printName = name => Console.WriteLine(name);

            List<string> modifiedNames = names.Select(ModifyName).ToList();

            foreach (var name in modifiedNames)
            {
                printName(name);
            }
        }
    }
}
