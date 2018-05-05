using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLab
{
    class Program
    {
        static void Main()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var rowsByLength = Math.Truncate(length / 1.2);
            var rowsByWidth = Math.Truncate((width - 1) / 0.7);
            Console.WriteLine(rowsByLength * rowsByWidth - 3);
        }
    }
}
