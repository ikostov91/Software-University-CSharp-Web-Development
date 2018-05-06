using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> occurrences = new Dictionary<string, int>();

            List<string> input = Console.ReadLine().ToLower().Split(' ').ToList();
            List<string> result = new List<string>();

            for (int i = 0; i < input.Count; i++)
            {
                if (occurrences.ContainsKey(input[i]))
                {
                    occurrences[input[i]] += 1;
                }
                else
                {
                    occurrences.Add(input[i], 1);
                }
            }

            foreach (var word in occurrences)
            {
                if (word.Value % 2 != 0)
                {
                    result.Add(word.Key);
                }
            }

            Console.WriteLine(String.Join(", ", result));
        }
    }
}
