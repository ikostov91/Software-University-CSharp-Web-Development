using System;
using System.Collections.Generic;
using System.Text;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.SeedClass
{
    public class BankAccountInitializer
    {
        public static BankAccount[] GetBankAccounts()
        {
            BankAccount[] accounts = new BankAccount[]
            {
                new BankAccount() { Balance = 30000.0m, BankName = "SocieteGenerale", SwiftCode = "CRB" }  
            };

            return accounts;
        }
    }
}
