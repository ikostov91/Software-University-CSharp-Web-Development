using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bird : Animal
{
    private double wingSize;

    public double WingSize
    {
        get
        {
            return this.wingSize;
        }
        set
        {
            this.wingSize = value;
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
