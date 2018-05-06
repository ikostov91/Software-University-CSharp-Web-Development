using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        CommandParser cmdParser = new CommandParser();
        InstantiateVehicles instVeh = new InstantiateVehicles();

        //string[] carInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        //Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
        Vehicle car = instVeh.InstantiateVehicle();
        //string[] truckInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        //Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
        Vehicle truck = instVeh.InstantiateVehicle();
        //string[] busInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
       // Vehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));
        Vehicle bus = instVeh.InstantiateVehicle();

        int commands = int.Parse(Console.ReadLine());

        for (int i = 1; i <= commands; i++)
        {
            string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            switch (command[1])
            {
                case "Car":
                    cmdParser.ExecuteCommand(command, car);
                    break;
                case "Truck":
                    cmdParser.ExecuteCommand(command, truck);
                    break;
                case "Bus":
                    cmdParser.ExecuteCommand(command, bus);
                    break;
            }
        }

        Console.WriteLine(car.ToString());
        Console.WriteLine(truck.ToString());
        Console.WriteLine(bus.ToString());
    }
}
