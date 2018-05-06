using System;
using System.Collections.Generic;
using System.Text;

public class Provider
{
    private const int MinEnergyOutput = 0;
    private const int MaxEnergyOutput = 10000;

    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get
        {
            return this.id;
        }
        protected set
        {
            this.id = value;
        }
    }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }
        protected set
        {
            if (value < MinEnergyOutput || value > MaxEnergyOutput)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }
}

