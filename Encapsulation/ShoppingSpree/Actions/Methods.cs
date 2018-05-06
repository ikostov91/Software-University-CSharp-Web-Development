using System;
using System.Collections.Generic;
using System.Linq;

public class Methods
{
    internal static void PrintPersons(List<Person> allPersons)
    {
        foreach (var person in allPersons)
        {
            string personInfo = person.Name + " - ";
            if (person.Products.Count == 0)
            {
                personInfo += "Nothing bought";
            }
            else
            {
                personInfo += (string.Join(", ", person.Products.Select(n => n.Name)));
            }
            Console.WriteLine(personInfo);
        }
    }

    internal static void BuyProducst(List<Person> allPersons, List<Product> allProducts)
    {
        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split();
            string inputPerson = commandArgs[0];
            string inputProduct = commandArgs[1];

            Person person = allPersons.Single(n => n.Name == inputPerson);
            Product product = allProducts.Single(n => n.Name == inputProduct);

            if (!person.AttemptToBuyProduct(product))
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
        }
    }

    internal static List<Person> GetPeople()
    {
        string[] personsInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        List<Person> allPersons = new List<Person>();
        foreach (var value in personsInput)
        {
            string[] nameMoney = value.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(nameMoney[0], decimal.Parse(nameMoney[1]));
            allPersons.Add(person);
        }

        return allPersons;
    }

    internal static List<Product> GetProducts()
    {
        string[] productsInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        List<Product> allProducts = new List<Product>();
        foreach (var value in productsInput)
        {
            string[] nameCost = value.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            Product product = new Product(nameCost[0], decimal.Parse(nameCost[1]));
            allProducts.Add(product);
        }

        return allProducts;
    }
}