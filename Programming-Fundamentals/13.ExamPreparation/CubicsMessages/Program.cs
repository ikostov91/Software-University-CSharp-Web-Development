using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CubicsMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Over!")
                {
                    break;
                }

                string message = input;
                int length = int.Parse(Console.ReadLine());

                string messagePattern = @"(?<indx1>.*)(?<message>[a-zA-Z]{" + length + "})(?<indx2>.*)";
                string indexPattern = @"[0-9]";

                Match messageMatch = Regex.Match(message, messagePattern);
                string decryptedMessage = messageMatch.Groups["message"].ToString();

                bool isMessageValid = CheckMessage(messageMatch);

                if (isMessageValid == false)
                {
                    continue;
                }

                MatchCollection indexMatches = Regex.Matches(message, indexPattern);
                StringBuilder verificationCode = new StringBuilder();

                foreach (Match index in indexMatches)
                {
                    int currentIndex = int.Parse(index.ToString());

                    if (currentIndex >= 0 && currentIndex < decryptedMessage.Length)
                    {
                        verificationCode.Append(decryptedMessage[currentIndex]);
                    }
                    else
                    {
                        verificationCode.Append(" ");
                    }
                }

                Console.WriteLine($"{decryptedMessage} == {verificationCode}");
            }
        }

        private static bool CheckMessage(Match messageMatch)
        {
            string indx1Pattern = @"^[0-9]*$";
            string indx2Pattern = @"^[^a-zA-Z]*$";

            if (Regex.IsMatch(messageMatch.Groups["indx1"].ToString(), indx1Pattern) && Regex.IsMatch(messageMatch.Groups["indx2"].ToString(), indx2Pattern))
            {
                return true;
            }

            return false;
        }
    }
}
