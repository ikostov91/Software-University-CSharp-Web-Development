using System;
using System.Collections.Generic;
using System.Text;

public class Pizza
{
    private const int MinToppingsCount = 0;
    private const int MaxToppingsCount = 10;

    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == String.Empty || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }

    public Pizza(string name)
    {
        this.Name = name;
        toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count == 10)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MinToppingsCount}..{MaxToppingsCount}].");
        }
        toppings.Add(topping);   
    }

    public int NumberOfToppings()
    {
        return this.toppings.Count;
    }

    public double TotalCalories()
    {
        double toppingsTotalCalories = 0;

        foreach (var topping in toppings)
        {
            toppingsTotalCalories += topping.Calories();
        }

        return this.Dough.Calories() + toppingsTotalCalories;
    }
}

