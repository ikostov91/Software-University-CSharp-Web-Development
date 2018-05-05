using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicExchangableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            string firstWord = input[0];
            string secondWord = input[1];

            CheckIfExchangable(firstWord, secondWord);
        }

        private static void CheckIfExchangable(string firstWord, string secondWord)
        {
            Dictionary<char, char> characterCouples = new Dictionary<char, char>();
            int minLength = Math.Min(firstWord.Length, secondWord.Length);

            for (int i = 0; i < minLength; i++)  
            {
                if (!characterCouples.ContainsKey(firstWord[i]))
                {
                    if (!characterCouples.ContainsValue(secondWord[i]))
                    {
                        characterCouples.Add(firstWord[i], secondWord[i]);
                    }
                    else
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }
                else if (characterCouples[firstWord[i]] != secondWord[i])
                {
                    Console.WriteLine("false");
                    return;
                }
            }

            string restOfLongerWord = null;

            if (firstWord.Length == minLength)
            {
                restOfLongerWord = firstWord.Substring(minLength);
            }
            else
            {
                restOfLongerWord = secondWord.Substring(minLength);
            }

            for (int i = 0; i < restOfLongerWord.Length; i++) 
            {
                if (!characterCouples.ContainsValue(restOfLongerWord[i]))
                {
                    Console.WriteLine("false");
                    return;
                }
            }

            Console.WriteLine("true");
            return;
        }
    }
}
