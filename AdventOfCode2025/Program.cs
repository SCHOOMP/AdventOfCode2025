using System;
using AdventOfCode2025.Days;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter day (1-25): ");
        int day = int.Parse(Console.ReadLine()!);

        switch (day)
        {
            case 1: Day01.Run(); break;
           
            // ...
            // case 25: Day25.Run(); break;
            default: Console.WriteLine("Invalid day"); break;
        }
    }
}