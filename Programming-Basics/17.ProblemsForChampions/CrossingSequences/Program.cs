using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int tribonachiFirst = int.Parse(Console.ReadLine());
            int tribonachiSecond = int.Parse(Console.ReadLine());
            int tribonachiThird = int.Parse(Console.ReadLine());
            int spiralFirst = int.Parse(Console.ReadLine());
            int spiralStep = int.Parse(Console.ReadLine());

            int tribonachiCurrent = tribonachiFirst + tribonachiSecond + tribonachiThird, 
                spiralCurrent     = spiralFirst, spiralStepMultiplier = 1, spiralIncrement = 0;

            while (spiralCurrent <= 1000000 && tribonachiCurrent <= 1000000)
            {
                if (spiralCurrent == tribonachiCurrent)
                {
                    Console.WriteLine(tribonachiCurrent);
                    break;
                }
                else if (spiralCurrent < tribonachiCurrent)
                {
                    spiralCurrent += spiralStepMultiplier * spiralStep;
                    spiralIncrement++;
                    if (spiralIncrement % 2 == 0)
                    {
                        spiralStepMultiplier += 2;
                    }
                }
                else if (tribonachiCurrent < spiralCurrent)
                {
                    tribonachiFirst = tribonachiSecond;
                    tribonachiSecond = tribonachiThird;
                    tribonachiThird = tribonachiCurrent;

                    tribonachiCurrent = tribonachiFirst + tribonachiSecond + tribonachiThird;
                }
            }

            
        }
    }
}
