using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordInPlural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string pluralWord = string.Empty;

            if (word.EndsWith("y"))
            {
                pluralWord = word.Remove(word.Length - 1) + "ies";
                //word.Remove(integer) - position of the letter in the string
            }
            else if (word.EndsWith("o") || word.EndsWith("ch") || word.EndsWith("s") || word.EndsWith("sh") || word.EndsWith("x") || word.EndsWith("z"))
            {
                pluralWord = word + "es";
            }
            else
            {
                pluralWord = word + "s";
            }

            Console.WriteLine(pluralWord);
        }
    }
}
