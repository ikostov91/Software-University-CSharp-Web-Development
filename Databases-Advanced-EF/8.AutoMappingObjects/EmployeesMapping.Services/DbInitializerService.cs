namespace EmployeesMapping.Services
{
    using System;
    using EmployeesMapping.Data;
    using EmployeesMapping.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly EmployeesMappingContext context;

        public DbInitializerService(EmployeesMappingContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
