using System;
using System.Collections.Generic;
using System.Text;

public abstract class Feline : Mammal
{
    private string breed;

    public string Breed
    {
        get
        {
            return this.breed;
        }
        set
        {
            this.breed = value;
        }
    }

    public override void IncreaseWeight(int quantity)
    {
    }

    public override string[] EdibleFoods { get; }

    public override string ProduceSound()
    {
        return string.Empty;
    }
}

