using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLilly
{
    class Program
    {
        static void Main(string[] args)
        {
            int years = int.Parse(Console.ReadLine());
            decimal washingMachinePrice = decimal.Parse(Console.ReadLine());
            decimal toyPrice = decimal.Parse(Console.ReadLine());

            int toys = 0;
            decimal totalMoney = 0.00m, birthdayMoney = 0.00m;

            for (int i = 1; i <= years; i++)
            {
                if (i % 2 == 0)
                {
                    birthdayMoney += 10.0m;
                    totalMoney += birthdayMoney;
                    totalMoney -= 1.00m;
                }
                else
                {
                    toys++;
                }
            }

            totalMoney += (toys * toyPrice);

            if (totalMoney >= washingMachinePrice)
            {
                Console.WriteLine("Yes! {0:F2}", totalMoney - washingMachinePrice);
            }
            else
            {
                Console.WriteLine("No! {0:F2}", washingMachinePrice - totalMoney);
            }

            //Console.WriteLine(totalMoney >= washingMachinePrice ? $"Yes! {0:F2}, {(totalMoney - washingMachinePrice):0:00}" : $"{0:F2}, {(washingMachinePrice - totalMoney):0:00}");
        }
    }
}
