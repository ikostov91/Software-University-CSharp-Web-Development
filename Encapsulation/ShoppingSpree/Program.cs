using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<Person> allPersons = Methods.GetPeople();
            List<Product> allProducts = Methods.GetProducts();

            Methods.BuyProducst(allPersons, allProducts);
            Methods.PrintPersons(allPersons);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
