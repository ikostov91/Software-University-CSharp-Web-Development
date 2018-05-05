using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitStringByEmptyChar
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Select(c => "" + c).Select(int.Parse).ToArray();

            // var nums = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            // string input = Console.ReadLine();
            // var items = intput.Select(c => "" + c);
            // var nums = items.Select(int.Parse);
            // var numbers = nums.ToArray();

            Console.WriteLine(String.Join(", ", numbers));
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
