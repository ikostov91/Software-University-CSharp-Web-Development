using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letters = new char[3];

            for (int i = 0; i < letters.Length; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                letters[i] = letter;
            }

            char[] reversedLetters = new char[3];

            for (int i = 0; i < reversedLetters.Length; i++)
            {
                reversedLetters[i] = letters[letters.Length - i - 1];
                Console.Write(reversedLetters[i]);
            }
            Console.WriteLine();
        }
    }
}
