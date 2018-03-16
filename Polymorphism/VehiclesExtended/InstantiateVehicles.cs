using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class InstantiateVehicles
{
    public Vehicle InstantiateVehicle()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        string vehicleType = input[0];
        double initialFuelQuantity = double.Parse(input[1]);
        double fuelConsumption = double.Parse(input[2]);
        double tankCapacity = double.Parse(input[3]);

        if (initialFuelQuantity > tankCapacity)
        {
            initialFuelQuantity = 0;
        }

        switch (vehicleType)
        {
            case "Car":
                return new Car(initialFuelQuantity, fuelConsumption, tankCapacity);
            case "Bus":
                return new Bus(initialFuelQuantity, fuelConsumption, tankCapacity);
            case "Truck":
                return new Truck(initialFuelQuantity, fuelConsumption, tankCapacity);
            default:
                return null;
        }
    }
}

