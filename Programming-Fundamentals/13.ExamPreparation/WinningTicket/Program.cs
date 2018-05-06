using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            string pattern = @"[$]{6,10}|[#]{6,10}|[@]{6,10}|[\^]{6,10}";

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                }
                else
                {
                    string leftPart = ticket.Substring(0, 10);
                    string rightPart = ticket.Substring(10);

                    Match leftMatch = Regex.Match(leftPart, pattern);
                    Match rightMatch = Regex.Match(rightPart, pattern);

                    string leftMatchString = leftMatch.ToString();
                    string rightMatchString = rightMatch.ToString();
                    int minLength = Math.Min(leftMatchString.Length, rightMatchString.Length);

                    if (leftMatchString.Substring(0, minLength) == rightMatchString.Substring(0, minLength))
                    {
                        if (leftMatchString.Length == 10 && rightMatchString.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - 10{leftMatchString.Substring(0,1)} Jackpot!");
                        }
                        else if (leftMatch.Length >= 6 && leftMatch.Length < 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {minLength}{leftMatchString.Substring(0, 1)}");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
            }
        }
    }
}
