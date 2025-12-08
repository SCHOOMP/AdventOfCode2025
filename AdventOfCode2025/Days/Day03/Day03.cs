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

            long part1Result = SolvePart1(input);
            long part2Result = SolvePart2(input);

            Console.WriteLine($"Day 03 - Part 1: {part1Result}");
            Console.WriteLine($"Day 03 - Part 2: {part2Result}");
        }

        // -------------------------------
        // Part 1: 
        // -------------------------------
        private static long SolvePart1(string[] input)
        {
            long total = 0;

            foreach (string line in input)
            {
                int[] digits = line.Select(c => c - '0').ToArray();
                int best = 0;

                for (int i = 0; i < digits.Length; i++)
                {
                    for (int j = i + 1; j < digits.Length; j++)
                    {
                        int value = digits[i] * 10 + digits[j];
                        if (value > best)
                            best = value;
                    }
                }

                total += best;
            }

            return total;
        }
        
        // -------------------------------
        // Part 2: 
        // -------------------------------
        private static long SolvePart2(string[] input)
        {
            const int K = 12;
            long total = 0;

            foreach (string line in input)
            {
                var digits = line.Select(c => c - '0').ToArray();
                int drop = digits.Length - K;

                List<int> stack = new List<int>(digits.Length);

                foreach (int d in digits)
                {
                    while (drop > 0 && stack.Count > 0 && stack[^1] < d)
                    {
                        stack.RemoveAt(stack.Count - 1);
                        drop--;
                    }
                    stack.Add(d);
                }

                // If we didn't drop enough, drop from the end
                while (stack.Count > K)
                    stack.RemoveAt(stack.Count - 1);

                // Convert top 12 digits to a number
                long value = 0;
                for (int i = 0; i < K; i++)
                    value = value * 10 + stack[i];

                total += value;
            }

            return total;
        }


        // -------------------------------
        // Helpers
        // -------------------------------
        
    }
}
