using System;
using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SalesDbContext context = new SalesDbContext())
            {
                Customer customer = new Customer()
                {
                    Name = "Ivaylo Kostov",
                    Email = "i.kostov@net.bg",
                    CreditCardNumber = "ABCD1234"
                };

                context.Customers.Add(customer);

                Product[] products = new Product[]
                {
                    new Product() {Name = "Aspirin", Description = "Medicament", Quantity = 5, Price = 25.0m },
                    new Product() {Name = "Bike", Quantity = 1, Price = 250.0m },
                    new Product() {Name = "Coca-Cola", Description = "Beverage", Quantity = 25, Price = 1.50m }
                };

                foreach (var product in products)
                {
                    context.Products.Add(product);
                }

                Store store = new Store()
                {
                    Name = "HIT Mladost"
                };

                context.Stores.Add(store);

                Sale[] sales = 
                {
                    new Sale() { Date = DateTime.Parse("5/11/2015"), ProductId = 1, CustomerId = 1, StoreId = 1},
                    new Sale() { ProductId = 2, CustomerId = 1, StoreId = 1} 
                };

                foreach (var sale in sales)
                {
                    context.Sales.Add(sale);
                }

                context.SaveChanges();
            }
        }
    }
}
