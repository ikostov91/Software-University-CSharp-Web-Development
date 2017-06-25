using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyEarnings
{
    class Program
    {
        static void Main()
        {
            int avgWorkDays = int.Parse(Console.ReadLine());
            double earningPerDay = double.Parse(Console.ReadLine());
            double courseUSD = double.Parse(Console.ReadLine());
            double yearlyMoney = avgWorkDays * 12 * earningPerDay;
            double totalMoney = yearlyMoney + (avgWorkDays * earningPerDay * 2.5);
            double taxDeducted = totalMoney - (totalMoney * 25 / 100);
            double finalEarningsPerDay = taxDeducted / 365;
            Console.WriteLine(Math.Round((finalEarningsPerDay * courseUSD),2));
        }
    }
}
