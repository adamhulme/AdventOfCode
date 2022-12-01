using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            var input = File.ReadAllLines(@"C:\Projects\AoCgithub\AdventOfCode\2022\Day1\input.txt");

            var currentElf = 0;
            var elves = new List<int>();

            for (int i=0; i<input.Length; i++)
            {
                if (input[i] != "")
                {
                    currentElf += Int32.Parse(input[i]);
                }
                else
                {
                    elves.Add(currentElf);
                    currentElf = 0;
                }
            }


            // Part 1
            Console.WriteLine(elves.Max());

            // Part 2
            elves.Sort();
            elves.Reverse();
            Console.WriteLine(elves[0] + elves[1] + elves[2]);
        }
    }
}
