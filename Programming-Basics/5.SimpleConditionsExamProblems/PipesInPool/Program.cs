using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());
            int P1 = int.Parse(Console.ReadLine());
            int P2 = int.Parse(Console.ReadLine());
            double N = double.Parse(Console.ReadLine());

            double firstPipeAmmount = P1 * N;
            double secondPipeAmmount = P2 * N;
            double waterFromPipes = firstPipeAmmount + secondPipeAmmount;

            if (waterFromPipes > V)
            {
                Console.WriteLine("For {0} hours the pool overflows with {1} liters.", N, (waterFromPipes - V));
            }
            else
            {
                double percentageFull = Math.Truncate((waterFromPipes / V) * 100);
                double firstPipePercentage = Math.Truncate((firstPipeAmmount / waterFromPipes) * 100);
                double secondPipePercentage = Math.Truncate((secondPipeAmmount / waterFromPipes) * 100);
                Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.", percentageFull, firstPipePercentage, secondPipePercentage);
            }
        }
    }
}
