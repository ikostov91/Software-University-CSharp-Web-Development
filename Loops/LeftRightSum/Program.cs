using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                leftSum += number;
            }

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                rightSum += number;
            }

            if (leftSum == rightSum)
            {
                Console.WriteLine("yes,sum = {0}",leftSum);
            }
            else
            {
                Console.WriteLine("no,diff = {0}", Math.Abs(leftSum - rightSum));
            }
        }
    }
}
