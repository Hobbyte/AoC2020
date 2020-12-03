using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Day3
{
    class Program
    {

        static bool[,] parseMap()
        {
            string inputPath = "input.txt";

            List<string> lines = new List<string>(File.ReadAllLines(inputPath));

            bool[,] map = new bool[lines[0].Length, lines.Count];



            for (var y = 0; y < lines.Count; y++)
            {
                var row = lines[y].ToCharArray();

                for (var x = 0; x < lines[0].Length; x++)
                {
                    map[x, y] = row[x] == '#' ? true : false;
                }
            }

            return map;
        }

        static int WalkMap(bool[,] map, int stepX, int stepY)
        {

            int w = map.GetLength(0);
            int h = map.GetLength(1);

            int posX = 0;
            int posY = 0;

            int numTrees = 0;

            while (posY < h)
            {
                if (map[posX % w, posY])
                {
                    numTrees++;
                }

                posX += stepX;
                posY += stepY;

            }
            return numTrees;
        }
        static void Part1()
        {
            bool[,] map = parseMap();

            int numTrees = WalkMap(map, 3, 1);

            Console.WriteLine("Part1: " + numTrees);
        }
        static void Part2()
        {
            bool[,] map = parseMap();

            long numTrees1 = WalkMap(map, 1, 1);
            long numTrees2 = WalkMap(map, 3, 1);
            long numTrees3 = WalkMap(map, 5, 1);
            long numTrees4 = WalkMap(map, 7, 1);
            long numTrees5 = WalkMap(map, 1, 2);

            long total = numTrees1 * numTrees2 * numTrees3 * numTrees4 * numTrees5;

            Console.WriteLine("Part2: " + total);
        }

        static void Main(string[] args)
        {
            Part1();
            Part2();
        }
    }
}
