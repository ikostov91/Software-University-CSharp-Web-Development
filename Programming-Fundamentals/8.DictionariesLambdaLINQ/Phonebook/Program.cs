using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] instruction = input.Split(' ').ToArray();

                if (instruction[0] == "A")
                {
                    if (phonebook.ContainsKey(instruction[1]))
                    {
                        phonebook[instruction[1]] = instruction[2];
                    }
                    else
                    {
                        phonebook.Add(instruction[1], instruction[2]);
                    }
                }

                if (instruction[0] == "S")
                {
                    if (phonebook.ContainsKey(instruction[1]))
                    {
                        Console.WriteLine($"{instruction[1]} -> {phonebook[instruction[1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {instruction[1]} does not exist.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
