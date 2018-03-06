using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private const int BaseCaloriesPerGram = 2;
    private const int MinWeight = 1;
    private const int MaxWeight = 50;

    private string name;
    private double weight;

    private Dictionary<string, double> toppingTypes = new Dictionary<string, double>
    {
        {"meat",    1.2},
        {"veggies", 0.8},
        {"cheese",  1.1},
        {"sauce",   0.9}
    };

    private string Name
    {
        get { return this.name; }
        set
        {
            if (!toppingTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.name = value;
        }
    }

    private double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"{this.Name} weight should be in the range [{MinWeight}..{MaxWeight}].");                
            }
            this.weight = value;
        }
    }

    public Topping(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public double Calories()
    {
        double toppingModifier = toppingTypes[this.Name.ToLower()];

        return this.Weight * BaseCaloriesPerGram * toppingModifier;
    }
}

