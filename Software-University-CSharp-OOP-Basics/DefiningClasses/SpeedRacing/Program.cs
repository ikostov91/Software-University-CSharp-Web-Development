using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfCars = int.Parse(Console.ReadLine());
        List<Car> allCars = new List<Car>();

        for (int i = 0; i < numberOfCars; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();

            string model = input[0];
            int fuelAmmount = int.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);

            Car car = new Car(model, fuelAmmount, fuelConsumption, 0);

            allCars.Add(car);
        }

        string command = String.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] currentCarCommand = command.Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();
            string carModel = currentCarCommand[1];
            int distanceToTravel = int.Parse(currentCarCommand[2]);

            Car currentCar = allCars.Find(x => x.Model == carModel);

            currentCar.CalculateFuelDistance(distanceToTravel);
        }

        foreach (var car in allCars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}

