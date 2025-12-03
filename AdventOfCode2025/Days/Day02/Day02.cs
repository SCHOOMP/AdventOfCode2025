using System;
using System.IO;

namespace AdventOfCode2025.Days
{
    public static class Day02
    {
        public static void Run()
        {
            string inputPath = Path.Combine("Days", "Day02", "input.txt");
            string[] input = File.ReadAllLines(inputPath);

            string part1Result = SolvePart1(input);
            string part2Result = SolvePart2(input);

            Console.WriteLine($"Day 02 - Part 1: {part1Result}");
            Console.WriteLine($"Day 02 - Part 2: {part2Result}");
        }

        // -------------------------------
        // Part 1: only two halves repeated
        // -------------------------------
        private static string SolvePart1(string[] input)
        {
            long total = 0;

            foreach (string line in input)
            {
                string[] ranges = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string range in ranges)
                {
                    string[] parts = range.Split('-');
                    long start = long.Parse(parts[0]);
                    long end = long.Parse(parts[1]);

                    for (long i = start; i <= end; i++)
                    {
                        if (IsInvalidIdPart1(i))
                        {
                            total += i;
                        }
                    }
                }
            }

            return total.ToString();
        }

        // -------------------------------
        // Part 2: any substring repeated ≥ 2
        // -------------------------------
        private static string SolvePart2(string[] input)
        {
            long total = 0;

            foreach (string line in input)
            {
                string[] ranges = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string range in ranges)
                {
                    string[] parts = range.Split('-');
                    long start = long.Parse(parts[0]);
                    long end = long.Parse(parts[1]);

                    for (long i = start; i <= end; i++)
                    {
                        if (IsInvalidIdPart2(i))
                        {
                            total += i;
                        }
                    }
                }
            }

            return total.ToString();
        }

        // -------------------------------
        // Helpers
        // -------------------------------

        // Part 1 rule: even-length string, two identical halves
        private static bool IsInvalidIdPart1(long number)
        {
            string s = number.ToString();
            int len = s.Length;

            if (len % 2 != 0) return false;

            string firstHalf = s.Substring(0, len / 2);
            string secondHalf = s.Substring(len / 2);

            return firstHalf == secondHalf;
        }

        // Part 2 rule: any substring repeated at least twice
        private static bool IsInvalidIdPart2(long number)
        {
            string s = number.ToString();
            int len = s.Length;

            for (int subLen = 1; subLen <= len / 2; subLen++)
            {
                if (len % subLen != 0) continue;

                string pattern = s.Substring(0, subLen);
                string rebuilt = string.Concat(Enumerable.Repeat(pattern, len / subLen));

                if (rebuilt == s && len / subLen >= 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
