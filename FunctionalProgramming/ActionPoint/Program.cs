using System;
using System.Linq;

namespace ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                               .ToArray();

            Action<string> printOnConsole = name => Console.WriteLine(name);

            foreach (var name in names)
            {
                printOnConsole(name);
            }
        }
    }
}
