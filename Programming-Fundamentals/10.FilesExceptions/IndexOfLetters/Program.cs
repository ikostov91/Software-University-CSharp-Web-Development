using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] word = File.ReadAllText("input.txt").ToCharArray();

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (word[i] == alphabet[j])
                    {
                        File.AppendAllText("output.txt", $"{word[i]} -> {j}" + Environment.NewLine);
                    }
                }
            }
        }
    }
}