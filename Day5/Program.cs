using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day5
{
    class Seating
    {
        public static int MaxRows = 127;
        public static int MaxCols = 7;


        public int Row;
        public int Col;
        public int SeatId;

        public static Seating FindSeat(string s)
        {
            //Split row and col
            string fb = s.Substring(0, 7);
            string lr = s.Substring(7, 3);

            int rowMin = 0;
            int rowMax = MaxRows;

            foreach (var c in fb.ToCharArray())
            {
                int diff = (rowMax - rowMin) / 2;
                if (c == 'F')
                {

                    rowMax = rowMin + diff;
                }
                if (c == 'B')
                {
                    rowMin = rowMax - diff;
                }
            }

            int row = rowMin;

            int colMin = 0;
            int colMax = MaxCols;

            foreach (var c in lr.ToCharArray())
            {
                int diff = (colMax - colMin) / 2;
                if (c == 'L')
                {

                    colMax = colMin + diff;
                }
                if (c == 'R')
                {
                    colMin = colMax - diff;
                }
            }

            int col = colMax;

            return new Seating() { Col = col, Row = row, SeatId = row * 8 + col };
        }
    }

    class Program
    {
        
        static List<Seating> FindSeats()
        {
            string inputPath = "input.txt";

            List<string> lines = new List<string>(File.ReadAllLines(inputPath));
            return lines.Select(x => Seating.FindSeat(x)).ToList();
        }
        static void Part1()
        {
            var maxSeatId = FindSeats().Max(x => x.SeatId);

            Console.WriteLine("Part1: " + maxSeatId);
        }

        static void Part2()
        {
            var seats = FindSeats();

            var seatRow = seats.Where(g => g.Row != 0 && g.Row != 127).GroupBy(x => x.Row).Where(z => z.Count() == 7).First();
            var foundSeat = Enumerable.Range(0, 7).Except(seatRow.Select(x => x.Col)).FirstOrDefault();

            var seatId = seatRow.First().Row * 8 + foundSeat;
            Console.WriteLine("Part2: " + seatId);
        }

        static void Test()
        {
            var result = Seating.FindSeat("FBFBBFFRLR");

            if (result.Row != 44 || result.Col != 5 || result.SeatId != 357)
                throw new Exception("wtf");
        }
        static void Main(string[] args)
        {
            Test();
            Part1();
            Part2();
        }
    }
}
