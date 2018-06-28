using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        
        int numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] input = Console.ReadLine().Split();

            Employee employee = null;

            if (input.Length == 6)
            {
                employee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], input[4], int.Parse(input[5]));
            }
            else
            {
                switch (input.Length)
                {
                    case 4:
                        employee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3]);
                        break;
                    case 5:
                        int integer;
                        bool isAge = int.TryParse(input[4], out integer);
                        if (isAge)
                        {
                            employee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], int.Parse(input[4]));
                        }
                        else
                        {
                            employee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], input[4]);
                        }
                        break;
                }
            }

            employees.Add(employee);
        }

        KeyValuePair<string, decimal> departmentWithHighestAverageSalary = GetDepartmentWithHighestAverageSalary(employees);

        Console.WriteLine($"Highest Average Salary: {departmentWithHighestAverageSalary.Key}");
        foreach (var employee in employees.Where(x => x.Department == departmentWithHighestAverageSalary.Key).OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
        }
    }

    private static KeyValuePair<string, decimal> GetDepartmentWithHighestAverageSalary(List<Employee> employees)
    {
        Dictionary<string, decimal> departments = new Dictionary<string, decimal>();

        foreach (var employee in employees)
        {
            if (!departments.ContainsKey(employee.Department))
            {
                departments.Add(employee.Department, employee.Salary);
            }
            else
            {
                departments[employee.Department] += employee.Salary;
            }
        }

        return departments.OrderByDescending(x => x.Value).First();
    }
}