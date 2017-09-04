using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoPictures
{
    class Program
    {
        static void Main(string[] args)
        {
            int pictures = int.Parse(Console.ReadLine());
            string pictureType = Console.ReadLine().ToUpper();
            string deliveryType = Console.ReadLine().ToLower();

            decimal orderPrice = 0m, discount = 0m;

            switch (pictureType)
            {
                case "9X13":
                    orderPrice = pictures * 0.16m;
                    if (pictures >= 50)
                    {
                        discount = 0.05m;
                    }
                    break;
                case "10X15":
                    orderPrice = pictures * 0.16m;
                    if (pictures >= 80)
                    {
                        discount = 0.03m;
                    }
                    break;
                case "13X18":
                    orderPrice = pictures * 0.38m;
                    if (pictures >= 50 && pictures <= 100)
                    {
                        discount = 0.03m;
                    }
                    else if (pictures > 100)
                    {
                        discount = 0.05m;
                    }
                    break;
                case "20X30":
                    orderPrice = pictures * 2.90m;
                    if (pictures >= 10 && pictures <= 50)
                    {
                        discount = 0.07m;
                    }
                    else if (pictures > 50)
                    {
                        discount = 0.09m;
                    }
                    break;
            }

            orderPrice -= discount * orderPrice;

            if (deliveryType == "online")
            {
                discount = 0.02m;
                orderPrice -= discount * orderPrice;
            }

            Console.WriteLine("{0:F2}BGN", orderPrice);
        }
    }
}
