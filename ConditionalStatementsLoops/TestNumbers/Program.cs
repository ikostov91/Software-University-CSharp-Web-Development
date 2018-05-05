using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int boundary = int.Parse(Console.ReadLine());

            int sum = 0, combinations = 0, number1, number2, currentResult;
                
            for (int i = N; i >= 1; i--)
            {
                for (int j = 1; j <= M; j++)
                {
                    if (sum >= boundary)
                    {
                        break;
                    }

                    number1 = i;
                    number2 = j;
                    combinations++;
                    currentResult = (number1 * number2) * 3;
                    sum += currentResult;
                }
            }

            Console.WriteLine("{0} combinations", combinations);
            if (sum >= boundary)
            {
                Console.WriteLine("Sum: {0} >= {1}", sum, boundary);
            }
            else
            {
                Console.WriteLine("Sum: {0}", sum);
            }
            
        }
    }
}
