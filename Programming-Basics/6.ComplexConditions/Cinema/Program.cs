using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string viewingType = Console.ReadLine().ToLower();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double income = 0;

            switch (viewingType)
            {
                case "premiere":
                    income = rows * columns * 12.00;
                    break;
                case "normal":
                    income = rows * columns * 7.50;
                    break;
                case "discount":
                    income = rows * columns * 5.00;
                    break;
            }

            Console.WriteLine("{0:f2} leva", income);
        }
    }
}
