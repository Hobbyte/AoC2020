using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day17
{
    class Program
    {
        static string[] test1data = new string[]
        {
        ".#.",
        "..#",
        "###"
        };
        static int test1answer = 112;
        static int test2answer = 848;

        static int DoTheNeedful(string[] data)
        {
            var theGrid = new bool[20, 20, 20];

            for (int y = 0; y < data.Length; y++)
            {
                var l = data[y].ToCharArray();
                for (int x = 0; x < l.Length; x++)
                {
                    theGrid[theGrid.GetLength(0) / 2 + x, theGrid.GetLength(1) / 2 + y, theGrid.GetLength(2) / 2] = l[x] == '#' ? true : false;
                }
            }

            for (int cycles = 0; cycles < 6; cycles++)
            {
                var theGrid2 = new bool[theGrid.GetLength(0), theGrid.GetLength(1), theGrid.GetLength(2)];

                for (int x = 1; x < theGrid.GetLength(0) - 1; x++)
                {
                    for (int y = 1; y < theGrid.GetLength(1) - 1; y++)
                    {
                        for (int z = 1; z < theGrid.GetLength(2) - 1; z++)
                        {
                            theGrid2[x, y, z] = theGrid[x, y, z];
                            int neighbors = 0;

                            for (int x2 = x - 1; x2 <= x + 1; x2++)
                            {
                                for (int y2 = y - 1; y2 <= y + 1; y2++)
                                {
                                    for (int z2 = z - 1; z2 <= z + 1; z2++)
                                    {
                                        if (x2 == x && y2 == y && z2 == z)
                                            continue;

                                        if (theGrid[x2, y2, z2])
                                            neighbors++;
                                    }
                                }

                            }

                            if (theGrid[x, y, z])
                            {
                                if (neighbors != 2 && neighbors != 3)
                                {
                                    theGrid2[x, y, z] = false;
                                }
                            }
                            else
                            {
                                if (neighbors == 3)
                                {
                                    theGrid2[x, y, z] = true;
                                }
                            }



                        }
                    }
                }
                theGrid = theGrid2;
            }

            return theGrid.Cast<bool>().Count(x => x);
        }
        static string visualize(bool[,,,] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int w = 1; w < data.GetLength(3) - 1; w++)
            {
                for (int z = 1; z < data.GetLength(2) - 1; z++)
                {
                    sb.AppendFormat("z={0}, w={1}\r\n", z, w);


                    for (int y = 1; y < data.GetLength(1) - 1; y++)
                    {
                        for (int x = 1; x < data.GetLength(0) - 1; x++)
                        {
                            sb.Append(data[x, y, z, w] ? "#" : ".");
                        }
                        sb.Append("\r\n");
                    }

                    sb.Append("\r\n");
                }
            }

            return sb.ToString();
        }
        static int DoTheNeedful2(string[] data)
        {
            var theGrid = new bool[40, 40, 40, 40];

            for (int y = 0; y < data.Length; y++)
            {
                var l = data[y].ToCharArray();
                for (int x = 0; x < l.Length; x++)
                {
                    theGrid[theGrid.GetLength(0) / 2 + x, theGrid.GetLength(1) / 2 + y, theGrid.GetLength(2) / 2, theGrid.GetLength(3) / 2] = l[x] == '#' ? true : false;
                }
            }

            for (int cycles = 0; cycles < 6; cycles++)
            {
                var theGrid2 = new bool[theGrid.GetLength(0), theGrid.GetLength(1), theGrid.GetLength(2), theGrid.GetLength(3)];

                for (int x = 1; x < theGrid.GetLength(0) - 1; x++)
                {
                    for (int y = 1; y < theGrid.GetLength(1) - 1; y++)
                    {
                        for (int z = 1; z < theGrid.GetLength(2) - 1; z++)
                        {
                            for (int w = 1; w < theGrid.GetLength(3) - 1; w++)
                            {
                                theGrid2[x, y, z, w] = theGrid[x, y, z, w];
                                int neighbors = 0;

                                for (int x2 = x - 1; x2 <= x + 1; x2++)
                                {
                                    for (int y2 = y - 1; y2 <= y + 1; y2++)
                                    {
                                        for (int z2 = z - 1; z2 <= z + 1; z2++)
                                        {
                                            for (int w2 = w - 1; w2 <= w + 1; w2++)
                                            {
                                                if (x2 == x && y2 == y && z2 == z && w2 == w)
                                                    continue;

                                                if (theGrid[x2, y2, z2, w2])
                                                    neighbors++;
                                            }
                                        }
                                    }

                                }

                                if (theGrid[x, y, z, w])
                                {
                                    if (neighbors != 2 && neighbors != 3)
                                    {
                                        theGrid2[x, y, z, w] = false;
                                    }
                                }
                                else
                                {
                                    if (neighbors == 3)
                                    {
                                        theGrid2[x, y, z, w] = true;
                                    }
                                }


                            }
                        }
                    }
                }
                theGrid = theGrid2;

                var c = visualize(theGrid);
            }

            return theGrid.Cast<bool>().Count(x => x);
        }
        static void Test1()
        {
            //var lines = File.ReadAllLines("input.txt").ToArray();
            int answer = DoTheNeedful(test1data);

            Console.WriteLine("Test1: " + answer + ", should be: " + test1answer);
        }
        static void Part1()
        {
            var lines = File.ReadAllLines("input.txt").ToArray();
            int answer = DoTheNeedful(lines);

            Console.WriteLine("Part1: " + answer);
        }
        static void Test2()
        {
            //var lines = File.ReadAllLines("input.txt").ToArray();
            int answer = DoTheNeedful2(test1data);

            Console.WriteLine("Test2: " + answer + ", should be: " + test2answer);
        }

        static void Part2()
        {
            var lines = File.ReadAllLines("input.txt").ToArray();
            int answer = DoTheNeedful2(lines);

            Console.WriteLine("Part2: " + answer);
        }
        static void Main(string[] args)
        {
            Test1();
            Part1();
            Test2();
            Part2();
        }
    }
}
