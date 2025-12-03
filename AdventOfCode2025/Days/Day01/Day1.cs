using System;
using System.IO;

namespace AdventOfCode2025.Days;

public static class Day01
{
    public static void Run()
    {
        string inputPath = Path.Combine("Days", "Day01", "input.txt");
        string[] input = File.ReadAllLines(inputPath);

        int part1Result = SolvePart1(input);
        int part2Result = SolvePart2(input);

        Console.WriteLine($"Day 01 - Part 1: {part1Result}");
        Console.WriteLine($"Day 01 - Part 2: {part2Result}");
    }

    // Part 1: counts dial landing on 0 after each rotation
    private static int SolvePart1(string[] input)
    {
        int dial = 50;
        int zeroCount = 0;

        foreach (string current in input)
        {
            char direction = current[0];
            int distance = int.Parse(current.Substring(1));

            if (direction == 'R')
                dial = (dial + distance) % 100;
            else if (direction == 'L')
                dial = (dial - distance + 100) % 100;

            if (dial == 0)
                zeroCount++;
        }

        return zeroCount;
    }

    // Part 2: counts every time the dial points to 0 during rotations
    private static int SolvePart2(string[] input)
    {
        int dial = 50;
        int zeroCount = 0;

        foreach (string current in input)
        {
            char direction = current[0];
            int distance = int.Parse(current.Substring(1));

            for (int i = 0; i < distance; i++)
            {
                if (direction == 'R')
                    dial = (dial + 1) % 100;
                else if (direction == 'L')
                    dial = (dial - 1 + 100) % 100;

                if (dial == 0)
                    zeroCount++;
            }
        }

        return zeroCount;
    }
}