using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Feline
{
    private string[] edibleFoods = { "vegetable", "meat" };

    public Cat(string name, double weight, int foodEaten, string livingRegion, string breed)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = foodEaten;
        this.LivingRegion = livingRegion;
        this.Breed = breed;
    }

    public override void IncreaseWeight(int quantity)
    {
        this.Weight += quantity * 0.30;
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
        return base.ProduceSound() + "Meow";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

