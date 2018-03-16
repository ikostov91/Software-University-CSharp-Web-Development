using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        GetAnimals getAn = new GetAnimals();

        List<Animal> allAnimals = new List<Animal>();

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] animalInfo = command.Split(new char[] {' '}, StringSplitOptions.None).ToArray();

            Animal animal = null;

            switch (animalInfo[0])
            {
                case "Hen":
                    animal = getAn.GetHen(animalInfo);
                    break;
                case "Owl":
                    animal = getAn.GetOwl(animalInfo);
                    break;
                case "Mouse":
                    animal = getAn.GetMouse(animalInfo);
                    break;
                case "Cat":
                    animal = getAn.GetCat(animalInfo);
                    break;
                case "Dog":
                    animal = getAn.GetDog(animalInfo);
                    break;
                case "Tiger":
                    animal = getAn.GetTiger(animalInfo);
                    break;
            }

            allAnimals.Add(animal);

            Console.WriteLine(animal.ProduceSound());

            string[] foodInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToArray();
            Food food = null;

            switch (foodInfo[0])
            {
                case "Vegetable":
                    food = new Vegetable(int.Parse(foodInfo[1]));
                    break;
                case "Fruit":
                    food = new Fruit(int.Parse(foodInfo[1]));
                    break;
                case "Meat":
                    food = new Meat(int.Parse(foodInfo[1]));
                    break;
                case "Seeds":
                    food = new Seeds(int.Parse(foodInfo[1]));
                    break;
            }

            if (!animal.EdibleFoods.Contains(foodInfo[0].ToLower()))
            {
                Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                animal.FoodEaten += food.Quantity;
                animal.IncreaseWeight(food.Quantity);
            }

            command = Console.ReadLine();
        }

        foreach (var animal in allAnimals)
        {
            Console.WriteLine(animal.ToString());
        }
    }
}

