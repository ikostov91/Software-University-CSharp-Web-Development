﻿using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get { return this.firstName; }
    }

    public string LastName
    {
        get { return this.lastName; }
    }

    public int Age
    {
        get { return this.age; }
    }

    public decimal Salary
    {
        get { return this.salary; }
    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.age < 30)
        {
            percentage /= 2;
        }

        this.salary += this.salary * percentage / 100;
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }
}

