using System;

    public class Car : Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;

        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption + 0.9; }
            set { this.fuelConsumption = value; }
        }

        public override void Refuel(double fuel)
        {
            this.fuelQuantity += fuel;
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
