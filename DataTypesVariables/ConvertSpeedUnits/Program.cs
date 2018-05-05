using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int timeInSeconds = seconds + minutes * 60 + hours * 3600;
            float metersPerSecond = (float)distance / timeInSeconds;
            float kilometersPerHour = (float)(distance / 1000f) / (timeInSeconds / 3600f);
            float milesPerHour = (float)(distance / 1609f) / (timeInSeconds / 3600f);

            Console.WriteLine($"{metersPerSecond}\n{kilometersPerHour}\n{milesPerHour}");
        }
    }
}
