using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            int vowelsSum = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a')
                {
                    vowelsSum += 1;
                }
                else if (text[i] == 'e')
                {
                    vowelsSum += 2;
                }
                else if (text[i] == 'i')
                {
                    vowelsSum += 3;
                }
                else if (text[i] == 'o')
                {
                    vowelsSum += 4;
                }
                else if (text[i] == 'u')
                {
                    vowelsSum += 5;
                }
            }
            Console.WriteLine(vowelsSum);
        }
    }
}
