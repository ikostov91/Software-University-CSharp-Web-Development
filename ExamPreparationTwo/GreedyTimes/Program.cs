using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace GreedyTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger bagCapacity = BigInteger.Parse(Console.ReadLine());

            BigInteger totalGoldAmmount = 0;
            BigInteger totalGemAmmount = 0;
            BigInteger totalCashAmmount = 0;

            Dictionary<string, long> gemsAmmount = new Dictionary<string, long>();
            Dictionary<string, long> cashAmmount = new Dictionary<string, long>();

            string[] items = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None).ToArray();

            for (int i = 0; i < items.Length; i+=2)
            {
                string key = "";

                string itemType = items[i];
                int itemAmmount = int.Parse(items[i + 1]);

                if (itemType.Length == 3)
                {
                    key = "Cash";
                    totalCashAmmount += itemAmmount;
 
                }
                else if (itemType.ToLower().EndsWith("gem"))
                {
                    key = "Gem";
                    totalGemAmmount += itemAmmount;
                }
                else if (itemType.ToLower() == "gold")
                {
                    totalGoldAmmount += itemAmmount;
                }
                else
                {
                    continue;
                }

                if (totalGoldAmmount >= totalGemAmmount && totalGemAmmount >= totalCashAmmount)
                {
                    BigInteger totalAllAmmount = totalGoldAmmount + totalGemAmmount + totalCashAmmount;

                    if (totalAllAmmount > bagCapacity)
                    {
                        if (key == "Gold")
                        {
                            totalGoldAmmount -= itemAmmount;
                        }
                        break;
                    }

                    switch (key)
                    {
                        case "Gem":
                            if (!gemsAmmount.ContainsKey(itemType))
                            {
                                gemsAmmount.Add(itemType, itemAmmount);
                            }
                            else
                            {
                                gemsAmmount[itemType] += itemAmmount;
                            }
                            break;
                        case "Cash":
                            if (!cashAmmount.ContainsKey(itemType))
                            {
                                cashAmmount.Add(itemType, itemAmmount);
                            }
                            else
                            {
                                cashAmmount[itemType] += itemAmmount;
                            }
                            break;
                    }
                }
            }

            if (totalGoldAmmount >= (BigInteger)gemsAmmount.Values.Sum() && (BigInteger)gemsAmmount.Values.Sum() >= (BigInteger)cashAmmount.Values.Sum())
            {
                PrintBagContents(totalGoldAmmount, gemsAmmount, cashAmmount);
            }
            
        }

        private static void PrintBagContents(BigInteger gold, Dictionary<string,long> gems, Dictionary<string,long> cash)
        {
            Console.WriteLine($"<Gold> ${gold}");
            Console.WriteLine($"##Gold - {gold}");

            if (gems.Any())
            {
                BigInteger gemsTotal = gems.Values.Sum();
                Console.WriteLine($"<Gem> ${gemsTotal}");
                foreach (var gem in gems.OrderByDescending(x => x.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{gem.Key} - {gem.Value}");
                }
            }

            if (cash.Any())
            {
                BigInteger cashTotal = cash.Values.Sum();
                Console.WriteLine($"<Cash> ${cashTotal}");
                foreach (var cashItem in cash.OrderByDescending(x => x.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{cashItem.Key} - {cashItem.Value}");
                }
            }
            
        }
    }
}
