using System;

namespace Sample_02.Animals
{
    class Animal
    {
        public Animal(string name, string type, int healthPoints, int food)
        {
            Name = name;
            Type = type;
            HealthPoints = healthPoints;
            Food = food;
        }

        public string Name { get; }
        public string Type { get; }
        public int HealthPoints { get; set; }
        public int Food { get; set; }

        public void Update()
        {
            if (HealthPoints <= 0) return;
            Food--;
            if (Food <= 0)
            {
                HealthPoints--;
                if (HealthPoints > 0)
                {
                    Console.WriteLine($"{Name} is starving.");
                }
                else
                {
                    Console.WriteLine($"{Name} starved to death.");
                    HealthPoints = 0;
                }

                Food = 0;
            }
        }

        public void Eat(int amount)
        {
            Food += amount;
        }
    }
}