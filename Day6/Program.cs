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
            Console.WriteLine("Part2: " + File.ReadAllText("input.txt").Split("\n\n").Select(z => z.Split('\n')).ToList().Select(g => g.Where(y => y.Length != 0).Select(x => x.ToList()).Aggregate((c1, c2) => c1.Intersect(c2).ToList()).Count).Sum());
        }
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
    }
}
