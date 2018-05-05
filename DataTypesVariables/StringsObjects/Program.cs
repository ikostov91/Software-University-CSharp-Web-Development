using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPart = "Hello";
            string secondPart = "World";

            Object greeting = firstPart + " " + secondPart;

            string finalGreeting = (string)greeting;

            Console.WriteLine(finalGreeting);
        }
    }
}
