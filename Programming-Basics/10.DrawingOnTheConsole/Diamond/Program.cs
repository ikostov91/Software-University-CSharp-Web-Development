using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int outerSpaces = 0, innerSpaces = 0,
                upperPart   = 0, lowerPart   = 0;
            bool even = true;

            if (n % 2 != 0)
            {
                even = false;
            }

            if (even)
            {
                outerSpaces = (n - 2) / 2;
                upperPart = n / 2;
                lowerPart = n - upperPart - 1;
            }
            else
            {
                outerSpaces = (n - 1) / 2;
                upperPart = (upperPart + 1) / 2;
                lowerPart = n - upperPart;
            }

            for (int i = 0; i < upperPart; i++)
            {
                Console.WriteLine(new string('-', outerSpaces) + '*' + new string('-', innerSpaces) + '*' + new string('-', outerSpaces));
                outerSpaces--;
                innerSpaces += 2;
            }

            //Console.WriteLine("outerSPaces = {0}", outerSpaces);
            //Console.WriteLine("inner spaces = {0}", innerSpaces);
            outerSpaces = 1;
            if (n > 3)
            { 
                innerSpaces = n - 4;
            }
            else
            {
                innerSpaces = 0;
            }

            for (int i = 0; i < lowerPart; i++)
            {         
                Console.WriteLine(new string('-', outerSpaces) + '*' + new string('-', innerSpaces) + '*' + new string('-', outerSpaces));
                outerSpaces++;
                innerSpaces -= 2;            
            }
        }
    }
}
