using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            int speed = int.Parse(Console.ReadLine());
            int firstTimeInterval = int.Parse(Console.ReadLine());
            int secondTimeInterval = int.Parse(Console.ReadLine());
            int thirdTimeInterval = int.Parse(Console.ReadLine());

            double firstDistanceInterval = speed * (firstTimeInterval / 60.0);

            double newSpeed = speed + (10 / 100.0 * speed);
            double secondDistanceInterval = newSpeed * (secondTimeInterval / 60.0);

            newSpeed = newSpeed - (5 / 100.0 * newSpeed);
            double thirdDistanceInterval = newSpeed * (thirdTimeInterval / 60.0);

            Console.WriteLine("{0:F2}", firstDistanceInterval + secondDistanceInterval + thirdDistanceInterval);
        }
    }
}
