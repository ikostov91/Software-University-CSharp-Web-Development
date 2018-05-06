using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get { return this.money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public List<Product> Products
    {
        get { return this.products; }
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public bool AttemptToBuyProduct(Product product)
    {
        if (product.Cost > this.Money)
        {
            
            return false;
        }

        this.products.Add(product);
        this.Money -= product.Cost;
        return true;
        
    }
}

