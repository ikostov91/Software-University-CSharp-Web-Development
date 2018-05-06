using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Child : Person
{
    private const int MaxAge = 15;
    public override int Age
    {
        get
        {
            return base.Age;
        }

        set
        {
            if (value > MaxAge)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            base.Age = value;
        }
    }

    public Child(string name, int age) : base(name, age)
    {
        
    }
}

