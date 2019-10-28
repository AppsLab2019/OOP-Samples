using System;

namespace Sample_02.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var zoo = new Zoo();
            Console.WriteLine("Press CTRL+C to exit.");

            while (true)
            {
                zoo.Update();
                Console.WriteLine("Which animal would you like to feed?");
                string input = Console.ReadLine();
                zoo.Feed(input, 3);
            }
        }
    }
}
