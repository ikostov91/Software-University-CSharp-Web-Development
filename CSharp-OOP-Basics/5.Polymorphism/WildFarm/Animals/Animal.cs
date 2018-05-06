using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            this.weight = value;
        }
    }

    public int FoodEaten
    {
        get
        {
            return this.foodEaten;
        }
        set
        {
            this.foodEaten = value;
        }
    }

    public abstract void IncreaseWeight(int quantity);

    public abstract string[] EdibleFoods { get; }

    public abstract string ProduceSound();
}

