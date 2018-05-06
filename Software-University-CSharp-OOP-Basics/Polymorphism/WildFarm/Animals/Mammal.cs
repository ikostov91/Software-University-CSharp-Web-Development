using System;
using System.Collections.Generic;
using System.Text;

public abstract class Mammal : Animal
{
    private string livingRegion;

    public string LivingRegion
    {
        get
        {
            return this.livingRegion;
        }
        set
        {
            this.livingRegion = value;
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

