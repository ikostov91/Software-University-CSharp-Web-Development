using System;
using System.Collections.Generic;
using System.Text;
using EmployeesMapping.App.Core.Contracts;

namespace EmployeesMapping.App.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public EmployeePersonalInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            var employeeDto = this.employeeController.GetEmployeePersonalInfo(id);

            return $"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:F2}\n" + 
                 $"Birthday: {employeeDto.Birthday.Value.ToString("dd-MM-yyyy")}\n" + 
                 $"Address: {employeeDto.Address}";
        }
    }
}
