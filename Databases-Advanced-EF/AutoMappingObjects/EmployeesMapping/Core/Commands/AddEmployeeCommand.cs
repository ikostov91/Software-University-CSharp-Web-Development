using System;
using System.Collections.Generic;
using System.Text;
using EmployeesMapping.App.Core.Contracts;
using EmployeesMapping.App.Core.Dtos;

namespace EmployeesMapping.App.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public AddEmployeeCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execure(string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            EmployeeDto employeeDto = new EmployeeDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.employeeController.AddEmployee(employeeDto);

            return $"Employee {employeeDto.FirstName} {employeeDto.LastName} was added succesffully";
        }
    }
}
