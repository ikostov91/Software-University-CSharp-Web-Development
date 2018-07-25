using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper.QueryableExtensions;
using EmployeesMapping.App.Core.Contracts;
using EmployeesMapping.App.Core.Dtos;
using EmployeesMapping.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMapping.App.Core.Controllers
{
    public class ManagerController : IManagerController
    {
        private EmployeesMappingContext context;

        public ManagerController(EmployeesMappingContext context)
        {
            this.context = context;
        }

        public ManagerDto GetManagerInfo(int employeeId)
        {
            var employee = context.Employees
                                  .Include(x => x.ManagerEmployees)
                                  .Where(x => x.Id == employeeId)
                                  .ProjectTo<ManagerDto>()
                                  .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employee;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);
            var manager = this.context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentException("Invalid id");
            }

            employee.Manager = manager;
            context.SaveChanges();
        }
    }
}
