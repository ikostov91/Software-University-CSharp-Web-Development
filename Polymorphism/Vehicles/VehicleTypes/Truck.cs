using System;

    public class Truck : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption + 1.6; }
            set { this.fuelConsumption = value; }
        }

        public override void Refuel(double fuel)
        {
            //Console.WriteLine($"Fuel: {fuel * 0.95}");
            this.fuelQuantity += fuel * 0.95;
        }

        public override void Drive(double distance)
        {
            string result = string.Empty;

            if (distance <= this.GetDistance())
            {
                this.fuelQuantity -= distance * this.FuelConsumption;
                result = $"{this.GetType().Name}" + " travelled " + $"{distance} km";
            }
            else
            {
                result = $"{this.GetType().Name} needs refueling";
            }

            Console.WriteLine(result);
        }

        public override double GetDistance()
        {
            double kilometers = this.fuelQuantity / this.FuelConsumption;
            return kilometers;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
