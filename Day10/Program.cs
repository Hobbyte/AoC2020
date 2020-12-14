using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        static int[] test1data = new int[]
        {
            28,
            33,
            18,
            42,
            31,
            14,
            46,
            20,
            48,
            47,
            24,
            23,
            49,
            45,
            19,
            38,
            39,
            11,
            1 ,
            32,
            25,
            35,
            8 ,
            17,
            7 ,
            9 ,
            4 ,
            2 ,
            34,
            10,
            3 
        };
        static int[] smallTestData = new int[]
        {
        16,
        10,
        15,
        5 ,
        1 ,
        11,
        7 ,
        19,
        6 ,
        12,
        4
        };

        static int test1answer = 220;
        static int test1answer2 = 19208;
        static int smallTestAnswer = 8;

        static int findAnswer(int[] data)
        {
            var sorted = data.OrderBy(x => x).ToList();

            int oneJolt = 0;
            int twoJolt = 0;
            int threeJolt = 0;

            if (sorted[0] == 1)
            {
                oneJolt++;
            }
            else if (sorted[0] == 2)
            {
                twoJolt++;
            }
            else if (sorted[0] == 3)
            {
                threeJolt++;
            }

            for (int i = 1; i < sorted.Count(); i++)
            {
                if(sorted[i] - sorted[i-1] == 1)
                {
                    oneJolt++;
                }
                else if (sorted[i] - sorted[i - 1] == 2)
                {
                    twoJolt++;
                }
                else if (sorted[i] - sorted[i - 1] == 3)
                {
                    threeJolt++;
                }
                else
                {
                    throw new Exception();
                }
            }

            threeJolt++;

            return oneJolt * threeJolt;
        }

        static void test1()
        {
            int answer = findAnswer(test1data);

            Console.WriteLine("Test1: " + answer + ", should be: " + test1answer);
        }
        static void Part1()
        {
            int answer = findAnswer(File.ReadAllLines("input.txt").Select(x => int.Parse(x)).ToArray());

            Console.WriteLine("Part1: " + answer);
        }

        static int numTasks = 0;
        static long combinations = 0;
        static void iterate(int i, int[] data)
        {
            int v0 = 0;
            if(i >= 0)
                v0 = data[i];
             
            List<Task> tasks = new List<Task>();
            //Try +1
            for (int x = i + 1; x < i+4 && x < data.Length && data[x] < v0 + 4; x++)
            {
                if (data[x] == v0 + 1 || data[x] == v0 + 2 || data[x] == v0 + 3)
                {
                    if (x == data.Length-1)
                    {
                        combinations++;
                    }
                        iterate(x, data);
                }
            }

            Task.WaitAll(tasks.ToArray());
            numTasks -= tasks.Count;
        }

        static void smallTest()
        {
            numTasks = 0;
            combinations = 0;
            iterate(-1, smallTestData.OrderBy(x => x).ToArray());

            Console.WriteLine("SmallTest: " + combinations + ", should be: " + smallTestAnswer);
            combinations = 0;
            numTasks = 0;
        }
        static void test2()
        {
            numTasks = 0;
            combinations = 0;
            iterate(-1,test1data.OrderBy(x => x).ToArray());

            Console.WriteLine("Test2: " + combinations + ", should be: " + test1answer2);
            combinations = 0;
            numTasks = 0;
        }
        static void Part2()
        {
            numTasks = 0;
            combinations = 0;
            var numbers = File.ReadAllLines("input.txt").Select(x => int.Parse(x)).OrderBy(x => x).ToArray();

            iterate(-1, numbers);

            Console.WriteLine("Part2: " + combinations);
            combinations = 0;
            numTasks = 0;
        }
        static void Main(string[] args)
        {
            test1();
            Part1();
            smallTest();
            test2();
            Part2();
        }
    }
}
