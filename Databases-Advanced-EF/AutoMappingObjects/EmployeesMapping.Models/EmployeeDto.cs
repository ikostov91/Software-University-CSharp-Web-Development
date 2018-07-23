using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesMapping.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }
    }
}
