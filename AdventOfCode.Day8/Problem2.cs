using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day8
{
    public class Problem2
    {
        public static int Solve()
        {
            var operations = Problem1.Parse(Problem1.Input);

            var potentialIndexes = new List<int>();
            for (var i = 0; i < operations.Count; i++)
            {
                if (operations[i].Operator != "acc") potentialIndexes.Add(i);
            }

            foreach (var potentialIndex in potentialIndexes)
            {
                Console.Out.Write($"Replacing operation {potentialIndex}");

                var result = TrySolve(operations, potentialIndex);

                Console.Out.WriteLine($": {result}");
            }

            return 0;
        }

        public static int? TrySolve(List<Problem1.Op> operations, int potentialIndex)
        {
            var currentOpIndex = 0;
            var accumulated = 0;
            var runOperations = new List<int>();
            do
            {
                //Console.Out.Write($"Index {currentOpIndex}");

                if (runOperations.Contains(currentOpIndex))
                {
                    //Console.Out.WriteLine("\tSecond Run Detected!");
                    return null;
                }
                else
                {
                    runOperations.Add(currentOpIndex);
                }

                var op = operations[currentOpIndex];

                if (currentOpIndex == potentialIndex)
                {
                    var origOp = op.Operator;
                    op.Operator = (op.Operator == "jmp") ? "nop" : "jmp";

                    Console.Out.Write($"\t{origOp} -> {op.Operator}");
                }

                //Console.Out.WriteLine($"\t{op.Operator} {op.Argument}\t| {accumulated}");

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
                    // if we're jumping back 
                    currentOpIndex = currentOpIndex + op.Argument;
                }
            } while (currentOpIndex < operations.Count);

            return accumulated;
        }
    }
}