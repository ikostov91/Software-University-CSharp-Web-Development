using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            //string input = Console.ReadLine();
            string[] input = File.ReadAllLines("input.txt");

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == "stop")
                {
                    break;
                }

                if (i % 2 == 0)
                {
                    string resource = File.ReadLines
                }
            }
            while (input != "stop")
            {
               

                if (resources.ContainsKey(input))
                {
                    resources[input] += quantity;
                }
                else
                {
                    resources.Add(input, quantity);
                }

                
            }

            ListResources(resources);
        }

        private static void ListResources(Dictionary<string, int> resources)
        {
            foreach (KeyValuePair<string, int> resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            };
        }
    }
}