using System;
using System.Collections.Generic;
using System.Text;

public class Harvester
{
    private const int MinOreOutput = 0;
    private const int MinEnergyRequirement = 0;
    private const int MaxEnergyRequirement = 20000;

    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
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

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < MinOreOutput)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            if (value < MinEnergyRequirement || value > MaxEnergyRequirement)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }
}

