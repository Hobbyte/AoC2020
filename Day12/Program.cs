using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Day12
{
    class Program
    {
        static string[] test1data = new string[]
        {
            "F10",
            "N3 ",
            "F7 ",
            "R90",
            "F11"
        };
        static int test1answer = 25;
        static int test2answer = 286;

        enum Facing
        {
            North = 0,
            East = 90,
            South = 180,
            West = 270
        }

        static int FindRoute(string[] data)
        {
            int x = 0;
            int y = 0;

            Facing facing = Facing.East;

            foreach (string s in data)
            {
                int val = int.Parse(s.Substring(1));
                switch (s.Substring(0, 1))
                {
                    case "N":
                        y += val;
                        break;
                    case "S":
                        y -= val;
                        break;
                    case "E":
                        x += val;
                        break;
                    case "W":
                        x -= val;
                        break;
                    case "L":
                        var newFacing = (int)facing - val;
                        if (newFacing < 0)
                            newFacing += 360;

                        facing = (Facing)newFacing;
                        break;
                    case "R":
                        var newFacing2 = (int)facing + val;
                        if (newFacing2 >= 360)
                            newFacing2 -= 360;

                        facing = (Facing)newFacing2;
                        break;
                    case "F":
                        switch (facing)
                        {
                            case Facing.North:
                                y += val;
                                break;
                            case Facing.East:
                                x += val;
                                break;
                            case Facing.South:
                                y -= val;
                                break;
                            case Facing.West:
                                x -= val;
                                break;
                        }
                        break;



                }
            }

            return (Math.Abs(x) + Math.Abs(y));
        }

        static int FindRoute2(string[] data)
        {
            int x = 0;
            int y = 0;

            int wX = 10;
            int wY = 1;

            Facing facing = Facing.East;

            foreach (string s in data)
            {
                int val = int.Parse(s.Substring(1));
                switch (s.Substring(0, 1))
                {
                    case "N":
                        y += val;
                        break;
                    case "S":
                        y -= val;
                        break;
                    case "E":
                        x += val;
                        break;
                    case "W":
                        x -= val;
                        break;
                    case "L":
                        var newFacing = (int)facing - val;
                        if (newFacing < 0)
                            newFacing += 360;

                        facing = (Facing)newFacing;
                        break;
                    case "R":
                        var newFacing2 = (int)facing + val;
                        if (newFacing2 >= 360)
                            newFacing2 -= 360;

                        facing = (Facing)newFacing2;
                        break;
                    case "F":
                        switch (facing)
                        {
                            case Facing.North:
                                y += val;
                                break;
                            case Facing.East:
                                x += val;
                                break;
                            case Facing.South:
                                y -= val;
                                break;
                            case Facing.West:
                                x -= val;
                                break;
                        }
                        break;



                }
            }

            return (Math.Abs(x) + Math.Abs(y));
        }
        static void Test1()
        {
            var answer = FindRoute(test1data);

            Console.WriteLine("Test1: " + answer + ", should be: " + test1answer);
        }
        static void Part1()
        {
            var answer = FindRoute(File.ReadAllLines("input.txt").ToArray());

            Console.WriteLine("Part1: " + answer);
        }
        static void Main(string[] args)
        {
            Test1();
            Part1();
        }
    }
}
