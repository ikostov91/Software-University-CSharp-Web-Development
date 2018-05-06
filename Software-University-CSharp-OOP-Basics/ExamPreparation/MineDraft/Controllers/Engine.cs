using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{ 
    public void Run()
    {
        DraftManager dm = new DraftManager();

        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            switch (input[0])
            {
                case "RegisterHarvester":
                    Console.WriteLine(dm.RegisterHarvester(input.Skip(1).ToList()));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(dm.RegisterProvider(input.Skip(1).ToList()));
                    break;
                case "Day":
                    Console.WriteLine(dm.Day());
                    break;
                case "Mode":
                    Console.WriteLine(dm.Mode(input.Skip(1).ToList()));
                    break;
                case "Check":
                    Console.WriteLine(dm.Check(input.Skip(1).ToList()));
                    break;
                case "Shutdown":
                    Console.WriteLine(dm.ShutDown());
                    return;
            }
        }
    }
}
