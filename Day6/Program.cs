using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day6
{
    class Program
    {

        static void Part1()
        {
            Console.WriteLine("Part1: " + File.ReadAllText("input.txt").Split("\n\n").Select(x => x.Replace("\n", "").ToLower().ToCharArray().Distinct().Count()).Sum());
        }
        static void Part2()
        {
            var groups = File.ReadAllText("input.txt").Split("\n\n").Select(z => z.Split('\n').ToList());

            int total = 0;

            foreach(var g in groups)
            {
                var derp = g.Where(y => y.Length != 0).Select(x => x.ToCharArray().ToList()).Aggregate((c1, c2) => c1.Intersect(c2).ToList());

                total += derp.Count;
            }

            Console.Write("Part2: " + total);
        }
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
    }
}
