using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Car
{
    private string model;
    private int engineSpeed;
    private int enginePower;
    private Cargo cargo;
    private List<Tire> tires;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public int EnginePower
    {
        get { return this.enginePower; }
        set { this.enginePower = value; }
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
        set { this.cargo = value; }
    }

    public List<Tire> Tires
    {
        get { return this.tires; }
        set { this.tires = value; }
    }

    public Car(string model, int engineSpeed, int enginePower, Cargo cargo, List<Tire> tires)
    {
        this.model = model;
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
        this.cargo = cargo;
        this.tires = tires;
    }
    
}
