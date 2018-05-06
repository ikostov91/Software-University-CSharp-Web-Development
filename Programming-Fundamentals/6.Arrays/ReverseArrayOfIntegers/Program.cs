using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n], arrayReversed = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                arrayReversed[i] = array[n - i - 1];
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(arrayReversed[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
