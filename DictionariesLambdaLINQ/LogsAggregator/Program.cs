using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, int>> usersLog = new SortedDictionary<string, SortedDictionary<string, int>>();

            int logs = int.Parse(Console.ReadLine());

            for (int i = 1; i <= logs; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();

                string user = input[1];
                string ip = input[0];
                int duration = int.Parse(input[2]);

                if (usersLog.ContainsKey(user))
                {
                    if (usersLog[user].ContainsKey(ip))
                    {
                        usersLog[user][ip] += duration;
                    }
                    else
                    {
                        usersLog[user].Add(ip, duration);
                    }
                }
                else
                {
                    usersLog.Add(user, new SortedDictionary<string, int>());
                    usersLog[user].Add(ip, duration);
                }
            }

            foreach (var user in usersLog)
            {
                Console.Write($"{user.Key}: {user.Value.Sum(x => x.Value)} ");

                List<string> ipAddresses = new List<string>();

                foreach (var ip in user.Value)
                {
                    ipAddresses.Add(ip.Key);
                }

                Console.WriteLine($"[{String.Join(", ", ipAddresses)}]");
            }
        }
    }
}
