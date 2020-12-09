using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day8
{
    public class Problem1
    {
        public const string TestInput = @"
nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";

        public static int Solve()
        {
            var operations = Parse(TestInput);

            var currentOpIndex = 0;
            var accumulated = 0;
            var runOperations = new List<int>();
            do
            {
                if (runOperations.Contains(currentOpIndex))
                {
                    return accumulated;
                }
                else
                {
                    runOperations.Add(currentOpIndex);
                }

                var op = operations[currentOpIndex];

                if (op.Operator == "nop")
                {
                    currentOpIndex = currentOpIndex + 1;
                }
                else if (op.Operator == "acc")
                {
                    accumulated = accumulated + op.Argument;
                    currentOpIndex = currentOpIndex + 1;
                }
                else if (op.Operator == "jmp")
                {
                    currentOpIndex = currentOpIndex + op.Argument;
                }
            } while (currentOpIndex < operations.Count);

            return accumulated;
        }

        public static List<Op> Parse(string input)
        {
            var operations = input.Trim().Split("\r\n").Select(x =>
            {
                var op = x.Split(" ").First().Trim();
                var arg = x.Split(" ").Last().Trim();

                return new Op()
                {
                    Operator = op,
                    Argument = Convert.ToInt32(arg),
                };
            }).ToList();

            return operations;
        }

        public class Op
        {
            public string Operator { get; set; }
            public int Argument { get; set; }

            public override string ToString()
            {
                return $"{Operator} {Argument}";
            }
        }
    }
}
