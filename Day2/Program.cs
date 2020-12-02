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

            List<string> lines = new List<string>(File.ReadAllLines(inputPath));

            int validPw = 0;
            foreach (var line in lines)
            {
                //Extract password policy and password
                string policy = line.Split(':')[0].Trim();
                char[] pw = line.Split(':')[1].Trim().ToCharArray();

                //Parse password policy
                string numbers = policy.Split(' ')[0];
                char letter = policy.Split(' ')[1].ToCharArray()[0];

                int minLetters = Int32.Parse(numbers.Split('-')[0]);
                int maxLetters = Int32.Parse(numbers.Split('-')[1]);

                int numChars = pw.Count(c => c == letter);

                if (numChars >= minLetters && numChars <= maxLetters)
                {
                    validPw++;
                }
            }

            Console.WriteLine("Part 1: " + validPw.ToString());
        }

        static void Part2()
        {
            string inputPath = "input.txt";

            List<string> lines = new List<string>(File.ReadAllLines(inputPath));

            int validPw = 0;
            foreach (var line in lines)
            {
                //Extract password policy and password
                string policy = line.Split(':')[0].Trim();
                char[] pw = line.Split(':')[1].Trim().ToCharArray();

                //Parse password policy
                string numbers = policy.Split(' ')[0];
                char letter = policy.Split(' ')[1].ToCharArray()[0];

                int firstLetter = Int32.Parse(numbers.Split('-')[0]);
                int secondLetter = Int32.Parse(numbers.Split('-')[1]);

                if(pw[firstLetter-1] == letter && pw[secondLetter-1] != letter ||
                   pw[firstLetter-1] != letter && pw[secondLetter-1] == letter)
                {
                    validPw++;
                }
            }

            Console.WriteLine("Part 2: " + validPw.ToString());
        }

        static void Main(string[] args)
        {
            Part1();
            Part2();
            
        }
    }
}
