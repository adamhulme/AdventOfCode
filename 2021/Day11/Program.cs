using System;
using System.IO;
using System.Linq;

namespace Day11
{
    class Program
    {
        public static int flashed = 0;
        public int[,] FlashAllNeighbours(int[,] grid, int x, int y)
        {
            return grid;
        }

        /*public int[,] IncrementAll(int[,] grid)
        {
            foreach (var row in grid)
            {
                foreach (var col in row)
                {

                }
            }
        }*/

        public static int[,] ConvertToInt(string[] grid)
        {
            var intg = new int[grid.Length, grid[0].Length];
            for (int i=0; i < grid.Length; i++)
            {
                for (int j=0; j<grid[0].Length; j++)
                {
                    intg[i, j] = (int) char.GetNumericValue(grid[i][j]);
                }
            }
            return intg;
        }

        static void Main(string[] args)
        {
            var grid = File.ReadAllLines(@"C:\Projects\AoCgithub\AdventOfCode\Day11\day11.txt");
            int[,] nums = ConvertToInt(grid);
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    Console.Write(nums[i, j]);
                }
                Console.WriteLine();
            }
            for (int i=0; i<100; i++)
            {

            }
        }
    }
}
