using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankReceipt
{
    class Program
    {
        static void Main(string[] args)
        {
            //char copy = '\u00A9';
            //Console.WriteLine(copy);
            PrintReceipt();
        }

        static void PrintReceipt()
        {
            PrintHeader();
            PrintBody();
            PrintFooter();
        }

        static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------");
        }

        static void PrintBody()
        {
            Console.WriteLine("Charged to______________");
            Console.WriteLine("Received by_____________");
        }

        static void PrintFooter()
        {
            char symbol = '\u00A9';
            Console.WriteLine("------------------------");
            Console.WriteLine(symbol + " SoftUni");
        }
    }
}
