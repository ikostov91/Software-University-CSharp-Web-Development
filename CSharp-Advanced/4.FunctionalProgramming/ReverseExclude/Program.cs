using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            int divisor = int.Parse(Console.ReadLine());
            Func<int, bool> isDivisible = x => x % divisor != 0;

            var newCollection = numbers.Reverse().Where(isDivisible);

            Console.WriteLine(String.Join(" ", newCollection));
        }
    }
}
