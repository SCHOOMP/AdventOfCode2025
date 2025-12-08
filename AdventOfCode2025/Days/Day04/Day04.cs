using System;
using System.IO;

namespace AdventOfCode2025.Days
{
    public static class Day04
    {
        public static void Run()
        {
            string inputPath = Path.Combine("Days", "Day04", "input.txt");
            string[] input = File.ReadAllLines(inputPath);

            long part1Result = SolvePart1(input);
            long part2Result = SolvePart2(input);

            Console.WriteLine($"Day 04 - Part 1: {part1Result}");
            Console.WriteLine($"Day 04 - Part 2: {part2Result}");
        }

        // -------------------------------
        // Part 1
        // -------------------------------
        private static long SolvePart1(string[] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            // Directions for 8 neighbors:
            // (dr, dc): row offset, column offset
            int[,] directions =
            {
                { -1, -1 }, { -1, 0 }, { -1, 1 },
                {  0, -1 },           {  0, 1 },
                {  1, -1 }, {  1, 0 }, {  1, 1 }
            };

            long accessible = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] != '@')
                        continue;

                    int neighbors = 0;

                    // Count '@' neighbors
                    for (int d = 0; d < 8; d++)
                    {
                        int nr = r + directions[d, 0];
                        int nc = c + directions[d, 1];

                        if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                        {
                            if (grid[nr][nc] == '@')
                                neighbors++;
                        }
                    }

                    if (neighbors < 4)
                        accessible++;
                }
            }

            return accessible;
        }

        // -------------------------------
        // Part 2 (placeholder)
        // -------------------------------
        private static long SolvePart2(string[] input)
        {
            int rows = input.Length;
            int cols = input[0].Length;

            // Convert to mutable grid
            char[,] grid = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                grid[r, c] = input[r][c];

            int totalRemoved = 0;

            while (true)
            {
                var toRemove = new List<(int r, int c)>();

                // Find all accessible rolls
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < cols; c++)
                    {
                        if (grid[r, c] != '@')
                            continue;

                        int neighbors = CountNeighbors(grid, r, c, rows, cols);

                        if (neighbors < 4)
                            toRemove.Add((r, c));
                    }
                }

                if (toRemove.Count == 0)
                    break;  // no more deletions possible

                // Remove them
                foreach (var (r, c) in toRemove)
                    grid[r, c] = '.';

                totalRemoved += toRemove.Count;
            }

            return totalRemoved;
        }

// Helper: count '@' neighbors
        private static int CountNeighbors(char[,] grid, int r, int c, int rows, int cols)
        {
            int count = 0;
            int[,] dirs = {
                { -1,-1 }, { -1,0 }, { -1,1 },
                { 0,-1 },            { 0,1 },
                { 1,-1 }, { 1,0 }, { 1,1 }
            };

            for (int i = 0; i < 8; i++)
            {
                int nr = r + dirs[i, 0];
                int nc = c + dirs[i, 1];

                if (nr >= 0 && nr < rows && nc >= 0 && nc < cols)
                {
                    if (grid[nr, nc] == '@')
                        count++;
                }
            }

            return count;
        }

    }
}
