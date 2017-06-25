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
            double MonthSalary = avgWorkDays * earningPerDay;
            double totalMoney = (MonthSalary * 12) + (MonthSalary * 2.5);
            double netSalary = totalMoney - (totalMoney * 0.25);
            double dailySalary = (netSalary / 365) * courseUSD;
            Console.WriteLine("{0:F2}", dailySalary);
        }
    }
}
