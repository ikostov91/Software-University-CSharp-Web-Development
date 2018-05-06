using System;
using System.Linq;

    class StartUp
    {
        static void Main()
        {
            CommandParser cmdParser = new CommandParser();

            string[] carInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Vehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));

            string[] truckInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Vehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

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
                } 
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());    
        }
    }
