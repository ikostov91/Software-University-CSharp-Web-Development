using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int magicNumber = int.Parse(Console.ReadLine());

            for (int n1 = 1; n1 < 10; n1++)
            {
                for (int n2 = 0; n2 < 10; n2++)
                {
                    for (int n3 = 0; n3 < 10; n3++)
                    {
                        for (int n4 = 0; n4 < 10; n4++)
                        {
                            for (int n5 = 0; n5 < 10; n5++)
                            {
                                for (int n6 = 0; n6 < 10; n6++)
                                {
                                    int number = n1 * n2 * n3 * n4 * n5 * n6;

                                    if (number == magicNumber)
                                    {
                                        Console.Write("{0}{1}{2}{3}{4}{5} ", n1, n2, n3, n4, n5, n6);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
