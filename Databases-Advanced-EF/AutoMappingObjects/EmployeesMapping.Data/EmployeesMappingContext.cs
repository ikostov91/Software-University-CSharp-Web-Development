using System;
using EmployeesMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesMapping.Data
{
    public class EmployeesMappingContext : DbContext
    {
        public EmployeesMappingContext()
        {
        }

        public EmployeesMappingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
