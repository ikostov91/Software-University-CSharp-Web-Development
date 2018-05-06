using System;
using System.Collections.Generic;
using System.Text;

public class SonicHarvester : Harvester
{
    private const int MinSonicFactor = 0;

    private int sonicFactor;

    public int SonicFactor
    {
        get
        {
            return this.sonicFactor;
        }
        set
        {
            if (value < MinSonicFactor)
            {
                throw new ArgumentException("Harvester is not registered, because of it's SonicFactor");
            }
            this.sonicFactor = value;
        }
    }

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = InitializedEnergyRequirement(energyRequirement, sonicFactor);
        this.SonicFactor = sonicFactor;
    }

    private double InitializedEnergyRequirement(double energyRequirement, int sonicFactor)
    {
        double result = energyRequirement / sonicFactor;
        return result;
    }

    public override string ToString()
    {
        return $"Sonic Harvester - {this.Id}" + Environment.NewLine +
               $"Ore Output: {this.OreOutput}" + Environment.NewLine +
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}

