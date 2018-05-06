
using System;
using System.Linq;
using System.Net.Http.Headers;
using FestivalManager.Core.IO;
using FestivalManager.Entities;

namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;

	/// <summary>
	/// by g0shk0
	/// </summary>
	class Engine : IEngine
	{
	    private IReader reader;
	    private IWriter writer;

	    private IFestivalController festivalCоntroller;
	    private ISetController setCоntroller;
	    private IStage stage;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            
            stage = new Stage();
	        festivalCоntroller = new FestivalController(stage);
            setCоntroller = new SetController(stage);
        }

        public void Run()
		{
		    string input;

			while (true)
			{
				input = reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception e)
				{
					this.writer.WriteLine("ERROR: " + e.InnerException.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

        public string ProcessCommand(string input)
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.None);

            var command = tokens.First();
            string[] parameters = tokens.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }

            var methodInfo = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

            string commandResults = string.Empty;

            try
            {
                commandResults = (string)methodInfo.Invoke(this.festivalCоntroller, new object[] { parameters });
            }
            catch (TargetInvocationException tie)
            {
                throw tie;
            }

            return commandResults;
        }
    }
}