using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedyTimesTrainerSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());

            string[] itemsInput = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, long> goldBag = new Dictionary<string, long>();
            long goldQuantity = 0;
            Dictionary<string, long> gemBag = new Dictionary<string, long>();
            long gemQuantity = 0;
            Dictionary<string, long> cashBag = new Dictionary<string, long>();
            long cashQuantity = 0;

            for (int i = 0; i < itemsInput.Length; i+=2)
            {
                string itemName = itemsInput[i];
                int itemAmmount = int.Parse(itemsInput[i + 1]);

                string itemType = GetItemType(itemName);

                bool canInsertItem = CanPutItemInBag(itemType, itemAmmount, bagCapacity, goldQuantity, gemQuantity, cashQuantity);

                if (itemType == "Invalid" || !canInsertItem)
                {
                    continue;
                }

                switch (itemType)
                {
                    case "Gold":
                        InsertItem(goldBag, itemName, itemAmmount);
                        goldQuantity += itemAmmount;
                        break;
                    case "Gem":
                        InsertItem(gemBag, itemName, itemAmmount);
                        gemQuantity += itemAmmount;
                        break;
                    case "Cash":
                        InsertItem(cashBag, itemName, itemAmmount);
                        cashQuantity += itemAmmount;
                        break;
                }
            }

            if (goldBag.Any())
            {
                Console.WriteLine(PrintBag(goldBag, "Gold", goldQuantity));
                if (gemBag.Any())
                {
                    Console.WriteLine(PrintBag(gemBag, "Gem", gemQuantity));
                    if (cashBag.Any())
                    {
                        Console.WriteLine(PrintBag(cashBag, "Cash", cashQuantity));
                    }
                }
            }
        }

        private static string PrintBag(Dictionary<string, long> bag, string type, long totalAmmount)
        {
            var resultBuilder = new StringBuilder();

            resultBuilder.AppendLine($"<{type}> ${totalAmmount}");

            var orderedBag = bag.OrderByDescending(x => x.Key).ThenBy(y => y.Value);

            foreach (var item in orderedBag)
            {
                resultBuilder.AppendLine($"##{item.Key} - {item.Value}");
            }

            string result = resultBuilder.ToString().Trim();

            return result;
        }

        private static void InsertItem(Dictionary<string, long> bag, string itemName, int itemAmmount)
        {
            if (!bag.ContainsKey(itemName))
            {
                bag[itemName] = 0;
            }
            bag[itemName] += itemAmmount;
        }

        private static bool CanPutItemInBag(string itemType, int itemAmmount, long bagCapacity, long goldQuantity, long gemQuantity, long cashQuantity)
        {
            long bagOccupied = goldQuantity + gemQuantity + cashQuantity;

            if (bagCapacity < bagOccupied + itemAmmount)
            {
                return false;
            }

            switch (itemType)
            {
                case "Gold":
                    return true;
                case "Gem":
                    gemQuantity += itemAmmount;
                    return gemQuantity <= goldQuantity;
                case "Cash":
                    cashQuantity += itemAmmount;
                    return cashQuantity <= gemQuantity;
            }

            return false;
        }

        private static string GetItemType(string itemName)
        {
            if (itemName.Length == 3)
            {
                return "Cash";
            }

            if (itemName.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }

            if (itemName.ToLower() == "gold")
            {
                return "Gold";
            }

            return "Invalid";
        }
    }
}
