using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeComissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine().ToLower();
            double volume = double.Parse(Console.ReadLine());
            double commission = 0;

            if (volume >= 0 && volume <= 500)
            {
                if (city == "sofia")
                {
                    commission = volume * 0.05;
                }
                else if (city == "varna")
                {
                    commission = volume * 0.045;
                }
                else if (city == "plovdiv")
                {
                    commission = volume * 0.055;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (volume > 500 && volume <= 1000)
            {
                if (city == "sofia")
                {
                    commission = volume * 0.07;
                }
                else if (city == "varna")
                {
                    commission = volume * 0.075;
                }
                else if (city == "plovdiv")
                {
                    commission = volume * 0.08;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (volume > 1000 && volume <= 10000)
            {
                if (city == "sofia")
                {
                    commission = volume * 0.08;
                }
                else if (city == "varna")
                {
                    commission = volume * 0.10;
                }
                else if (city == "plovdiv")
                {
                    commission = volume * 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (volume > 10000)
            {
                if (city == "sofia")
                {
                    commission = volume * 0.12;
                }
                else if (city == "varna")
                {
                    commission = volume * 0.13;
                }
                else if (city == "plovdiv")
                {
                    commission = volume * 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

            Console.WriteLine("{0:f2}",commission);
        }
    }
}
