using System.Linq;
using AutoMapper.QueryableExtensions;
using EmployeesMapping.Models;

namespace EmployeesMapping.App.Core.Controllers
{
    using System;
    using EmployeesMapping.App.Core.Contracts;
    using EmployeesMapping.App.Core.Dtos;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using EmployeesMapping.Data;

    public class EmployeeController : IEmployeeController
    {
        private readonly EmployeesMappingContext context;
        private readonly IMapper mapper;

        public EmployeeController(EmployeesMappingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Address = address;

            context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            employee.Birthday = date;

            context.SaveChanges();
        }

        public EmployeeDto GetEmployeeInfo(int employeeId)
        {
            var employee = context.Employees
                                  .Where(x => x.Id == employeeId)
                                  .ProjectTo<EmployeeDto>()
                                  .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employee;
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = context.Employees
                                  .Where(x => x.Id == employeeId)
                                  .ProjectTo<EmployeePersonalInfoDto>()
                                  .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employee;
        }
    }
}
