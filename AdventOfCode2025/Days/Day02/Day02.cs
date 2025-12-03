using System;
using System.IO;

namespace AdventOfCode2025.Days;

public static class Day02
{
    public static void Run()
    {
        string inputPath = Path.Combine("Days", "Day02", "input.txt");
        string[] input = File.ReadAllLines(inputPath);

        String part1Result = SolvePart1(input);
        String part2Result = SolvePart2(input);

        Console.WriteLine($"Day 02 - Part 1: {part1Result}");
        Console.WriteLine($"Day 02 - Part 2: {part2Result}");
    }

    // Part 1: implement puzzle logic here
    private static String SolvePart1(string[] input)
    {
        // TODO: Replace with actual logic
        return "Hello World";
    }

    // Part 2: implement puzzle logic here
    private static String SolvePart2(string[] input)
    {
        return "Hello World";
    }
}