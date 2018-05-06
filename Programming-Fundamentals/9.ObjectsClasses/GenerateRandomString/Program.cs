using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateRandomString
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder randomString = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 101; i++)
            {
                int rndInt = rnd.Next(97, 123);
                randomString.Append((char)rndInt);
            }

            Console.WriteLine(randomString);
        }
    }
}
