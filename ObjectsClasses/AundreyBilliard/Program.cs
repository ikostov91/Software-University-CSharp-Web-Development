using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AundreyBilliard
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> shopEntities = new Dictionary<string, decimal>();
            List<Customer> customers = new List<Customer>();

            int entities = int.Parse(Console.ReadLine());
            shopEntities = FillShop(entities, shopEntities);

            string input = Console.ReadLine();

            while (input != "end of clients")
            {
                string[] currentClient = input.Split('-', ',').ToArray();

                string name = currentClient[0];
                string order = currentClient[1];
                int ammount = int.Parse(currentClient[2]);

                if (!shopEntities.ContainsKey(order))
                {
                    input = Console.ReadLine();
                    continue;
                }

                Customer customer = new Customer();

                customer.Name = name;
                customer.Orders = new Dictionary<string, int>();
                customer.Orders.Add(order, ammount);

                if (customers.Any(c => c.Name == name))
                {
                    Customer existingCustomer = customers.First(c => c.Name == name);

                    if (existingCustomer.Orders.ContainsKey(order))
                    {
                        existingCustomer.Orders[order] += ammount;
                    }
                    else
                    {
                        existingCustomer.Orders[order] = ammount;
                    }

                }
                else
                {
                    customers.Add(customer);
                }

                input = Console.ReadLine();
            }

            foreach (var customer in customers)
            {
                foreach (var order in customer.Orders)
                {
                    foreach (var product in shopEntities)
                    {
                        if (order.Key == product.Key)
                        {
                            customer.Bill += order.Value * product.Value;
                        }
                    }
                }
            }

            customers = customers.OrderBy(x => x.Name).ThenBy(x => x.Bill).ToList();

            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.Name);

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"-- {order.Key} - {order.Value}");
                }

                Console.WriteLine($"Bill: {customer.Bill:F2}");
            }

            Console.WriteLine($"Total bill: {customers.Sum(x => x.Bill):F2}");
        }

        private static Dictionary<string, decimal> FillShop(int entities, Dictionary<string, decimal> shopEntities)
        {
            for (int i = 0; i < entities; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();
                string name = input[0];
                decimal price = decimal.Parse(input[1]);

                if (shopEntities.ContainsKey(name))
                {
                    shopEntities[name] = price;
                }
                else
                {
                    shopEntities.Add(name, price);
                }
            }

            return shopEntities;
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> Orders { get; set; }
        public decimal Bill { get; set; }
    }
}
