using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private const decimal MinWeekSalary = 10m;
    private const int     MinWorkHours = 1;
    private const int     MaxWorkHours = 12;

    private decimal weekSalary;
    private int workHoursPerDay;

    public int WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (!ValidateWorkHours(value))
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (!ValidateWeekSalary(value))
            {
                throw  new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    public Worker(string firstName, string lastName, decimal salary, int workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = salary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private decimal SalaryPerHour()
    {
        int totalWeekHours = this.WorkHoursPerDay * 5;
        decimal salaryPerHour = this.WeekSalary / totalWeekHours;

        return salaryPerHour;
    }

    private bool ValidateWeekSalary(decimal salary)
    {
        if (salary <= MinWeekSalary)
        {
            return false;
        }

        return true;
    }

    private bool ValidateWorkHours(int hours)
    {
        if (hours < MinWorkHours || hours > MaxWorkHours)
        {
            return false;
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine(base.ToString())
            .AppendLine($"Week Salary: {this.WeekSalary:F2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:F2}")
            .Append($"Salary per hour: {this.SalaryPerHour():F2}");

        return result.ToString().TrimEnd();
    }
}

