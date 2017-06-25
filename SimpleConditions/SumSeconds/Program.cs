using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            int totalTime = firstTime + secondTime + thirdTime;
            int minutes = 0;
            if (totalTime > 59)
            {
                minutes++;
                totalTime -= 60;
            }
            if (totalTime > 59)
            {
                minutes++;
                totalTime -= 60;
            }

            if (totalTime < 10)
            {
                Console.WriteLine(minutes + ":0" + totalTime);
            }
            else
            {
                Console.WriteLine(minutes + ":" + totalTime);
            }
        }
    }
}
