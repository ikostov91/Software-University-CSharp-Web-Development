using System;

public class Car
{
    private const double MaxFuelCapacity = 160;

    private double fuelAmmount;

    public Car(int hp, double fuelAmmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmmount = fuelAmmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmmount
    {
        get { return this.fuelAmmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ErrorMessages.OutOfFuel);
            }

            this.fuelAmmount = Math.Min(value, MaxFuelCapacity);
        }
    }

    public Tyre Tyre { get; private set; }

    public void ReduceFuel(double burnedFuel)
    {
        this.FuelAmmount -= burnedFuel;
    }

    public void Refuel(double fuelAmmount)
    {
        this.FuelAmmount += fuelAmmount;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}

