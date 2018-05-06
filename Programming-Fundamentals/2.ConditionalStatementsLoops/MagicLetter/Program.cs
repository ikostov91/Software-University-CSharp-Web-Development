using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char last = char.Parse(Console.ReadLine());
            char skip = char.Parse(Console.ReadLine());

            for (int i = first; i <= last; i++)
            {
                for (int j = first; j <= last; j++)
                {
                    for (int k = first; k <= last; k++)
                    {
                        if (i == skip || j == skip || k == skip)
                        {
                            continue;
                        }
                        else
                        {
                            Console.Write("{0}{1}{2} ", (char)i,(char)j,(char)k);
                        }
                    }
                }
            }
        }
    }
}
