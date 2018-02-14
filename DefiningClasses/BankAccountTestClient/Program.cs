using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] splitCommand = command.Split();

            switch (splitCommand[0])
            {
                case "Create":
                    Create(splitCommand, accounts);
                    break;
                case "Deposit":
                    Deposit(splitCommand, accounts);
                    break;
                case "Withdraw":
                    Withdraw(splitCommand, accounts);
                    break;
                case "Print":
                    Print(splitCommand, accounts);
                    break;
            }
        }
    }

    private static void Create(string[] splitCommand, Dictionary<int, BankAccount> accounts)
    {
        int accountId = int.Parse(splitCommand[1]);

        if (accounts.ContainsKey(accountId))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            BankAccount account = new BankAccount();
            account.Id = accountId;
            accounts.Add(account.Id, account);
        }
    }

    private static void Deposit(string[] splitCommand, Dictionary<int, BankAccount> accounts)
    {
        int accountId = int.Parse(splitCommand[1]);

        if (accounts.ContainsKey(accountId))
        {
            accounts[accountId].Deposit(decimal.Parse(splitCommand[2]));
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(string[] splitCommand, Dictionary<int, BankAccount> accounts)
    {
        int accountId = int.Parse(splitCommand[1]);

        if (accounts.ContainsKey(accountId))
        {
            if (accounts[accountId].Balance < decimal.Parse(splitCommand[2]))
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[accountId].Withdraw(decimal.Parse(splitCommand[2]));
            }

        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Print(string[] splitCommand, Dictionary<int, BankAccount> accounts)
    {
        int accountId = int.Parse(splitCommand[1]);

        if (accounts.ContainsKey(accountId))
        {
            Console.WriteLine($"Account ID{accounts[accountId].Id}, balance {accounts[accountId].Balance:F2}");
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }
}

