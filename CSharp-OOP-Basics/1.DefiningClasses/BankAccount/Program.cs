using System;

class Program
{
    static void Main(string[] args)
    {
        BankAccount bankAcc = new BankAccount();

        bankAcc.Id = 1;
        bankAcc.Balance = 15;

        Console.WriteLine($"Account: {bankAcc.Id}, balance: {bankAcc.Balance}");
    }
}

