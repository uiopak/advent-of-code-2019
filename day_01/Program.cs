using System;
using System.IO;

namespace day_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input");
            int totalFuelPartOne = 0;
            int totalFuelPartTwo = 0;
            foreach (var line in input)
            {
                int mass = int.Parse(line);
                int rocketFuel = ((mass / 3) - 2);
                totalFuelPartOne += rocketFuel;
                totalFuelPartTwo += rocketFuel;
                while (true)
                {
                    rocketFuel = ((rocketFuel / 3) - 2);
                    if (rocketFuel>0)
                    {
                        totalFuelPartTwo += rocketFuel;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"Total fuel part one: {totalFuelPartOne}");
            Console.WriteLine($"Total fuel part two: {totalFuelPartTwo}");
        }
    }
}
