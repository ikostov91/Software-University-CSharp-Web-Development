using System;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStrings; i++)
            {
                string value = Console.ReadLine();
                var box = new Box<string>(value);
                Console.WriteLine(box);
            }
        }
    }
}
