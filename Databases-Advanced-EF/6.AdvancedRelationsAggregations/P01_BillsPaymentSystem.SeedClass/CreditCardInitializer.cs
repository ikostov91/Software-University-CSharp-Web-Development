using System;
using System.Collections.Generic;
using System.Text;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.SeedClass
{
    public class CreditCardInitializer
    {
        public static CreditCard[] GetCreditCards()
        {
            CreditCard[] creditCards = new CreditCard[]
            {
                new CreditCard() { Limit = 5000.0m, MoneyOwed = 1000.0m, ExpirationDate = DateTime.Parse("16/11/2019")}
            };

            return creditCards;
        }
    }
}
