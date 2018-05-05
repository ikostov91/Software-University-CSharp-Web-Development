using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Team> Teams = new List<Team>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] teamToCreate = Console.ReadLine().Split('-').ToArray();
                string creator = teamToCreate[0];
                string teamName = teamToCreate[1];

                if (Teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                else
                {
                    Team newTeam = new Team();
                    newTeam.Name = teamName;
                    newTeam.Creator = creator;
                    newTeam.Members = new List<string>();

                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                    Teams.Add(newTeam);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] memberToJoin = input.Split(new string[] { "->" }, StringSplitOptions.None).ToArray();
                string name = memberToJoin[0];
                string teamToJoin = memberToJoin[1];

                if (Teams.Any(t => t.Name == teamToJoin))
                {
                    bool canJoin = CheckIfMemberCanJoin(Teams, name);
                    if (canJoin)
                    {
                        Teams.First(t => t.Name == teamToJoin).Members.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"Member {name} cannot join team {teamToJoin}!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
            }

            List<Team> teamsToDisband = Teams.Where(x => x.Members.Count == 0).OrderBy(n => n.Name).ToList();
            List<Team> teamsWithMembers = Teams.Where(x => x.Members.Count >= 1)
                                               .OrderByDescending(y => y.Members.Count)
                                               .ThenBy(n => n.Name)
                                               .ToList();

            foreach (var team in teamsWithMembers)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(n => n))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in teamsToDisband)
            {
                Console.WriteLine(team.Name);
            }
        }

        private static bool CheckIfMemberCanJoin(List<Team> teams, string name)
        {
            foreach (var team in teams)
            {
                if (team.Creator == name)
                {
                    return false;
                }

                foreach (var member in team.Members)
                {
                    if (member == name)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
