using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGuess
{
    class Program
    {
        static void Main()
        {
            string secretPassword = "s3cr3t!P@ssw0rd";
            string guess = Console.ReadLine();
            if (guess == secretPassword)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
