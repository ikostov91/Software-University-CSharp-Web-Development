using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput = InitializedEnergyOutput(energyOutput);
    }

    private double InitializedEnergyOutput(double energyOutput)
    {
        double result = energyOutput + (energyOutput * 0.5);
        return result;
    }

    public override string ToString()
    {
        return $"Pressure Provider - {this.Id}" + Environment.NewLine +
               $"Energy Output: {this.EnergyOutput}";
    }
}

