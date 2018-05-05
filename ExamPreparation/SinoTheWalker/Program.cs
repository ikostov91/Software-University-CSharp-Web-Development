using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] timeOfLeave = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            int numberOfSteps = int.Parse(Console.ReadLine());
            int secondsPerStep = int.Parse(Console.ReadLine());

            ulong totalSeconds = (ulong)numberOfSteps * (ulong)secondsPerStep;

            var secondsToAdd = totalSeconds % 60;
            var totalMinutes = totalSeconds / 60;
            var minutesToAdd = totalMinutes % 60;
            var totalHours =  totalMinutes / 60;
            var hoursToAdd = totalHours % 24;

            var seconds = timeOfLeave[2] + (int)secondsToAdd;
            var minutes = timeOfLeave[1] + (int)minutesToAdd;
            var hours = timeOfLeave[0] + (int)hoursToAdd;

            if (seconds >= 60)
            {
                seconds -= 60;
                minutes++;
            }

            if (minutes >= 60)
            {
                minutes -= 60;
                hours++;    
            }

            if (hours >= 24)
            {
                hours -= 24;
            }

            Console.WriteLine($"Time Arrival: {hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
