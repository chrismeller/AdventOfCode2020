using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class Problem2
    {
        public static long Solve()
        {
            var steps = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1),
                new Tuple<int, int>(1, 2),
            };

            var totalTrees = new List<long>();
            foreach (var step in steps)
            {
                var stepX = step.Item1;
                var stepY = step.Item2;

                var trees = SolveFor(stepX, stepY);

                totalTrees.Add(trees);
            }

            var result = totalTrees.Aggregate((total, i) =>
            {
                var newTotal = total * i;
                Console.Out.WriteLine($"{total} x {i} = {newTotal}");
                return newTotal;
            });

            return result;
        }

        public static int SolveFor(int stepX, int stepY)
        {
            var trees = 0;

            var x = 0;
            var y = 0;
            do
            {
                Console.Out.Write($"x: {x}, y: {y}");

                if (Problem1.IsTree(x, y))
                {
                    Console.Out.Write("\tTree!");
                    trees++;
                }

                x = x + stepX;
                y = y + stepY;

                Console.Out.WriteLine();
            }
            while (Problem1.IsEnd(x, y) == false);

            return trees;
        }
    }
}