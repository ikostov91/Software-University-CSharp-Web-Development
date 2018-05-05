using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWebsites = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            List<string> websites = new List<string>();
            decimal totalLoss = 0;

            for (int i = 1; i <= numberOfWebsites; i++)
            {
                string[] currentWebsite = Console.ReadLine().Split(' ');
                string website = currentWebsite[0];
                long siteVisits = long.Parse(currentWebsite[1]);
                decimal pricePerVisit = decimal.Parse(currentWebsite[2]);
                websites.Add(website);

                decimal currentSiteLoss = siteVisits * pricePerVisit;
                totalLoss += currentSiteLoss;
            }

            //double securityToken = Math.Pow(securityKey, websites.Count);
            double securityToken = GetPower(securityKey, websites.Count);
            PrintWebsites(websites);

            Console.WriteLine($"Total Loss: {totalLoss:F20}");
            Console.WriteLine($"Security Token: {securityToken}");
        }

        private static void PrintWebsites(List<string> websites)
        {
            foreach (var site in websites)
            {
                Console.WriteLine($"{site}");
            }
        }
        private static ulong GetPower(int x, int y)
        {
            ulong result = 1;

            for (int i = 1; i <= y; i++)
            {
                result *= (ulong)x;
            }

            return result;
        }

    }
}
