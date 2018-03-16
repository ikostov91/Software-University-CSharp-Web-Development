using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

public class GetAnimals
{
    public Hen GetHen(string[] animalInfo)
    {
        string name = animalInfo[1];
        double weight = double.Parse(animalInfo[2]);
        double wingSize = double.Parse(animalInfo[3]);

        return new Hen(name, weight, 0 , wingSize);
    }

    public Owl GetOwl(string[] animalInfo)
    {
        string name = animalInfo[1];
        double weight = double.Parse(animalInfo[2]);
        double wingSize = double.Parse(animalInfo[3]);

        return new Owl(name, weight, 0, wingSize);
    }

    public Mouse GetMouse(string[] animalInfo)
    {
        string name = animalInfo[1];
        double weight = double.Parse(animalInfo[2]);
        string livingRegion = animalInfo[3];

        return new Mouse(name, weight, 0, livingRegion);
    }

    public Cat GetCat(string[] animalInfo)
    {
        string name = animalInfo[1];
        double weight = double.Parse(animalInfo[2]);
        string livingRegion = animalInfo[3];
        string breed = animalInfo[4];

        return new Cat(name, weight, 0, livingRegion, breed);
    }

    public Dog GetDog(string[] animalInfo)
    {
        string name = animalInfo[1];
        double weight = double.Parse(animalInfo[2]);
        string livingRegion = animalInfo[3];

        return new Dog(name, weight, 0, livingRegion);
    }

    public Tiger GetTiger(string[] animalInfo)
    {
        string name = animalInfo[1];
        double weight = double.Parse(animalInfo[2]);
        string livingRegion = animalInfo[3];
        string breed = animalInfo[4];

        return new Tiger(name, weight, 0, livingRegion, breed);
    }
}

