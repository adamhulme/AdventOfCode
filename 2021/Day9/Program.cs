using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day9
{
    class Coord
    {
        public Coord(int r, int c)
        {
            Row = r;
            Col = c;
        }
        public int Row;
        public int Col;

        public int GetGridVal(string[] grid)
        {
            return (int)char.GetNumericValue(grid[Row][Col]);
        }
    }
    class Program
    {
        public List<Coord> ExploreAllAdjacent(Coord center, string[] grid, List<Coord> basin)
        {
            var above = new Coord(center.Row - 1, center.Col);
            var below = new Coord(center.Row + 1, center.Col);
            var left = new Coord(center.Row, center.Col - 1);
            var right = new Coord(center.Row, center.Col + 1);
            if (above.Row >= 0)
            {
                if (above.GetGridVal(grid) != 9 && !basin.Any(c => c.Row == above.Row && c.Col == above.Col))
                {
                    basin.Add(above);
                    basin = ExploreAllAdjacent(above, grid, basin);
                }
            }
            if (below.Row < grid.Length)
            {
                if (below.GetGridVal(grid) != 9 && !basin.Any(c => c.Row == below.Row && c.Col == below.Col))
                {
                    basin.Add(below);
                    basin = ExploreAllAdjacent(below, grid, basin);
                }
            }
            if (left.Col >= 0)
            {
                if (left.GetGridVal(grid) != 9 && !basin.Any(c => c.Row == left.Row && c.Col == left.Col))
                {
                    basin.Add(left);
                    basin = ExploreAllAdjacent(left, grid, basin);
                }
            }
            if (right.Col < grid[0].Length)
            {
                if (right.GetGridVal(grid) != 9 && !basin.Any(c => c.Row == right.Row && c.Col == right.Col))
                {
                    basin.Add(right);
                    basin = ExploreAllAdjacent(right, grid, basin);
                }
            }
            return basin;
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var grid = File.ReadAllLines(@"C:\Projects\AoCgithub\AdventOfCode\Day9\Day9\day9.txt");
            var lowCount = 0;
            var rowlen = grid[0].Length - 1;
            var collen = grid.Length - 1;

            var maxbas = -1;
            var max2bas = -1;
            var max3bas = -1;

            // Check top left
            var current = grid[0][0];
            Coord c = new Coord(0, 0);
            if (current < grid[0][1] && current < grid[1][0])
            {
                lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                if (basinSize > maxbas)
                {
                    max3bas = max2bas;
                    max2bas = maxbas;
                    maxbas = basinSize;
                }
                else if (basinSize > max2bas)
                {
                    max3bas = max2bas;
                    max2bas = basinSize;
                
                }
                else if (basinSize > max3bas)
                {
                    max3bas = basinSize;
                }
            }

            // Check top right
            current = grid[0][rowlen];
            c = new Coord(0, rowlen);
            if (current < grid[0][rowlen - 1] && current < grid[1][rowlen])
            {
                lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                if (basinSize > maxbas)
                {
                    max3bas = max2bas;
                    max2bas = maxbas;
                    maxbas = basinSize;
                }
                else if (basinSize > max2bas)
                {
                    max3bas = max2bas;
                    max2bas = basinSize;

                }
                else if (basinSize > max3bas)
                {
                    max3bas = basinSize;
                }
            }

            // Check bot left
            current = grid[collen][0];
            c = new Coord(collen, 0);
            if (current < grid[collen - 1][0] && current < grid[collen][1])
            {
                lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                if (basinSize > maxbas)
                {
                    max3bas = max2bas;
                    max2bas = maxbas;
                    maxbas = basinSize;
                }
                else if (basinSize > max2bas)
                {
                    max3bas = max2bas;
                    max2bas = basinSize;

                }
                else if (basinSize > max3bas)
                {
                    max3bas = basinSize;
                }
            }

            // Check bot right
            current = grid[collen][rowlen];
            c = new Coord(collen, rowlen);
            if (current < grid[collen - 1][rowlen] && current < grid[collen][rowlen - 1])
            {
                lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                if (basinSize > maxbas)
                {
                    max3bas = max2bas;
                    max2bas = maxbas;
                    maxbas = basinSize;
                }
                else if (basinSize > max2bas)
                {
                    max3bas = max2bas;
                    max2bas = basinSize;

                }
                else if (basinSize > max3bas)
                {
                    max3bas = basinSize;
                }
            }

            // Check top row
            for (int i = 1; i < rowlen; i++)
            {
                current = grid[0][i];
                c = new Coord(0, i);
                if (current < grid[0][i - 1] && current < grid[0][i + 1] && current < grid[1][i])
                {
                    lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                    var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                    if (basinSize > maxbas)
                    {
                        max3bas = max2bas;
                        max2bas = maxbas;
                        maxbas = basinSize;
                    }
                    else if (basinSize > max2bas)
                    {
                        max3bas = max2bas;
                        max2bas = basinSize;

                    }
                    else if (basinSize > max3bas)
                    {
                        max3bas = basinSize;
                    }
                }
            }

            // Check bot row
            for (int i = 1; i < rowlen; i++)
            {
                current = grid[collen][i];
                c = new Coord(collen, i);
                if (current < grid[collen][i - 1] && current < grid[collen][i + 1] && current < grid[collen - 1][i])
                {
                    lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                    var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                    if (basinSize > maxbas)
                    {
                        max3bas = max2bas;
                        max2bas = maxbas;
                        maxbas = basinSize;
                    }
                    else if (basinSize > max2bas)
                    {
                        max3bas = max2bas;
                        max2bas = basinSize;

                    }
                    else if (basinSize > max3bas)
                    {
                        max3bas = basinSize;
                    }
                }
            }

            // Now check remaining rows
            for (int i=1; i<collen; i++)
            {
                // Check row start
                current = grid[i][0];
                c = new Coord(i, 0);
                if (current < grid[i-1][0] && current < grid[i+1][0] && current < grid[i][1])
                {
                    lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                    var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                    if (basinSize > maxbas)
                    {
                        max3bas = max2bas;
                        max2bas = maxbas;
                        maxbas = basinSize;
                    }
                    else if (basinSize > max2bas)
                    {
                        max3bas = max2bas;
                        max2bas = basinSize;

                    }
                    else if (basinSize > max3bas)
                    {
                        max3bas = basinSize;
                    }
                }

                // Check row end
                current = grid[i][rowlen];
                c = new Coord(i, rowlen);
                if (current < grid[i-1][rowlen] && current < grid[i+1][rowlen] && current < grid[i][rowlen-1])
                {
                    lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                    var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                    if (basinSize > maxbas)
                    {
                        max3bas = max2bas;
                        max2bas = maxbas;
                        maxbas = basinSize;
                    }
                    else if (basinSize > max2bas)
                    {
                        max3bas = max2bas;
                        max2bas = basinSize;

                    }
                    else if (basinSize > max3bas)
                    {
                        max3bas = basinSize;
                    }
                }

                // Check row middle
                for (int j = 1; j < rowlen; j++)
                {
                    current = grid[i][j];
                    c = new Coord(i, j);
                    if (current < grid[i-1][j] && current < grid[i+1][j] && current < grid[i][j-1] && current < grid[i][j+1])
                    {
                        lowCount = lowCount + (1 + (int)char.GetNumericValue(current));
                        var basinSize = p.ExploreAllAdjacent(c, grid, new List<Coord>()).Count();
                        if (basinSize > maxbas)
                        {
                            max3bas = max2bas;
                            max2bas = maxbas;
                            maxbas = basinSize;
                        }
                        else if (basinSize > max2bas)
                        {
                            max3bas = max2bas;
                            max2bas = basinSize;

                        }
                        else if (basinSize > max3bas)
                        {
                            max3bas = basinSize;
                        }
                    }
                }
            }

            Console.WriteLine("p1: " + lowCount);
            Console.WriteLine("p2: " + maxbas * max2bas * max3bas);
        }
    }
}
