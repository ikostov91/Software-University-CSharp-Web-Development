using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> evenNumbers = new List<int>();

            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    evenNumbers.Add(num);
                }
            }

            List<int> newEvenNumbers = numbers.Where(x => x % 2 == 0).ToList();

            //Console.WriteLine(String.Join(" ", evenNumbers));
            //Console.WriteLine(String.Join(" ", newEvenNumbers));

            Func<string, int> csharpParser = int.Parse;
            Func<string, int> moreClear = (string text) => int.Parse(text);
            Func<string, int> lessClear = text => int.Parse(text);
            Func<int, int, int> sum = (x, y) => x + y;
            Func<string, decimal, string> pesho = (name, grade) => name + grade;
            Func<string, List<int>, string> parkash = (personName, grades) => personName + " " + grades.Average();
            Func<string, string, string> gosho = (firstName, lastName) => $"{firstName} {lastName}";

            var number = int.Parse("5");
            var fullName = gosho("Georgi","Mihalkov");
            //Console.WriteLine(fullName);

            List<int> peshoGrades = new List<int>{2, 4, 4, 6};
            //Console.WriteLine(parkash("Pesho", peshoGrades));

            Action<string> prakash = text => Console.WriteLine(text);
            //prakash("trololo");

            Action<string, string> print = (firstName, lastName) => Console.WriteLine($"{firstName} {lastName}");
            //print("Gaco", "Bacov");

            Func<string> readFromConsole = () => { return Console.ReadLine(); };

            Action<string> printToConsole = text => Console.WriteLine(text);

            string input = readFromConsole();
            printToConsole(input);
        }

        static int MyParser(string text)
        {
            return int.Parse(text);
        }
    }
}
