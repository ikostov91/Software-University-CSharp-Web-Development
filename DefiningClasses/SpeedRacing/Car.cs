using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private double fuelAmmount;
    private double fuelConsumption;
    private int distanceTravelled;

    public string Model
    {
        get { return this.model; }
        set { this.model = value;  }
    }

    public double FuelAmmount
    {
        get { return this.fuelAmmount;  }
        set { this.fuelAmmount = value; }
    }

    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
        set { this.fuelAmmount = value; }
    }

    public int DistanceTravelled
    {
        get { return this.distanceTravelled; }
        set { this.distanceTravelled = value; }
    }

    public Car(string model, double fuelAmmount, double fuelConsumption, int distanceTravelled)
    {
        this.model = model;
        this.fuelAmmount = fuelAmmount;
        this.fuelConsumption = fuelConsumption;
        this.distanceTravelled = distanceTravelled;
    }

    public void CalculateFuelDistance(int distance)
    {
        double fuelNeeded = distance * this.fuelConsumption;

        if (fuelNeeded > this.fuelAmmount)
        {
            Console.WriteLine($"Insufficient fuel for the drive");
        }
        else
        {
            this.fuelAmmount -= fuelNeeded;
            this.distanceTravelled += distance;
        }
    }

    public override string ToString()
    {
        return $"{this.model} {this.fuelAmmount:F2} {this.distanceTravelled}";
    }
}

