using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleService
{
    class Car : Vehicle
    {
        public Car(int consumption) : base(4, consumption)
        {
            this.Consumption = consumption;
        }

        public override string ToString()
        {
            return "This is car.";
        }
    }
}
