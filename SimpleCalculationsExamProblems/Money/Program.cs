using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    class Program
    {
        static void Main()
        {
            int bitcoins = int.Parse(Console.ReadLine());
            double chineseYuans = double.Parse(Console.ReadLine());
            double commission = double.Parse(Console.ReadLine());
            double bitcoinsLevs = bitcoins * 1168;
            double YuansLevs = chineseYuans * 0.15 * 1.76;
            double totalSumEuro = (bitcoinsLevs + YuansLevs) / 1.95;
            Console.WriteLine(totalSumEuro - (totalSumEuro * commission / 100));
        }
    }
}
