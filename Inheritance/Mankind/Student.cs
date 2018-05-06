using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (!ValidateFacultyNumber(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        
        this.FacultyNumber = facultyNumber;
    }

    private bool ValidateFacultyNumber(string number)
    {
        string pattern = @"^[a-zA-Z0-9]{5,10}$";

        if (Regex.IsMatch(number, pattern))
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return (base.ToString() + Environment.NewLine + $"Faculty number: {this.FacultyNumber}").TrimEnd();
    }
}

