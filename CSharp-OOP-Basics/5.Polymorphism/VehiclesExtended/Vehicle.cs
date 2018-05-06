using System;

    public abstract class Vehicle
    {
        public virtual bool AirConditioner { get; set; }

        public abstract void Refuel(double fuel);

        public abstract void Drive(double distance);

        public abstract double GetDistance();

        public abstract override string ToString();
    }
