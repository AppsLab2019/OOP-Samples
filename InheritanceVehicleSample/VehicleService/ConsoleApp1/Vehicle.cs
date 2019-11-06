using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleService
{
    class Vehicle
    {
        public Vehicle(int numberOfWheels, int consumption)
        {
            this.NumberOfWheels = numberOfWheels;
            this.Consumption = consumption;
        }

        public int NumberOfWheels { get; protected set; }
        public int Consumption { get; protected set; }
        public double ActualFuelCapacity { get; private set; }

        public void UpdateBusActualFuelCapacity(double distancePassed)
        {
            this.ActualFuelCapacity -= distancePassed / this.Consumption;
        }

        public override string ToString()
        {
            return "This is a vehicle.";
        }
    }
}
