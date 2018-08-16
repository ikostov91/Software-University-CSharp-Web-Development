using AutoMapper;
using EmployeesMapping.App.Core;
using EmployeesMapping.App.Core.Contracts;
using EmployeesMapping.App.Core.Controllers;

namespace EmployeesMapping.App
{
    using System;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //using (var context = new EmployeesMappingContext())
            //{
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //ICollection<Employee> employees = new List<Employee>()
            //{
            //    new Employee("Ivo", "Kostov", 1700.0m),
            //    new Employee("Naska", "Chochkova", 700.0m, DateTime.Now.AddYears(-20)),
            //    new Employee("Lolio", "Loliov", 200.0m, "Studentski Grad 15"),
            //    new Employee("Pesho", "Peshov", 400.0m, DateTime.Now.AddYears(-21), "Sofia 213")
            //};

            //context.Employees.AddRange(employees);
            //context.SaveChanges();
            //}
            //}

            var service = ConfigureService();
            IEngine engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddAutoMapper(conf => conf.AddProfile<EmployeeMappingProfile>());
            serviceCollection.AddDbContext<EmployeesMappingContext>(opts => opts.UseSqlServer(Configuration.ConnectionString));
            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();
            serviceCollection.AddTransient<IManagerController, ManagerController>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
