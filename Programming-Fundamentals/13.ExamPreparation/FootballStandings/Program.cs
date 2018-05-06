using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballStandings
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> standings = new Dictionary<string, long>();
            Dictionary<string, long> goals = new Dictionary<string, long>();

            string key = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "final")
                {
                    break;
                }

                string[] currentMatch = input.Split(' ');


                string firstTeam = GetTeam(currentMatch[0], key);
                string secondTeam = GetTeam(currentMatch[1], key);
                int[] matchResult = currentMatch[2].Split(':').Select(int.Parse).ToArray();

                UpdateStandingsTable(firstTeam, secondTeam, matchResult, standings);
                UpdateGoalsTable(firstTeam, secondTeam, matchResult, goals);
            }

            Console.WriteLine($"League standings:");
            int index = 0;
            foreach (var item in standings.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
            {
                index += 1;
                Console.WriteLine($"{index}. {item.Key} {item.Value}");
            }

            Console.WriteLine($"Top 3 scored goals:");
            foreach (var item in goals.OrderByDescending(x => x.Value).ThenBy(y => y.Key).Take(3))
            {
                Console.WriteLine($"- {item.Key} -> {item.Value}");
            }
        }

        private static void UpdateStandingsTable(string firstTeam, string secondTeam, int[] matchResult, Dictionary<string, long> standings)
        {
            if (matchResult[0] > matchResult[1])
            {
                if (!standings.ContainsKey(firstTeam))
                {
                    standings.Add(firstTeam, 3);
                }
                else
                {
                    standings[firstTeam] += 3;
                }

                if (!standings.ContainsKey(secondTeam))
                {
                    standings.Add(secondTeam, 0);
                }

            }
            else if (matchResult[0] < matchResult[1])
            {
                if (!standings.ContainsKey(secondTeam))
                {
                    standings.Add(secondTeam, 3);
                }
                else
                {
                    standings[secondTeam] += 3;
                }

                if (!standings.ContainsKey(firstTeam))
                {
                    standings.Add(firstTeam, 0);
                }
            }
            else
            {
                if (!standings.ContainsKey(firstTeam))
                {
                    standings.Add(firstTeam, 1);
                }
                else
                {
                    standings[firstTeam] += 1;
                }

                if (!standings.ContainsKey(secondTeam))
                {
                    standings.Add(secondTeam, 1);
                }
                else
                {
                    standings[secondTeam] += 1;
                }
            }
        }

        private static void UpdateGoalsTable(string firstTeam, string secondTeam, int[] matchResult, Dictionary<string, long> goals)
        {
            if (!goals.ContainsKey(firstTeam))
            {
                goals.Add(firstTeam, matchResult[0]);
            }
            else
            {
                goals[firstTeam] += matchResult[0];
            }

            if (!goals.ContainsKey(secondTeam))
            {
                goals.Add(secondTeam, matchResult[1]);
            }
            else
            {
                goals[secondTeam] += matchResult[1];
            }
        }

        static string GetTeam(string text, string key)
        {
            string pattern = Regex.Escape(key) + @"(?<team>\w+)" + Regex.Escape(key);

            Match firstTeamMatch = Regex.Match(text, pattern);
            string teamName = firstTeamMatch.Groups["team"].ToString();
            char[] array = teamName.ToCharArray();
            Array.Reverse(array);
            string arrayStr = new string(array).ToUpper();

            return arrayStr;
        }
    }
}
