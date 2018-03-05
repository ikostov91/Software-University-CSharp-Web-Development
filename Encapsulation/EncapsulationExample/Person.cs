using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class Person
{
    public int age;

    public int Age
    {
        get { return age; }
    }

    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FullName
    {
        get { return this.firstName + " " + this.lastName; }
    }

    public bool SetAge(int newAge)
    {
        this.age = newAge;
        var isValid = IsAgeValid(this);
        IncreaseAgeByOne();
        return true;
    }

    bool IsAgeValid(Person person)
    {
        return person.age >= 0;
    }

    public void IncreaseAgeByOne()
    {
        this.age++;
    }

    //public Person IncreaseAgeByOne()
    //{
    //    this.age++;
    //    return this;
    //}

    public void Print()
    {
        Console.WriteLine($"My age is {Age}");
    }
}

