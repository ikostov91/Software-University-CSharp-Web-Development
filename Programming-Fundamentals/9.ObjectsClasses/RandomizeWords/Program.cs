using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            Random rnd = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int first = rnd.Next(0, input.Length);
                int second = rnd.Next(0, input.Length);

                string change = input[first];
                input[first] = input[second];
                input[second] = change;
            }

            Console.WriteLine(String.Join("\n", input));
        }
    }
}
