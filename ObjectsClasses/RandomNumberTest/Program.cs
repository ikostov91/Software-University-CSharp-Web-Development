using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd;

            while (true)
            {
                rnd = new Random();
                Console.WriteLine(Environment.TickCount);
                Console.WriteLine(rnd.Next(10));
            }
        }
    }
}
