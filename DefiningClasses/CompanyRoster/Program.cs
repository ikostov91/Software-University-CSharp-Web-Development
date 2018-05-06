using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfEmployees = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();
        Dictionary<string, decimal> employeesInDepartment = new Dictionary<string, decimal>();

        for (int i = 0; i < numberOfEmployees; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();

            Employee newEmployee = null;

            if (input.Length == 6)
            {
                newEmployee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], input[4], int.Parse(input[5]));
            }
            else
            {
                if (input.Length < 6)
                {
                    

                    switch (input.Length)
                    {
                        case 4:
                            newEmployee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3]);
                            break;
                        case 5:
                            int number;
                            bool tryParseAge = int.TryParse(input[4], out number);
                            if (tryParseAge)
                            {
                                newEmployee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], int.Parse(input[4]));
                            }
                            else
                            {
                                newEmployee = new Employee(input[0], decimal.Parse(input[1]), input[2], input[3], input[4]);
                            }
                            break;
                    }
                }
            }

            employees.Add(newEmployee);
        }

        KeyValuePair<string, decimal> departmentWithHighestTotalSalary = CalculateSalaries(employees);

        Console.WriteLine($"Highest Average Salary: {departmentWithHighestTotalSalary.Key}");

        foreach (var employee in employees.Where(x => x.Department == departmentWithHighestTotalSalary.Key).OrderByDescending(y => y.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:F2} {employee.Email} {employee.Age}");
        }
    }

    private static KeyValuePair<string, decimal> CalculateSalaries(List<Employee> employees)
    {
        Dictionary<string, decimal> departments = new Dictionary<string, decimal>();

        foreach (var employee in employees)
        {
            if (!departments.ContainsKey(employee.Department))
            {
                departments.Add(employee.Department, 0);
            }
            else
            {
                departments[employee.Department] += employee.Salary;
            }
        }

        departments = departments.OrderByDescending(x => x.Value).ToDictionary(k => k.Key, v => v.Value);

        return departments.First();
    }
}
