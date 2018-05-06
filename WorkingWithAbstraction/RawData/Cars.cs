using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Cars
{
    private List<Car> allCars;
    private List<string> carsWithFragileCargo;
    private List<string> carsWithFlamableCargo;

    public Cars()
    {
        allCars = new List<Car>();
    }

    public void AddCar(Car car)
    {
        allCars.Add(car);
    }

    public void GetCars(string cargoType)
    {
        if (cargoType == "fragile")
        {
            CarsWithFragileCargo();
        }
        else
        {
            CarsWithFlamableCargo();
        }
    }

    public void CarsWithFragileCargo()
    {
        carsWithFragileCargo = new List<string>(allCars
            .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
            .Select(x => x.Model)
            .ToList());
        Console.WriteLine(string.Join(Environment.NewLine, carsWithFragileCargo));
    }

    public void CarsWithFlamableCargo()
    {
        carsWithFlamableCargo = new List<string>(allCars
            .Where(x => x.Cargo.CargoType == "flamable" && x.EnginePower > 250)
            .Select(x => x.Model)
            .ToList());
        Console.WriteLine(string.Join(Environment.NewLine, carsWithFlamableCargo));
    }
}

