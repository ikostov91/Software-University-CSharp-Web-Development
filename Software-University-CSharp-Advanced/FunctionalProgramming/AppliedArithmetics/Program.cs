using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToList();

            Action<List<int>> print = list => Console.WriteLine(String.Join(" ", list));
            //Func<int, int> add = number => number + 1;
            //Func<int, int> multiply = number => number * 2;
            //Func<int, int> subtract = number => number - 1;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        numbers = ForEach(numbers, n => n + 1);
                        break;
                    case "multiply":
                        numbers = ForEach(numbers, n => n * 2);
                        break;
                    case "subtract":
                        numbers = ForEach(numbers, n => n - 1);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }

        private static List<int> ForEach(List<int> numbers, Func<int, int> func)
        {
            return numbers.Select(n => func(n)).ToList();
        }
    }
}
