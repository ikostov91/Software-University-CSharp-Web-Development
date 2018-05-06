using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CommandParser
{
    public void ParseCommand(string input)
    {
        string[] command = input.Split(new char[] {' '}, StringSplitOptions.None).ToArray();

        StudentSystem StudentSystem = new StudentSystem();

        switch (command[0])
        {
            case "Create":
                StudentSystem.Create(command);
                break;
            case "Show":
                StudentSystem.Show(command);
                break;
            case "Exit":
                Environment.Exit(0);
                break;
        }
    }
}

