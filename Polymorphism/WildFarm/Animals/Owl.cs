using System;
using System.Collections.Generic;
using System.Text;

public class Owl : Bird
{
    private string[] edibleFoods = { "meat" };

    public Owl(string name, double weight, int foodEaten, double wingSize)
    {
        base.Name = name;
        base.Weight = weight;
        base.FoodEaten = foodEaten;
        base.WingSize = wingSize;
    }

    public override void IncreaseWeight(int quantity)
    {
        base.Weight += quantity * 0.25;
    }

    public override string[] EdibleFoods
    {
        get
        {
            return this.edibleFoods;
        }
    }

    public override string ProduceSound()
    {
        return base.ProduceSound() + "Hoot Hoot";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

