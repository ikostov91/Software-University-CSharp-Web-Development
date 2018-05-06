using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitRemoveEmptyEntries
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            double sum = 0;

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
                sum += items[i];
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
