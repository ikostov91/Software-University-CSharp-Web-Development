using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Mammal
{
    private string[] edibleFoods = { "meat" };

    public Dog(string name, double weight, int foodEaten, string livingRegion)
    {
        base.Name = name;
        base.Weight = weight;
        base.FoodEaten = foodEaten;
        base.LivingRegion = livingRegion;
    }

    public override void IncreaseWeight(int quantity)
    {
        base.Weight += quantity * 0.40;
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
        return base.ProduceSound() + "Woof!";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

