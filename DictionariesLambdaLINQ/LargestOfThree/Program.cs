using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestThree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> result = new List<int>(numbers.OrderByDescending(x => x).Take(3));

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
