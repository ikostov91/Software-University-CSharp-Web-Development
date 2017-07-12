using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal inheritedMoney = decimal.Parse(Console.ReadLine());
            decimal neededMoney = 0.00m;
            int year = int.Parse(Console.ReadLine());
            int age = 18;

            for (int i = 1800; i <= year; i++)
            {             
                if (i % 2 == 0)
                {
                    neededMoney += 12000.00m;
                }
                else
                {
                    neededMoney += (12000.00m + 50 * age);
                }
                age++;
            }

            if (neededMoney <= inheritedMoney)
            {
                Console.WriteLine("Yes! He will live a carefree life and will have {0:F2} dollars left.", inheritedMoney - neededMoney);
            }
            else
            {
                Console.WriteLine("He will need {0:F2} dollars to survive.", neededMoney - inheritedMoney);
            }
        }
    }
}
