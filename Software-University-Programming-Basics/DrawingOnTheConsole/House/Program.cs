using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int stars = 0, spaces = 0;
            double upperPart = 0, lowerPart = 0;
            bool even = true;
            if (n % 2 != 0)
            {
                even = false;
            }

            if (even) 
            {
                spaces = (n - 2) / 2;  
                stars = 2;            
            }
            else
            {
                spaces = (n - 1) / 2;
                stars = 1;
            }

            upperPart = Math.Ceiling((double)n / 2);

            for (int i = 0; i < upperPart; i++)
            {
                Console.WriteLine(new string('-', spaces) + new string('*', stars) + new string('-', spaces));
                spaces--;
                stars += 2;
            }

            lowerPart = Math.Floor((double)n / 2);

            for (int i = 0; i < lowerPart; i++)
            {
                Console.WriteLine(new string('|', 1) + new string('*', (n - 2)) + new string('|', 1));
            }
        }
    }
}
