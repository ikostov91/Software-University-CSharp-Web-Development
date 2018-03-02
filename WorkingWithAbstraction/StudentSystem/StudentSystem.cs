using System;
using System.Collections.Generic;

public class StudentSystem
{
    private Dictionary<string, Student> repo;

    private string studentInfo = string.Empty;

    public StudentSystem()
    {
        this.repo = new Dictionary<string, Student>();    
    }

    public Dictionary<string, Student> Repo
    {
        get { return this.repo; }
        set { this.repo = value; }
    }

    public void Create(string[] input)
    {
        var name = input[1];
        var age = int.Parse(input[2]);
        var grade = double.Parse(input[3]);

        if (!repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            this.repo.Add(name, student);
        }
    }

    public void Show(string[] input)
    {
        var name = input[1];

        if (this.repo.ContainsKey(name))
        {
            var student = this.repo[name];
            this.studentInfo = $"{student.Name} is {student.Age} years old.";

            FilterGrade(studentInfo, student);
        }

        ViewStudent();
    }

    public void FilterGrade(string studentInfo, Student student)
    {
        if (student.Grade >= 5.00)
        {
            this.studentInfo += " Excellent student.";
        }
        else if (student.Grade < 5.00 && student.Grade >= 3.50)
        {
            this.studentInfo += " Average student.";
        }
        else
        {
            this.studentInfo += " Very nice person.";
        }
    }

    public void ViewStudent()
    {
        Console.WriteLine(studentInfo);
    }
}