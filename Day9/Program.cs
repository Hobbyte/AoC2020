using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day9
{
    class Program
    {
        static long Part1()
        {
            var lines = File.ReadAllLines("input.txt").Select(x => Int64.Parse(x)).ToList();

            bool found = false;
            long lastNum = 0;
            for (int i = 25; i < lines.Count(); i++)
            {
                found = false;
                for (var x = i - 25; x < i && !found; x++)
                {
                    for (var y = i - 25; y < i && !found; y++)
                    {
                        if (lines[x] == lines[y])
                            continue;

                        if (lines[x] + lines[y] == lines[i])
                        {
                            found = true;
                            continue;
                        }
                    }
                }
                if(!found)
                {
                    lastNum = lines[i];
                    break;
                }
            }

            return lastNum;
        }
        static void Part2(long part1)
        {

            var lines = File.ReadAllLines("input.txt").Select(x => Int64.Parse(x)).ToList();


            for (int i = 0; i < lines.Count(); i++)
            {
                long sum = lines[i];

                for (var x = i + 1; x < lines.Count(); x++)
                {
                    sum += lines[x];

                    if (sum > part1)
                        break;

                    if(sum == part1)
                    {
                        

                        var chunk = lines.GetRange(i, x - i);

                        long smallest = chunk.Min();
                        long largest = chunk.Max();

                        long found = smallest + largest;
                        Console.WriteLine("Part2: " + found);
                        return;
                    }

                }
            }
        }
        static void Main(string[] args)
        {
            var part1 = Part1();
            Console.WriteLine("Part1: " + part1);
            Part2(part1);
        }
    }
}
