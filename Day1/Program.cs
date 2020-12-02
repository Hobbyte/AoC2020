using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Part1()
        {
            string inputPath = "input.txt";

            List<int> lines = new List<string>(File.ReadAllLines(inputPath)).Select(x => int.Parse(x)).ToList();

            foreach (var num1 in lines)
            {
                foreach(var num2 in lines)
                {
                    if(num1 != num2)
                    {
                        if(num1 + num2 == 2020)
                        {
                            Console.WriteLine("Part 1: " + num1 * num2);
                            return;
                        }
                    }
                }
                
            }

            
        }

        static void Part2()
        {
            string inputPath = "input.txt";

            List<int> lines = new List<string>(File.ReadAllLines(inputPath)).Select(x => int.Parse(x)).ToList();

            foreach (var num1 in lines)
            {
                foreach (var num2 in lines)
                {
                    foreach (var num3 in lines)
                    {
                        if (num1 != num2 && num2 != num3 && num1 != num3)
                        {
                            if (num1 + num2 + num3 == 2020)
                            {
                                Console.WriteLine("Part 2: " + num1 * num2 * num3);
                                return;
                            }
                        }
                    }
                }

            }
        }

        static void Main(string[] args)
        {
            Part1();
            Part2();

        }
    }
}
