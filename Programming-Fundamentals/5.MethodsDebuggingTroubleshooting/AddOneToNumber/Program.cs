using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOneToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var val = AddOneToNumber(5);
            Console.WriteLine(val.Item1);
            Console.WriteLine(val.Item2);
        }

        static (int, int) AddOneToNumber(int n)
        {
            return (n + 1, n + 2);
        }
    }
}
