using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] instructions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> result = new List<int>();

            for (int i = 0; i < instructions[0]; i++)
            {
                result.Add(numbers[i]);
            }

            for (int i = 0; i < instructions[1]; i++)
            {
                result.RemoveAt(0);
            }

            if (result.Contains(instructions[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
