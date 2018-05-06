using System;
using System.Collections.Generic;
using System.Text;

    public class CommandParser
    {
        public void ExecuteCommand(string[] command, Vehicle vehicle)
        {
            switch (command[0])
            {
                case "Drive":
                    vehicle.Drive(double.Parse(command[2]));
                    break;
                case "Refuel":
                    vehicle.Refuel(double.Parse(command[2]));
                    break;
            }
        }
    }

