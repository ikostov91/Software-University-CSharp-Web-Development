using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char last = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());

            int combinationCount = 0;

            for (char i = first; i <= last; i++)
            {
                for (char j = first; j <= last; j++)
                {
                    for (char k = first; k <= last; k++)
                    {
                        if (k == skip || j == skip || i == skip)
                        {
                            continue;
                        }
                        else
                        {
                            Console.Write("{0}{1}{2} ", i, j, k);
                            combinationCount++;
                        }
                    }
                }
            }
            Console.WriteLine(combinationCount);
        }
    }
}
