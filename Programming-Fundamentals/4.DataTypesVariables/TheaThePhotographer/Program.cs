using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long picturesTaken = int.Parse(Console.ReadLine());
            long filterTime = int.Parse(Console.ReadLine());
            long filteredPicturesPercentage = int.Parse(Console.ReadLine());
            long uploadTime = int.Parse(Console.ReadLine());

            long filteredPictures = (int)Math.Ceiling(picturesTaken * (filteredPicturesPercentage / 100.0));
            long totalTime = (picturesTaken * filterTime) + (filteredPictures * uploadTime);
            long days = 0, hours = 0, minutes = 0;

            if (totalTime >= 86400)
            {
                days = totalTime / 86400;
                totalTime = totalTime % 86400;
            }

            if (totalTime >= 3600)
            {
                hours = totalTime / 3600;
                totalTime = totalTime % 3600;
            }

            if (totalTime >= 60)
            {
                minutes = totalTime / 60;
                totalTime = totalTime % 60;
            }

            Console.WriteLine("{0}:{1:D2}:{2:D2}:{3:D2}", days, hours, minutes, totalTime);

            // Another way to solve this problem
            // TimeSpan time = TimeSpan.FromSeconds(totalTime);
            // Console.WriteLine("{0}:{1:D2}:{2:D2}:{3:D2}", time.Days, time.Hours, time.Minutes, time.Seconds);
        }
    }
}
