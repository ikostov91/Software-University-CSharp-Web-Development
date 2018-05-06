﻿using System;
using System.Runtime.InteropServices;

public class Bus : Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;
    private bool   airConditioner;

    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        set
        {
            this.fuelQuantity = value;
        }
    }

    public double FuelConsumption
    {
        get
        {
            if (AirConditioner)
            {
                return this.fuelConsumption + 1.4;
            }
            return this.fuelConsumption;
        }
        set
        {
            this.fuelConsumption = value;
        }
    }

    public double TankCapacity
    {
        get
        {
            return this.tankCapacity;
        }
        set
        {
            this.tankCapacity = value;
        }
    }

    public override bool AirConditioner
    {
        get
        {
            return this.airConditioner;
        }
        set
        {
            this.airConditioner = value;
        }
    }

    public override void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }

        if (fuel + this.FuelQuantity > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            return;
        }

        this.fuelQuantity += fuel;
    }

    public override void Drive(double distance)
    {
        if (distance <= this.GetDistance())
        {
            this.fuelQuantity -= distance * this.FuelConsumption;
            Console.WriteLine($"{this.GetType().Name}" + " travelled " + $"{distance} km");
        }
        else
        {
            Console.WriteLine($"{this.GetType().Name} needs refueling");
        }
    }

    public override double GetDistance()
    {
        double kilometers = this.fuelQuantity / this.FuelConsumption;
        return kilometers;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}
