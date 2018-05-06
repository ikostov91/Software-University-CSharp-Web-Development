using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesInGivenRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            List<int> primes = FindPrimesInRange(startNum, endNum);

            string result = String.Join(", ", primes);
            Console.WriteLine(result);
        }

        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            var primesList = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                if (i == 0 || i == 1)
                {
                    continue;
                }

                bool checkPrime = isPrime(i);

                if (checkPrime == true)
                {
                    primesList.Add(i);
                }
            }
            return primesList;
        }

        static bool isPrime(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
