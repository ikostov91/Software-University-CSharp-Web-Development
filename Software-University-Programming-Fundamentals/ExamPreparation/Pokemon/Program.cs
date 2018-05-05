using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            double halfN = N * 0.5;
            int pokedTargets = 0;

            while (N >= M)
            {
                N = N - M;
                pokedTargets += 1;

                if (N == halfN && Y > 0)
                {
                    N /= Y;
                }
            }

            Console.WriteLine(N);
            Console.WriteLine(pokedTargets);
        }
    }
}
