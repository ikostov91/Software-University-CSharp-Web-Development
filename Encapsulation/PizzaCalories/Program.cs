using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPizza = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();
            string[] inputDough = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();

            Pizza pizza = new Pizza(inputPizza[1]);
            Dough dough = new Dough(inputDough[1], inputDough[2], double.Parse(inputDough[3]));
            pizza.Dough = dough;

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] inputTopping = command.Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();
                Topping topping = new Topping(inputTopping[1], double.Parse(inputTopping[2]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} Calories.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

