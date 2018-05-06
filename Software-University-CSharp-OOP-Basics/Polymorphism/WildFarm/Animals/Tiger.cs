using System;
using System.Collections.Generic;
using System.Text;

public class Tiger : Feline
{
    private string[] edibleFoods = { "meat" };

    public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed)
    {
        base.Name = name;
        base.Weight = weight;
        base.FoodEaten = foodEaten;
        base.LivingRegion = livingRegion;
        base.Breed = breed;
    }

    public override void IncreaseWeight(int quantity)
    {
        base.Weight += quantity * 1.00;
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
        return base.ProduceSound() + "ROAR!!!";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

