using System;
using AdventOfCode2025.Days;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter day (1-25):");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int day) && day >= 1 && day <= 25)
        {
            Console.WriteLine(); // spacing before output

            switch (day)
            {
                case 1: Day01.Run(); break;
                case 2: Day02.Run(); break;
                case 3: Day03.Run(); break;
                case 4: Day04.Run(); break;
                // ...
                default: Console.WriteLine("Day not implemented."); break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input, try again.");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
