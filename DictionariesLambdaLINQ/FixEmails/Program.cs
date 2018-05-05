using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> accounts = new Dictionary<string, string>();

            string name = Console.ReadLine();

            while (name != "stop")
            {
                string email = Console.ReadLine();

                string ending = email.Substring(email.Length - 2, 2).ToLower();

                if (ending != "us" && ending != "uk")
                {
                    accounts.Add(name, email);
                }

                name = Console.ReadLine();
            }

            ListAllAccounts(accounts);
        }

        private static void ListAllAccounts(Dictionary<string, string> accounts)
        {
            foreach (KeyValuePair<string, string> item in accounts)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
