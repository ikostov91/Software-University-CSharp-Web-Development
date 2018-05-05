using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bricks
{
    class Program
    {
        static void Main(string[] args)
        {
            int bricks = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int bricksPerCourse = workers * capacity;
            double totalCourses = Math.Ceiling((double) bricks / bricksPerCourse);

            Console.WriteLine("{0}", totalCourses);
        }
    }
}
