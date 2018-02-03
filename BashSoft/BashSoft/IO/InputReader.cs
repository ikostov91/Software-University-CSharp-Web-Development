using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft
{
    public static class InputReader
    {
        private const string endCommand = "quit";
        public static void StartReadingCommands()
        {
            string input = Console.ReadLine();

            while (input != endCommand)
            {
                CommandInterpreter.InterpretCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}>");
                input = Console.ReadLine();
                input = input.Trim();
            }
        }
    }
}
