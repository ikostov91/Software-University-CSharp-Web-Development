using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                int firstOccurence = input.IndexOf(pattern);
                int lastOccurrence = input.LastIndexOf(pattern);

                if (firstOccurence == -1 || lastOccurrence == -1 || firstOccurence == lastOccurrence || pattern == string.Empty)
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    break;
                }
                else
                {
                    Console.WriteLine("Shaked it.");
                    input = input.Remove(lastOccurrence, pattern.Length);
                    input = input.Remove(firstOccurence, pattern.Length);

                    // Remove at index equal to the pattern’s length / 2. 
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                }                
            }
        }
    }
}
