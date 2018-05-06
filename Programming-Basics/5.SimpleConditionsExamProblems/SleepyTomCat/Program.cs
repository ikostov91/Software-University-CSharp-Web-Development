using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyTomCat
{
    class Program
    {
        static void Main(string[] args)
        {
            int restDays = int.Parse(Console.ReadLine());
            int playTimeRestDays = restDays * 127;
            int playTimeWorkDays = (365 - restDays) * 63;
            int totalPlaytime = playTimeRestDays + playTimeWorkDays;
            int difference = Math.Abs(totalPlaytime - 30000);
            int hours = difference / 60;
            int minutes = difference % 60;
            if (totalPlaytime <= 30000)
            {
                
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play", hours, minutes);
            }
            else
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", hours, minutes);
            }
        }
    }
}
