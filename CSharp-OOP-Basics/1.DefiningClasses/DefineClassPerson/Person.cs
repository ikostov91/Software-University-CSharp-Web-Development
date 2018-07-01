﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private int age;
    //private List<BankAccount> accounts;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    //public Person(string name, int age)
    //{
    //    this.name = name;
    //    this.age = age;
    //    this.accounts = new List<BankAccount>();
    //}

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.name = name;
        this.age = age;
        //this.accounts = accounts;
    }

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }

    public Person(int age):this()       // Constructior chaining
    {
        this.age = age;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    //public decimal GetBalance()
    //{
    //    return this.accounts.Sum(x => x.Balance);
    //}

    public override string ToString()
    {
        return $"Person: {name}, age: {age}";
    }
}
