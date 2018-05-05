using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetInfoIndex = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> hitList = new Dictionary<string, Dictionary<string, string>>();

            string input = Console.ReadLine();

            while (input != "end transmissions")
            {
                string[] currentLine =
                    input.Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = currentLine[0];

                if (!hitList.ContainsKey(name))
                {
                    hitList.Add(name, new Dictionary<string, string>());
                }

                for (int i = 1; i < currentLine.Length; i++)
                {
                    string[] keyValue = currentLine[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string key = keyValue[0];
                    string value = keyValue[1];

                    if (!hitList[name].ContainsKey(key))
                    {
                        hitList[name].Add(key, value);
                    }
                    else
                    {
                        hitList[name][key] = value;
                    }
                }

                input = Console.ReadLine();
            }

            string[] killCommand = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, string> targetInfo = hitList[killCommand[1]];

            Console.WriteLine($"Info on {killCommand[1]}:");
            int infoIndex = 0;

            foreach (var keyValuePair in targetInfo.OrderBy(y => y.Key))
            {
                Console.WriteLine($"---{keyValuePair.Key}: {keyValuePair.Value}");
                infoIndex += keyValuePair.Key.Length + keyValuePair.Value.Length;
            }

            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
