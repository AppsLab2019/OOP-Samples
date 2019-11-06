using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VehicleService
{
    class Bus : Vehicle
    {
        private IList stopList;

        public Bus(int consumption) : base(6, consumption)
        {
            this.NumberOfWheels = 6;
            this.Consumption = consumption;
        }

        public void AddStop() { }
        public void RemoveStop() { }

        public override string ToString()
        {
            return "This is bus.";
        }
    }
}
