using System;
using System.Collections.Generic;
using System.Linq;

public class RawData
{
    static void Main(string[] args)
    {
        Cars cars = new Cars();

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Cargo cargo = new Cargo(int.Parse(parameters[3]), parameters[4]);
            List<Tire> allTires = new List<Tire>();
            for (int tireIndex = 5; tireIndex <= 12; tireIndex += 2)
            {
                Tire tire = new Tire(double.Parse(parameters[tireIndex]), int.Parse(parameters[tireIndex + 1]));
                allTires.Add(tire);
            }

            Car car = new Car(parameters[0], int.Parse(parameters[1]), int.Parse(parameters[2]), cargo, allTires);
            cars.AddCar(car);
        }

        cars.GetCars(Console.ReadLine());
    }
}

