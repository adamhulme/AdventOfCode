using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day10
{
    class Program
    {
        public static int GetIllegalScore(char c)
        {
            switch (c)
            {
                case ')':
                    return 3;
                case ']':
                    return 57;
                case '}':
                    return 1197;
                case '>':
                    return 25137;
                default:
                    return 0;
            }
        }

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"C:\Projects\AoCgithub\AdventOfCode\Day10\day10.txt");
            var inc = new List<string>();
            var corCount = 0;
            for (int li = 0; li < lines.Count(); li++)
            {
                var line = lines.ElementAt(li);
                bool lineIncomplete = true;
                for (int i = 0; i < line.Length; i++)
                {
                    var c = line[i];
                    if (c == ')')
                    {
                        if (line[i - 1] == '(')
                        {
                            line = line.Remove(i - 1, 1);
                            line = line.Remove(i - 1, 1);
                            i = 0;
                        }
                        else
                        {
                            corCount += GetIllegalScore(c);
                            i = line.Length;
                            lineIncomplete = false;
                        }
                    }
                    else if (c == '}')
                    {
                        if (line[i - 1] == '{')
                        {
                            line = line.Remove(i - 1, 1);
                            line = line.Remove(i - 1, 1);
                            i = 0;
                        }
                        else
                        {
                            corCount += GetIllegalScore(c);
                            i = line.Length;
                            lineIncomplete = false;
                        }
                    }
                    else if (c ==']')
                    {
                        if (line[i - 1] == '[')
                        {
                            line = line.Remove(i - 1, 1);
                            line = line.Remove(i - 1, 1);
                            i = 0;
                        }
                        else
                        {
                            corCount += GetIllegalScore(c);
                            i = line.Length;
                            lineIncomplete = false;
                        }
                    }
                    else if (c == '>')
                    {
                        if (line[i - 1] == '<')
                        {
                            line = line.Remove(i - 1, 1);
                            line = line.Remove(i - 1, 1);
                            i = 0;
                        }
                        else
                        {
                            corCount += GetIllegalScore(c);
                            i = line.Length;
                            lineIncomplete = false;
                        }
                    }
                }
                if (lineIncomplete)
                {
                    inc.Add(line);
                }
            }
            var scores = new List<long>();
            foreach (var l in inc)
            {
                long score = 0;
                var lrev = l.Reverse();
                foreach (var c in lrev)
                {
                    switch (c)
                    {
                        case '(':
                            score *= 5;
                            score += 1;
                            break;
                        case '[':
                            score *= 5;
                            score += 2;
                            break;
                        case '{':
                            score *= 5;
                            score += 3;
                            break;
                        case '<':
                            score *= 5;
                            score += 4;
                            break;
                    }
                }
                scores.Add(score);
            }
            Console.WriteLine(corCount);

            scores.Sort();
            var midpoint = scores.Count() / 2;
            Console.WriteLine(scores.ElementAt(midpoint));
        }
    }
}
