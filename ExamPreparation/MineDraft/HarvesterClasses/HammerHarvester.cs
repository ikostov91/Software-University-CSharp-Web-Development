using System;
using System.Collections.Generic;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput = InitializedOreOutput(oreOutput);
        this.EnergyRequirement = InitializedEnergyRequirement(energyRequirement);
    }

    private double InitializedOreOutput(double oreOutput)
    {
        double result = oreOutput * 3;
        return result;
    }

    private double InitializedEnergyRequirement(double energyRequirement)
    {
        double result = energyRequirement * 2;
        return result;
    }

    public override string ToString()
    {
        return $"Hammer Harvester - {this.Id}" + Environment.NewLine + 
               $"Ore Output: {this.OreOutput}" + Environment.NewLine + 
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}


