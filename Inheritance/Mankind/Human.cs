using System;
using System.Collections.Generic;
using System.Text;

public class Human
{
    private string firstName;
    private string lastName;

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            ValidateName(value, "firstName");
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            ValidateName(value, "lastName");
            this.lastName = value;
        }
    }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    protected void ValidateName(string name, string nameType)
    {
        int minNameLength = 0;

        if (!char.IsUpper(name, 0))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {nameType}");
        }

        switch (nameType)
        {
            case "firstName":
                minNameLength = 4;
                break;
            case "lastName":
                minNameLength = 3;
                break;
        }

        if (name.Length < minNameLength)
        {
            throw new ArgumentException($"Expected length at least {minNameLength} symbols! Argument: {nameType}");
        }
    }

    public override string ToString()
    {
        return ($"First Name: {this.FirstName}" + Environment.NewLine + $"Last Name: {this.LastName}").TrimEnd();
    }
}

