using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, int>> users = new SortedDictionary<string, SortedDictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] log = input.Split(new char[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string user = log[5];
                string ipAddress = log[1];
                int counter = 1;

                if (users.ContainsKey(user))
                {
                    if (users[user].ContainsKey(ipAddress))
                    {
                        users[user][ipAddress] += 1;
                    }
                    else
                    {
                        users[user].Add(ipAddress, counter);
                    }
                }
                else
                {
                    users.Add(user, new SortedDictionary<string, int>());
                    users[user].Add(ipAddress, 1);
                }

                input = Console.ReadLine();
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}:");

                List<string> items = new List<string>();

                foreach (var ip in user.Value)
                {
                    var text = $"{ip.Key} => {ip.Value}";
                    items.Add(text);
                }

                Console.WriteLine($"{String.Join(", ",items)}.");
            }
        }
    }
}
