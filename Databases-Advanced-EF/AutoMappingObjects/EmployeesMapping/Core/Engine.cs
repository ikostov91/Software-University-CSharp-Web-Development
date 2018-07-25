using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesMapping.App.Core.Contracts;
using EmployeesMapping.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeesMapping.App.Core
{
    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var initializedDb = this.serviceProvider.GetService<IDbInitializerService>();
            initializedDb.InitializeDatabase();

            var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.None).ToArray();
                string result = commandInterpreter.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
