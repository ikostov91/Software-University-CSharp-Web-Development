using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamBuilder.App.Core.Commands;

namespace TeamBuilder.App.Core
{
    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string commandName = inputArgs[0];
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (commandName)
            {
                case "Login":
                    var login = new LoginCommand();
                    result = login.Execute(inputArgs);
                    break;
                case "Logout":
                    var logout = new LogoutCommand();
                    result = logout.Execute(inputArgs);
                    break;
                case "RegisterUser":
                    var registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(inputArgs);
                    break;
                case "Exit":
                    var exit = new ExitCommand();
                    result = exit.Execute(inputArgs);
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }

            return result;
        }
    }
}
