using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameOfLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Last test in Judge - wrond result

            long number = long.Parse(Console.ReadLine());

            var lastDigitName = GetNameOfLastDigit(number);
            Console.WriteLine(lastDigitName);
        }

        static string GetNameOfLastDigit(long number)
        { 
            long digit = number % 10;
            string name = string.Empty;
            switch (digit)
            {
                case 0: name = "zero"; break;
                case 1: name = "one"; break;
                case 2: name = "two"; break;
                case 3: name = "three"; break;
                case 4: name = "four"; break;
                case 5: name = "five"; break;
                case 6: name = "six"; break;
                case 7: name = "seven"; break;
                case 8: name = "eigth"; break;
                case 9: name = "nine"; break;
            }

            return name;
        }
    }
}
