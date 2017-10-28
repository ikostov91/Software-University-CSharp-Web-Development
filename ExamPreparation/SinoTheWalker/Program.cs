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
            int[] leaveTime = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            //var leaveTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            int steps = int.Parse(Console.ReadLine());
            var secondsPerStep = int.Parse(Console.ReadLine());

            //int hours = leaveTime.Hour;
            //int minutes = leaveTime.Minute;
            //int seconds = leaveTime.Second;

            int hours = leaveTime[0];
            int minutes = leaveTime[1];
            int seconds = leaveTime[2];

            long initialSeconds = leaveTime[0] * 3600 + leaveTime[1] * 60 + leaveTime[2];
            ulong secondsToAdd = (ulong)steps * (ulong)secondsPerStep;

            ulong totalSeconds = (ulong)initialSeconds + secondsToAdd;

            var resulSeconds = totalSeconds % 60;
            var totalMinutes = totalSeconds / 60;
            var resultMinutes = totalMinutes % 60;
            var totalHours = totalMinutes / 60;
            var resultHours = totalHours % 24;

            Console.WriteLine($"Time Arrival: {resultHours:D2}:{resultMinutes:D2}:{resulSeconds:D2}");
        }
    }
}
