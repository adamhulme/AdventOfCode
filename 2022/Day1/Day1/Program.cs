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

            Console.WriteLine(input[0][0]);
            Console.WriteLine(input[1][1]);
        }
    }
}
