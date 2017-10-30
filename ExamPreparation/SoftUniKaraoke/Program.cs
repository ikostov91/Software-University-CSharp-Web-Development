using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniKaraoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> participantsAwards = new Dictionary<string, List<string>>();

            string[] participants = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
            string[] songs = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            foreach (var participant in participants)
            {
                participantsAwards[participant] = new List<string>();
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "dawn")
                {
                    break;
                }

                string[] currentParticipant = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                string name = currentParticipant[0];
                string song = currentParticipant[1];
                string award = currentParticipant[2];

                if (participantsAwards.ContainsKey(name) && songs.Contains(song))
                {
                    participantsAwards[name].Add(award);
                }
            }

            for (int i = 0; i < participants.Length; i++)
            {
                participantsAwards[participants[i]] = participantsAwards[participants[i]].Distinct().ToList();
            }

            if (participantsAwards.Values.Sum(x => x.Count) == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                foreach (var participant in participantsAwards.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count))
                {
                    Console.WriteLine($"{participant.Key}: {participant.Value.Count} awards");

                    foreach (string item in participant.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{item}");
                    }
                }
            }
            
        }
    }
}
