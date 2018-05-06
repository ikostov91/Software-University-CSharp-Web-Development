using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private List<Driver> allDrivers = new List<Driver>();
    private Dictionary<Driver, string> dnfDrivers = new Dictionary<Driver, string>();
    private int trackLength = 0;
    private int raceLaps = 0;
    private int lapsCompleted = 0;
    private string currentWeather = "Sunny";

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.trackLength = trackLength;
        this.raceLaps = lapsNumber;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        string driverType = commandArgs[0];
        string name = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmmount = double.Parse(commandArgs[3]);
        string tyreType = commandArgs[4];
        double tyreHardness = double.Parse(commandArgs[5]);

        Tyre tyre = null;
        if (tyreType == "Ultrasoft")
        {
            double tyreGrip = double.Parse(commandArgs[6]);
            tyre = new UltrasoftTyre(tyreHardness, tyreGrip);
        }
        else
        {
            tyre = new HardTyre(tyreHardness);
        }
        Car car = new Car(hp, fuelAmmount, tyre);

        Driver driver = null;
        switch (driverType)
        {
            case "Aggressive":
                driver = new AggressiveDriver(name, car);
                break;
            case "Endurance":
                driver = new EnduranceDriver(name, car);
                break;
            default:
                throw new ArgumentException();
        }

        allDrivers.Add(driver);
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxType = commandArgs[0];
        string driverName = commandArgs[1];
        Driver driver = allDrivers.FirstOrDefault(x => x.Name == driverName);

        switch (boxType)
        {
            case "Refuel":
                double fuelAmmount = double.Parse(commandArgs[2]);
                driver.Car.Refuel(fuelAmmount);
                break;
            case "ChangeTyres":
                string tyreType = commandArgs[2];
                double hardness = double.Parse(commandArgs[3]);
                if (tyreType == "Ultrasoft")
                {
                    double grip = double.Parse(commandArgs[4]);
                    Tyre newTyre = new UltrasoftTyre(hardness, grip);
                    driver.Car.ChangeTyres(newTyre);
                }
                else
                {
                    Tyre newTyre = new HardTyre(hardness);
                    driver.Car.ChangeTyres(newTyre);
                }
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int lapsToComplete = int.Parse(commandArgs[0]);

        if (lapsToComplete > (raceLaps - lapsCompleted))
        {
            throw new ArgumentException($"There is no time!On lap {lapsCompleted}.");
        }

        for (int lap = 1; lap <= lapsToComplete; lap++)
        {
            lapsCompleted += 1;
            AddTimeToDrivers(allDrivers);
            DecreaseDriverResources(allDrivers);
            AttemptOvertakes(allDrivers);
        }

        if (lapsCompleted == raceLaps)
        {
            return this.GetWinner();
        }

        return "";
    }

    private void AddTimeToDrivers(List<Driver> drivers)
    {
        foreach (var driver in drivers)
        {
            double timeToAdd = 60 / (trackLength / driver.Speed);
            driver.AddToTotalTime(timeToAdd);
        }
    }

    private void DecreaseDriverResources(List<Driver> drivers)
    {
        for (int i = 0; i < drivers.Count; i++)
        {
            try
            {
                double burnedFuel = trackLength * drivers[i].FuelConsumptionPerKm;
                drivers[i].Car.ReduceFuel(burnedFuel);
                drivers[i].Car.Tyre.CompleteLap();
            }
            catch (ArgumentException exception)
            {
                dnfDrivers.Add(drivers[i], exception.Message);
                drivers.RemoveAt(i);
                i -= 1;
            }
        }
    }

    private void AttemptOvertakes(List<Driver> drivers)
    {
        double overtakeInterval = 2;
        bool aggressiveUltrasoft = false;
        bool enduranceHard = false;

        for (int i = drivers.Count - 1; i >= 1; i--)
        {
            if (drivers[i].GetType().Name == "Aggressive" && drivers[i].Car.Tyre.Name == "Ultrasoft")
            {
                overtakeInterval = 3;
                aggressiveUltrasoft = true;
            }
            else if (drivers[i].GetType().Name == "EnduranceDriver" && drivers[i].Car.Tyre.Name == "Hard")
            {
                overtakeInterval = 3;
                enduranceHard = true;
            }

            if ((drivers[i].TotalTime - drivers[i].TotalTime) <= overtakeInterval)
            {
                if (currentWeather == "Foggy" && aggressiveUltrasoft)
                {
                    dnfDrivers.Add(drivers[i], ErrorMessages.Crash);
                    drivers.RemoveAt(i);
                }
                else if (currentWeather == "Rainy" && enduranceHard)
                {
                    dnfDrivers.Add(drivers[i], ErrorMessages.Crash);
                    drivers.RemoveAt(i);
                }
                else
                {
                    Driver temp = drivers[i];
                    drivers[i] = drivers[i - 1];
                    drivers[i - 1] = temp;
                    i -= 1;

                    Console.WriteLine($"{drivers[i].Name} has overtaken {drivers[i - 1].Name} on lap {lapsCompleted}.");
                }
            }
        }
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {lapsCompleted}/{raceLaps}");

        List<Driver> driversRacing = allDrivers.OrderBy(x => x.TotalTime).ToList();

        for (int i = 0; i < driversRacing.Count; i++)
        {
            sb.AppendLine($"{i + 1} {driversRacing[i].Name} {driversRacing[i].TotalTime:F3}");
        }

        int position = driversRacing.Count;
        foreach (var driver in dnfDrivers)
        {
            position += 1;
            sb.AppendLine($"{position} {driver.Key.Name} {driver.Value}");
        }

        return sb.ToString();
    }

    public string GetWinner()
    {
        Driver winner = allDrivers.OrderBy(x => x.TotalTime).FirstOrDefault();
        return $"{winner.Name} wins the race for {winner.TotalTime:F3} seconds.";
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string weather = commandArgs[0];
        currentWeather = weather;
    }
}

