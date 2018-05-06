using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

public class Dough
{
    private const int BaseCaloriesPerGram = 2;
    private const int MinWeight = 1;
    private const int MaxWeigth = 200;

    private static Dictionary<string, double> flourModifiers = new Dictionary<string, double>
    {
        {"white",      1.5},
        {"wholegrain", 1.0}
    };

    private static Dictionary<string, double> bakingModifiers = new Dictionary<string, double>
    {
        {"crispy",   0.9},
        {"chewy",    1.1},
        {"homemade", 1.0}
    };

    private string flourType;
    private string bakingTechnique;
    private double weight;

    private string FlourType
    {
        get { return this.flourType; }
        set
        {
            if (!flourModifiers.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }

    private string BakingTechnique
    {
        get { return this.bakingTechnique; }
        set
        {
            if (!bakingModifiers.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    private double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < MinWeight || value > MaxWeigth)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeigth}].");
            }
            this.weight = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double Calories()
    {
        double flourModifier = flourModifiers[this.FlourType.ToLower()];
        double bakingModifier = bakingModifiers[this.BakingTechnique.ToLower()];

        return BaseCaloriesPerGram * this.Weight * flourModifier * bakingModifier;
    }
}

