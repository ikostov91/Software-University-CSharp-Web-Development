using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.SeedClass;

namespace P01_BillsPaymentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new BillsPaymentSystemContext())
            {
                var user = context.Users.Find(2);

                var paymentMethods = user.PaymentMethods.ToArray();

                Console.WriteLine();
            }
        }
    }
}
