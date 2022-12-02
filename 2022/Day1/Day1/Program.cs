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

            // Day 2 (and I'm already sick of C#) (py time tomorrow)
            var score = 0;
            for (int i=0; i<input.Length; i++) 
            {
                var answers = input[i].Split(' ');
                var them = answers[0];
                var me = answers[1];
                if (me == "X")
                {
                    if (them == "A")
                    {
                        score += 3;
                    }
                    else if (them == "B")
                    {
                        score++;
                    }
                    else if (them == "C")
                    {
                        score += 2;
                    }

                }
                else if (me == "Y")
                {
                    score += 3;
                    if (them == "A")
                    {
                        score += 1;
                    }
                    else if (them == "B")
                    {
                        score += 2;
                    }
                    else if (them == "C")
                    {
                        score += 3;
                    }

                }
                else if (me == "Z")
                {
                    score += 6;
                    if (them == "A")
                    {
                        score += 2;
                    }
                    else if (them == "B")
                    {
                        score += 3;
                    }
                    else if (them == "C")
                    {
                        score += 1;
                    }
                }
            }

            Console.WriteLine(score);

            // Day 1
            //var currentElf = 0;
            //var elves = new List<int>();

            //for (int i=0; i<input.Length; i++)
            //{
            //    if (input[i] != "")
            //    {
            //        currentElf += Int32.Parse(input[i]);
            //    }
            //    else
            //    {
            //        elves.Add(currentElf);
            //        currentElf = 0;
            //    }
            //}


            //// Part 1
            //Console.WriteLine(elves.Max());

            //// Part 2
            //elves.Sort();
            //elves.Reverse();
            //Console.WriteLine(elves[0] + elves[1] + elves[2]);
        }
    }
}
