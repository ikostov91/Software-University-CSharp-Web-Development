using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isBoolean = Convert.ToBoolean(input);

            if (isBoolean)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
