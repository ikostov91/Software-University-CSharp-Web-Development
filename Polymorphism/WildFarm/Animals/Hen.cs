using System;
using System.Collections.Generic;
using System.Text;

public class Hen : Bird
{

    private string[] edibleFoods = { "vegetable", "fruit", "meat", "seeds" };

    public Hen(string name, double weight, int foodEaten, double wingSize)
    {
        base.Name = name;
        base.Weight = weight;
        base.FoodEaten = foodEaten;
        base.WingSize = wingSize;
    }

    public override void IncreaseWeight(int quantity)
    {
        base.Weight += quantity *  0.35;
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
        return base.ProduceSound() + "Cluck";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

