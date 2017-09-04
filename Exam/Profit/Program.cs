using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            int coins1Levs = int.Parse(Console.ReadLine());
            int coins2Levs = int.Parse(Console.ReadLine());
            int bills5Levs = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            int currentSum = 0;

            for (int i = 0; i <= coins1Levs; i++)
            {
                for (int j = 0; j <= coins2Levs; j++)
                {
                    for (int k = 0; k <= bills5Levs; k++)
                    {
                        currentSum = i * 1 + j * 2 + k * 5;
                        if (currentSum == sum)
                        {
                            Console.WriteLine("{0} * 1 lv. + {1} * 2 lv. + {2} * 5 lv. = {3} lv.", i, j, k, sum);
                        }
                    }
                }
            }
        }
    }
}
