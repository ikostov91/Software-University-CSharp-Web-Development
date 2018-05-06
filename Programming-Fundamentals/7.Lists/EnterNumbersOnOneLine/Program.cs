using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbersOnOneLine
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            // List<int> numbers = new List<int>();
            // string inputLine = Console.ReadLine();
            // while (inputLine != "exit")
            // {
            //    int number = int.Parse(inputLine);
            //    numbers.Add(number);
            //    inputLine = Console.ReadLine();
            // }

            numbers.Add(100);

            // .Remove doesn't throw an exception if there is no such element in the list.
            // When there are multiple elements, it removes the first element it finds.
            // Ex.: Remove(20) = {10, 20, 30, 20} -> {10, 30, 20},   {10, 30, 40} -> {10, 30, 40}
            
            numbers.Remove(20);
            Console.WriteLine(numbers.Count);
            Console.WriteLine(String.Join(", ", numbers));
        }
    }
}
