using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string systemMode = string.Empty;
    private double totalEnergyStored;
    private double totalOreMined;
    private List<Provider> allProviders;
    private List<Harvester> allHarvesters;
    private HarvesterFactory harvFact;
    private ProviderFactory provFact;

    public DraftManager()
    {
        totalEnergyStored = 0;
        totalOreMined = 0;
        systemMode = "Full";
        this.allHarvesters = new List<Harvester>();
        this.allProviders = new List<Provider>();
        harvFact = new HarvesterFactory();
        provFact = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            harvFact.CreateHarvester(arguments);
        }
        catch (ArgumentException exception)
        {
            return exception.Message; 
        }

        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            provFact.CreateProvider(arguments);
        }
        catch (ArgumentException exception)
        {
            return exception.Message;
        }

        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }

    public string Day()
    {
        double energyProvided = 0;
        double energyModifier = 0;
        double oreModifer = 0;
        double oreMined = 0;

        foreach (var provider in allProviders)
        {
            energyProvided += provider.EnergyOutput;
            
        }
        totalEnergyStored += energyProvided;

        switch (systemMode)
        {
            case "Full":
                energyModifier = 1;
                oreModifer = 1;
                break;
            case "Half":
                energyModifier = 0.6;
                oreModifer = 0.5;
                break;
            case "Energy":
                break;
        }

        double energyRequirement = GetEneryRequirement(allHarvesters) * energyModifier;

        if (totalEnergyStored >= energyRequirement)
        {
            totalEnergyStored -= energyRequirement;
            oreMined = GetOreMined(allHarvesters) * oreModifer;
            totalOreMined += oreMined;
        }

        return "A day has passed." + Environment.NewLine + 
               $"Energy Provided: {energyProvided}" + Environment.NewLine + 
               $"Plumbus Ore Mined: {oreMined}";
    }

    private double GetEneryRequirement(List<Harvester> allHarvesters)
    {
        double energyRequirement = 0;

        foreach (var harvester in allHarvesters)
        {
            energyRequirement += harvester.EnergyRequirement;
        }

        return energyRequirement;
    }

    private double GetOreMined(List<Harvester> alHarvesters)
    {
        double oreMined = 0;

        foreach (var harvester in allHarvesters)
        {
            oreMined += harvester.OreOutput;
        }

        return oreMined;
    }

    public string Mode(List<string> arguments)
    {
        systemMode = arguments[0];
        return $"Successfully changed working mode to {this.systemMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        var currentHarvester = this.allHarvesters.FirstOrDefault(harv => harv.Id == id);
        Provider currentProvider = null;

        if (currentHarvester == null)
        {
            currentProvider = this.allProviders.FirstOrDefault(prov => prov.Id == id);
        }
        else
        {
            return currentHarvester.ToString();
        }

        if (currentProvider == null)
        {
            return $"No element found with id - {id}";
        }

        return currentProvider.ToString();
    }

    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine +
               $"Total Energy Stored: {totalEnergyStored}" + Environment.NewLine +
               $"Total Mined Plumbus Ore: {totalOreMined}";
    }
}

