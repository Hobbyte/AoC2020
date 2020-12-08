using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day7
{
    class Program
    {
        class Relation
        {
            public string Parent;
            public string Child;
            public int Num;
        }

        static List<Relation> ParseRelations ()
        {
            var lines = File.ReadAllLines("input.txt");

            List<Relation> relations = new List<Relation>();

            var regex = new Regex("([0-9]+) (.+)");

            foreach (var line in lines)
            {
                var splitup = line.Split(" contain ");

                string parentBag = splitup[0].Replace(" bags", "").Replace(" bag", "");
                string childBags = splitup[1];


                foreach (string rule in childBags.Split(','))
                {
                    if (rule == "no other bags.")
                        continue;

                    var r = rule.Trim().Replace(".", "").Replace(" bags", "").Replace(" bag", "");

                    var capture = regex.Match(r);

                    int num = int.Parse(capture.Groups[1].Value);
                    string bagName = capture.Groups[2].Value;

                    relations.Add(new Relation()
                    {
                        Parent = parentBag,
                        Child = bagName,
                        Num = num
                    });
                }
            }

            return relations;
        }
        static void Part1()
        {
            var relations = ParseRelations();

            List<string> validBags = new List<string>();
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("shiny gold");

            string item;

            while (queue.TryDequeue(out item))
            {
                relations.Where(x => x.Child == item).Select(y => y.Parent).ToList().ForEach(s => { queue.Enqueue(s); validBags.Add(s); });
            }

            Console.WriteLine("Part1: " + validBags.Distinct().Count());
        }
        static List<Relation> FindChildren(List<Relation> relations, string parent)
        {
            return relations.Where(x => x.Parent == parent).ToList();
        }
        static void Part2()
        {
            var relations = ParseRelations();

            Queue<string> queue = new Queue<string>();

            queue.Enqueue("shiny gold");
            int count = 0;
            string item;
            while (queue.TryDequeue(out item))
            {
                count++;
                foreach (var c in FindChildren(relations, item))
                {
                    

                    for (int i = 0; i < c.Num; i++)
                    {
                        queue.Enqueue(c.Child);
                    }
                }
            }
            count--; //don't count the shiny gold bag
            Console.WriteLine("Part2: " + count);
        }
        static void Main(string[] args)
        {
            Part1();
            Part2();

        }
    }
}
