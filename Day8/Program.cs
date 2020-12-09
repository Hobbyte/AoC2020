using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day8
{
    class Program
    {
        class Instruction
        {
            public string OpCode;
            public int Val;
            public bool HasRun;

            public Instruction Clone()
            {
                return new Instruction() { HasRun = HasRun, OpCode = OpCode, Val = Val };
            }
        }

        static List<Instruction> ParseInstructions()
        {
            var lines = File.ReadAllLines("input.txt");
            return lines.Select(l => new Instruction() { OpCode = l.Split(' ')[0], Val = int.Parse(l.Split(' ')[1]) }).ToList();
        }

        static Tuple<int,bool> Execute(List<Instruction> instructions)
        {

            int acc = 0;
            int pc = 0;

            Instruction ins;
            while (pc < instructions.Count && !(ins = instructions[pc]).HasRun)
            {
                switch (ins.OpCode)
                {
                    case "nop":
                        pc++;
                        break;
                    case "acc":
                        acc += ins.Val;
                        pc++;
                        break;
                    case "jmp":
                        pc += ins.Val;
                        break;
                }
                ins.HasRun = true;
            }


            return new Tuple<int, bool>(acc, pc != instructions.Count);
        }

        static void Part1()
        {
            var instructions = ParseInstructions();

            var result = Execute(instructions);

            Console.WriteLine("Part1: " + result.Item1);
        }
        
        static void Part2()
        {
            var instructions = ParseInstructions();
            
            for(int i = 0; i < instructions.Count;i++)
            {
                
                switch(instructions[i].OpCode)
                {
                    case "nop":
                        {
                            var newInstructions = instructions.Select(x => x.Clone()).ToList();
                            newInstructions[i].OpCode = "jmp";

                            var result = Execute(newInstructions);

                            if (!result.Item2)
                            {
                                Console.WriteLine("Part2: " + result.Item1);
                                return;
                            }
                            break;
                        }
                    case "jmp":
                        {
                            var newInstructions = instructions.Select(x => x.Clone()).ToList();
                            newInstructions[i].OpCode = "nop";

                            var result = Execute(newInstructions);

                            if (!result.Item2)
                            {
                                Console.WriteLine("Part2: " + result.Item1);
                                return;
                            }
                            break;
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
