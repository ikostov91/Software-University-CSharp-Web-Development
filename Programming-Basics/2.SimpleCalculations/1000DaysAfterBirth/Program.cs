using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000DaysAfterBirth
{
    class Program
    {
        static void Main()
        {
            var stringDate = Console.ReadLine();
            DateTime date = DateTime.ParseExact(stringDate,"dd-MM-yyyy", null);
            DateTime newDate = date.AddDays(999);
            Console.WriteLine(newDate.ToString("dd-MM-yyyy"));
        }
    }
}
