using System.Globalization;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using BarrackWarsTheCommandsStrikeBack.Core.Commands;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data[0]) + "Command";
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);
            Command command = (Command)Activator.CreateInstance(commandType, data, repository, unitFactory);
            string result = command.Execute();
            return result;
        }
    }
}
