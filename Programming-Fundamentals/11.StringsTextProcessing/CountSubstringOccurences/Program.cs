using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string pattern = Console.ReadLine().ToLower();

            int count = 0;
            int index = -1;

            while (true)
            {
                index = text.IndexOf(pattern, index + 1);

                if (index == -1)
                {
                    break;
                }

                count++;
            }

            Console.WriteLine(count);
        }
    }
}
