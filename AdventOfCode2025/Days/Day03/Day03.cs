using System;
using System.IO;

namespace AdventOfCode2025.Days
{
    public static class Day03
    {
        public static void Run()
        {
            string inputPath = Path.Combine("Days", "Day03", "input.txt");
            string[] input = File.ReadAllLines(inputPath);

            string part1Result = SolvePart1(input);
            string part2Result = SolvePart2(input);

            Console.WriteLine($"Day 03 - Part 1: {part1Result}");
            Console.WriteLine($"Day 03 - Part 2: {part2Result}");
        }

        // -------------------------------
        // Part 1: 
        // -------------------------------
        private static string SolvePart1(string[] input)
        {
            foreach (var line in input)
            {
                Console.WriteLine(line);
            }

            return "Blank";
        }

        // -------------------------------
        // Part 2: 
        // -------------------------------
        private static string SolvePart2(string[] input)
        {
            return "Blank";
        }

        // -------------------------------
        // Helpers
        // -------------------------------
        
        
    }
}
