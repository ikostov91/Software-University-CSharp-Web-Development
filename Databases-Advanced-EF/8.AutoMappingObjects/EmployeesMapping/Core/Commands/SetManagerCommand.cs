using System;
using System.Collections.Generic;
using System.Text;
using EmployeesMapping.App.Core.Contracts;

namespace EmployeesMapping.App.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly IManagerController managerController;

        public SetManagerCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            // SetManager method - could return DTO instead of void (DTC with info for employee and manager)
            this.managerController.SetManager(employeeId, managerId);

            return "Command accomplished succesffully";
        }
    }
}
