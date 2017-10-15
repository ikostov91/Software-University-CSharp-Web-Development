using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> score = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "JOKER")
            {
                string[] playerCards = input.Split(':').ToArray();
                string name = playerCards[0];

                List<string> cardsDrawn = playerCards[1].Split(',')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();

                cardsDrawn = cardsDrawn.Distinct().ToList();

                if (score.ContainsKey(name))
                {
                    foreach (var card in cardsDrawn)
                    {
                        if (score[name].Contains(card))
                        {
                            continue;
                        }
                        else
                        {
                            score[name].Add(card);
                        }
                    }
                }
                else
                {
                    score.Add(name, cardsDrawn);
                }

                input = Console.ReadLine();
            }

            ListScore(score);
        }

        private static void ListScore(Dictionary<string, List<string>> score)
        {
            foreach (KeyValuePair<string, List<string>> item in score)
            {
                int playerScore = CalculateScore(item.Value);

                Console.WriteLine($"{item.Key}: {playerScore}");
            }
        }

        private static int CalculateScore(List<string> cards)
        {
            int score = 0;

            foreach (var card in cards)
            {
                int power = 0, type = 0;

                string multiplierType = card.Substring(card.Length - 1, 1);
                string cardPower;

                if (card.Length == 3)
                {
                    cardPower = card.Substring(0, 2);
                }
                else
                {
                    cardPower = card.Substring(0, 1)
;
                }

                switch (cardPower)
                {
                    case "1": power = 1; break;
                    case "2": power = 2; break;
                    case "3": power = 3; break;
                    case "4": power = 4; break;
                    case "5": power = 5; break;
                    case "6": power = 6; break;
                    case "7": power = 7; break;
                    case "8": power = 8; break;
                    case "9": power = 9; break;
                    case "10": power = 10; break;
                    case "J": power = 11; break;
                    case "Q": power = 12; break;
                    case "K": power = 13; break;
                    case "A": power = 14; break;
                }

                switch (multiplierType)
                {
                    case "S": type = 4; break;
                    case "H": type = 3; break;
                    case "D": type = 2; break;
                    case "C": type = 1; break;
                }

                score += power * type;
            }

            return score;
        }
    }
}
