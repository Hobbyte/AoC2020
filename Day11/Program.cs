using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day11
{
    class Program
    {
        static string[] test1Data = new string[]
        {
            "L.LL.LL.LL",
            "LLLLLLL.LL",
            "L.L.L..L..",
            "LLLL.LL.LL",
            "L.LL.LL.LL",
            "L.LLLLL.LL",
            "..L.L.....",
            "LLLLLLLLLL",
            "L.LLLLLL.L",
            "L.LLLLL.LL"
        };
        static int test1answer = 37;
        static int test2answer = 26;
        enum SeatStatus
        {
            Floor,
            Empty,
            Occupied
        }
        static SeatStatus[,] parseData(string[] lines)
        {
            var seatMap = new SeatStatus[lines[0].Length, lines.Length];

            for (int y = 0; y < lines.Length; y++)
            {
                var chars = lines[y].ToCharArray();
                for (int x = 0; x < chars.Length; x++)
                {
                    seatMap[x, y] = chars[x] == 'L' ? SeatStatus.Empty : SeatStatus.Floor;
                }
            }

            return seatMap;
        }

        static bool LookUp(int x, int y, bool single, SeatStatus[,] seatmap)
        {
            while (--y >= 0)
            {
                if (seatmap[x, y] == SeatStatus.Occupied)
                    return true;
                else if (seatmap[x, y] == SeatStatus.Empty)
                    return false;
                if (single)
                    return false;
            }

            return false;
        }

        static bool LookLeft(int x, int y, bool single, SeatStatus[,] seatmap)
        {
            while (--x >= 0)
            {
                if (seatmap[x, y] == SeatStatus.Occupied)
                    return true;
                else if (seatmap[x, y] == SeatStatus.Empty)
                    return false;
                if (single)
                    return false;
            }

            return false;
        }

        static bool LookRight(int x, int y, bool single, SeatStatus[,] seatmap)
        {
            while (++x < seatmap.GetLength(0))
            {
                if (seatmap[x, y] == SeatStatus.Occupied)
                    return true;
                else if (seatmap[x, y] == SeatStatus.Empty)
                    return false;
                if (single)
                    return false;
            }

            return false;
        }
        static bool LookDown(int x, int y, bool single, SeatStatus[,] seatmap)
        {
            while (++y < seatmap.GetLength(1))
            {
                if (seatmap[x, y] == SeatStatus.Occupied)
                    return true;
                else if (seatmap[x, y] == SeatStatus.Empty)
                    return false;
                if (single)
                    return false;
            }

            return false;
        }
        static bool LookUpLeft(int x, int y, bool single, SeatStatus[,] seatmap)
        {
            while (--y >= 0 && --x >= 0)
            {
                if (seatmap[x, y] == SeatStatus.Occupied)
                    return true;
                else if (seatmap[x, y] == SeatStatus.Empty)
                    return false;
                if (single)
                    return false;
            }

            return false;
        }
        static bool LookUpRight(int x, int y, bool single, SeatStatus[,] seatmap)
        {
            while (--y >= 0 && ++x < seatmap.GetLength(0))
            {
                if (seatmap[x, y] == SeatStatus.Occupied)
                    return true;
                else if (seatmap[x, y] == SeatStatus.Empty)
                    return false;
                if (single)
                    return false;
            }

            return false;
        }
        static bool LookDownRight(int x, int y, bool single, SeatStatus[,] seatmap)
        {
            while (++y < seatmap.GetLength(1) && ++x < seatmap.GetLength(0))
            {
                if (seatmap[x, y] == SeatStatus.Occupied)
                    return true;
                else if (seatmap[x, y] == SeatStatus.Empty)
                    return false;
                if (single)
                    return false;
            }

            return false;
        }

        static bool LookDownLeft(int x, int y, bool single, SeatStatus[,] seatmap)
        {
            while (++y < seatmap.GetLength(1) && --x >= 0)
            {
                if (seatmap[x, y] == SeatStatus.Occupied)
                    return true;
                else if (seatmap[x, y] == SeatStatus.Empty)
                    return false;
                if (single)
                    return false;
            }

            return false;
        }

        static int FindOccupiedSeats(SeatStatus[,] seatmap, bool single, int maxNeighbors)
        {
            bool moved = false;
            do
            {
                moved = false;

                var newSeatMap = new SeatStatus[seatmap.GetLength(0), seatmap.GetLength(1)];

                for (int x = 0; x < seatmap.GetLength(0); x++)
                {
                    for (int y = 0; y < seatmap.GetLength(1); y++)
                    {
                        newSeatMap[x, y] = seatmap[x, y];
                        if (seatmap[x, y] == SeatStatus.Floor)
                            continue;
                        int neighbors = 0;

                        if (LookUpLeft(x, y, single, seatmap))
                            neighbors++;
                        if (LookUp(x, y, single, seatmap))
                            neighbors++;
                        if (LookUpRight(x, y, single, seatmap))
                            neighbors++;
                        if (LookRight(x, y, single, seatmap))
                            neighbors++;
                        if (LookDownRight(x, y, single, seatmap))
                            neighbors++;
                        if (LookDown(x, y, single, seatmap))
                            neighbors++;
                        if (LookDownLeft(x, y, single, seatmap))
                            neighbors++;
                        if (LookLeft(x, y, single, seatmap))
                            neighbors++;

                        if (neighbors == 0 && seatmap[x, y] != SeatStatus.Occupied)
                        {
                            newSeatMap[x, y] = SeatStatus.Occupied;
                            moved = true;
                        }
                        else if (neighbors >= maxNeighbors && seatmap[x, y] != SeatStatus.Empty)
                        {
                            newSeatMap[x, y] = SeatStatus.Empty;
                            moved = true;
                        }
                    }
                }
                seatmap = newSeatMap;
            } while (moved);

            int occupiedCount = 0;

            foreach (var s in seatmap)
            {
                if (s == SeatStatus.Occupied)
                    occupiedCount++;
            }

            return occupiedCount;
        }
        static void Test1()
        {
            var seatMap = parseData(test1Data);

            int answer = FindOccupiedSeats(seatMap, true, 4);

            Console.WriteLine("Test1: " + answer + ", should be: " + test1answer);
        }

        static void Part1()
        {
            var seatMap = parseData(File.ReadAllLines("input.txt"));

            int answer = FindOccupiedSeats(seatMap, true, 4);

            Console.WriteLine("Part1: " + answer);
        }
        static void Test2()
        {
            var seatMap = parseData(test1Data);

            int answer = FindOccupiedSeats(seatMap, false, 5);

            Console.WriteLine("Test2: " + answer + ", should be: " + test2answer);
        }

        static void Part2()
        {
            var seatMap = parseData(File.ReadAllLines("input.txt"));

            int answer = FindOccupiedSeats(seatMap, false, 5);

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
