using System;
using System.IO;

namespace AdventOfCode2025.Days;

public static class Day01
{
    public static void Run()
    {
        string inputPath = Path.Combine("Days", "Day01", "input.txt");
        string[] input = File.ReadAllLines(inputPath);
        int dial = 50;
        int zeroIncrement = 0;

        for (int i = 0; i < input.Length; i++)
        {
            string current = input[i];
            char direction = current[0];
            string distancePart = current.Substring(1);
            int distance = int.Parse(distancePart);

            if (direction == 'R')
            {
                dial = (dial + distance) % 100;
                zeroIncrement = CheckIfZero(dial, zeroIncrement);
            }

            if (direction == 'L')
            {
                dial = (dial - distance + 100) % 100; // ensure positive modulo
                zeroIncrement = CheckIfZero(dial, zeroIncrement);
            }
        }

        Console.WriteLine("Password is " + zeroIncrement);


    }

    private static int CheckIfZero(int dial, int increment)
    {
        if (dial == 0)
        {
            increment += 1;
        }
        
        return increment;
    }
}