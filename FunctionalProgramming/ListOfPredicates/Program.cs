using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimit = int.Parse(Console.ReadLine());

            List<int> divisors = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            Queue<int> result = new Queue<int>();

            var predicates = divisors.Select(divisor => (Func<int, bool>) (n => n % divisor == 0)).ToArray();  

            for (int i = 1; i <= upperLimit; i++)
            {
                if (isValid(predicates, i))
                {
                    result.Enqueue(i);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }

        private static bool isValid(Func<int, bool>[] predicates, int number)
        {
            foreach (var predicate in predicates)
            {
                if (!predicate(number))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
