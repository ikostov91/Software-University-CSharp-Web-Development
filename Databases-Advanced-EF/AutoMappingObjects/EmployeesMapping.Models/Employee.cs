using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeesMapping.Models
{
    public class Employee
    {
        private int id;
        private string firstName;
        private string lastName;
        private decimal salary;
        private DateTime? birthday;
        private string address;

        public Employee(string firstName, string lastName, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.ManagerEmployees = new HashSet<Employee>();
        }

        public Employee(string firstName, string lastName, decimal salary, DateTime birthday)
            : this(firstName, lastName, salary)
        {
            this.Birthday = birthday;
        }

        public Employee(string firstName, string lastName, decimal salary, string address)
            : this(firstName, lastName, salary)
        {
            this.Address = address;
        }

        public Employee(string firstName, string lastName, decimal salary, DateTime birthday, string address)
            : this(firstName, lastName, salary)
        {
            this.Birthday = birthday;
            this.Address = address;
        }

        [Key]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [Required]
        [MaxLength(50)]
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        [Required]
        [MaxLength(50)]
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        [Required]
        [DefaultValue(100)]
        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }
        
        public DateTime? Birthday
        {
            get { return this.birthday; }
            set { this.birthday = value; }
        }

        [MaxLength(250)]
        public string Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> ManagerEmployees { get; set; }
    }
}
