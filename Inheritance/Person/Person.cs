using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Win32.SafeHandles;

public class Person
{
    private const int MinNameLength = 3;
    private const int MinAge = 0;

    private string name;
    private int age;

    public virtual string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length < MinNameLength)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            this.name = value;
        }
    }

    public virtual int Age
    {
        get { return this.age; }
        set
        {
            if (value < MinAge)
            {
                throw new ArgumentException("Age must be positive!");
            }
            this.age = value;
        }
    }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}

