using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dataSets = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, Dictionary<string, long>> cache = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "thetinggoesskrra")
                {
                    break;
                }

                string[] data = input.Split(new string[] {" -> "," | "}, StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 1)
                {
                    if (!dataSets.ContainsKey(data[0]))
                    {
                        dataSets.Add(data[0], new Dictionary<string, long>());
                    }

                    foreach (var set in cache)
                    {
                        if (dataSets.ContainsKey(set.Key))
                        {
                            foreach (var keySize in cache[set.Key])
                            {
                                dataSets[set.Key].Add(keySize.Key, keySize.Value);
                            }
                        }
                    }
                    continue;
                }

                string dataKey = data[0];
                string dataSet = data[2];
                long dataSize = long.Parse(data[1]);

                if (!dataSets.ContainsKey(dataSet))
                {
                    if (!cache.ContainsKey(dataSet))
                    {
                        cache.Add(dataSet, new Dictionary<string, long>());
                        cache[dataSet].Add(dataKey, dataSize);
                    }
                    else
                    {
                        cache[dataSet].Add(dataKey, dataSize);
                    }
                }
                else
                {
                    dataSets[dataSet].Add(dataKey, dataSize);
                }
            }

            foreach (var keyValuePair in dataSets.OrderByDescending(x => x.Value.Sum(y => y.Value)).Take(1))
            {
                Console.WriteLine($"Data Set: {keyValuePair.Key}, Total Size: {keyValuePair.Value.Sum(s => s.Value)}");

                foreach (var value in keyValuePair.Value)
                {
                    Console.WriteLine($"$.{value.Key}");
                }
            }
        }
    }
}
