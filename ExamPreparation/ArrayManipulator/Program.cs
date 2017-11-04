using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input.Split(' ');
                int index;
                int count;
                string evenOdd = string.Empty;
                int[] result;

                switch (command[0])
                {
                    case "exchange":
                        index = int.Parse(command[1]);

                        if (index < 0 || index >= array.Length)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }

                        array = ExchangeSubArrays(array, index);
                        break;
                    case "max":
                        evenOdd = command[1];
                        PrintMaxOddEvenIndex(array, evenOdd);
                        break;
                    case "min":
                        evenOdd = command[1];
                        PrintMinOddEvenIndex(array, evenOdd);
                        break;
                    case "first":
                        evenOdd = command[2];
                        count = int.Parse(command[1]);

                        if (count > array.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        result = PrintFirstEvenOddElements(array, count, evenOdd);
                        Console.WriteLine($"[{String.Join(", ", result)}]");

                        break;

                    case "last":
                        evenOdd = command[2];
                        count = int.Parse(command[1]);

                        if (count > array.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        result = PrintLastEvenOddElements(array, count, evenOdd);
                        Console.WriteLine($"[{String.Join(", ", result)}]");
                        break;
                }
            }

            Console.WriteLine($"[{String.Join(", ", array)}]");
        }

        private static int[] PrintLastEvenOddElements(int[] array, int count, string evenOdd)
        {

            if (evenOdd == "even")
            {
                return array.Where(x => x % 2 == 0).Reverse().Take(count).Reverse().ToArray();
            }
            else
            {
                return array.Where(x => x % 2 != 0).Reverse().Take(count).Reverse().ToArray();
            }

        }

        private static int[] PrintFirstEvenOddElements(int[] array, int count, string evenOdd)
        {

            if (evenOdd == "even")
            {
                 return array.Where(x => x % 2 == 0).Take(count).ToArray();
            }
            else
            {
                return array.Where(x => x % 2 != 0).Take(count).ToArray();
            }

        }

        private static void PrintMinOddEvenIndex(int[] array, string evenOdd)
        {
            int index = -1, minElement = int.MaxValue;

            if (evenOdd == "even")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0 && array[i] < minElement)
                    {
                        minElement = array[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 != 0 && array[i] < minElement)
                    {
                        minElement = array[i];
                        index = i;
                    }
                }
            }

            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static void PrintMaxOddEvenIndex(int[] array, string evenOdd)
        {
            int index = -1, maxElement = int.MinValue;

            if (evenOdd == "even")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0 && array[i] > maxElement)
                    {
                        maxElement = array[i];
                        index = i;
                    }
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 != 0 && array[i] > maxElement)
                    {
                        maxElement = array[i];
                        index = i;
                    }
                }
            }

            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        private static int[] ExchangeSubArrays(int[] array, int index)
        {
            int[] firstSubArray = array.Take(index + 1).ToArray();
            int[] secondSubArray = array.Skip(index + 1).ToArray();

            return secondSubArray.Concat(firstSubArray).ToArray();
        }
    }
}
