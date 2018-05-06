using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Person
{
    private const decimal MinSalary = 460.0m;
    private const int     MinAge    = 0;
    private const int     MinLength = 3;

    private string  firstName;
    private string  lastName;
    private int     age;
    private decimal salary;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            ValidateFieldLength(value, "First name");
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            ValidateFieldLength(value, "Last name");
            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < MinAge)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set
        {
            if (value < MinSalary)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            this.salary = value;
        }
    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        if (this.age < 30)
        {
            percentage /= 2;
        }

        this.salary += this.salary * percentage / 100;
    }

    private void ValidateFieldLength(string fieldValue, string fieldName)
    {
        if (fieldValue?.Length < MinLength)
        {
            throw new ArgumentException(fieldName + " cannot contain fewer than 3 symbols!");
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
    }
}

