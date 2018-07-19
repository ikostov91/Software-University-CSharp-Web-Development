using System;
using System.Collections.Generic;
using System.Text;
using BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Enums;

namespace P01_BillsPaymentSystem.SeedClass
{
    public class PaymentMethodInitializer
    {
        public static PaymentMethod[] GetPaymentMethods()
        {
            PaymentMethod[] paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod() { Type = PaymentType.BankAccount, UserId = 1, BankAccountId = 1 },
                new PaymentMethod() { Type = PaymentType.CreditCard,  UserId = 2, CreditCardId = 1 } 
            };

            return paymentMethods;
        }
    }
}
