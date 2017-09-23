using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int last = int.Parse(Console.ReadLine());

            for (int i = Math.Min(first, last); i <= Math.Max(first, last); i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
