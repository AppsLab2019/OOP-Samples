using System;
using System.Collections.Generic;

namespace VehicleService
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle v1 = new Bus(8);
            Vehicle v2 = new Car(6);

            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(v1);
            vehicles.Add(v2);

            foreach (Vehicle v in vehicles)
            {
                if (v is Car)
                {
                    Console.WriteLine("This is a car.");
                }
                else if (v is Bus)
                {
                    Console.WriteLine("This is a bus.");
                }
                else
                {
                    Console.WriteLine("Unknown type of vehicle.");
                }
            }

            //Console.WriteLine(v1.ToString());
            //Console.WriteLine(v2.ToString());
        }
    }
}
