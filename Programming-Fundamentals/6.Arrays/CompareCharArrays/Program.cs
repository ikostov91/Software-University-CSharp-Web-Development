using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] first = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] second = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            bool firstArray = false, secondArray = false;

            for (int i = 0; i < Math.Min(first.Length, second.Length); i++)
            {
                if (first[i] < second[i])
                {
                    firstArray = true;
                    break;
                }
                else if (second[i] < first[i])
                {
                    secondArray = true;
                    break;
                }
                else
                {
                    continue;
                }
            }

            if (firstArray == false && secondArray == false)
            {
                if (first.Length < second.Length)
                {
                    PrintArray(first);
                    PrintArray(second);
                }
                else
                {
                    PrintArray(second);
                    PrintArray(first);
                }
            }
            else
            {
                if (firstArray == true)
                {
                    PrintArray(first);
                    PrintArray(second);
                }
                else
                {
                    PrintArray(second);
                    PrintArray(first);
                }
            }
        }

        private static void PrintArray(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }
    }
}
