using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day9
{
    public class Problem2
    {
        public static Int64 Solve()
        {
            var windowSize = 25;

            var input = Problem1.Input.Trim().Split("\r\n").Select(x => Convert.ToInt64(x)).ToList();

            // skip the preamble, start with the window after that
            for (var currentIndex = windowSize; currentIndex < input.Count; currentIndex++)
            {
                Console.Out.Write($"{currentIndex} = {input[currentIndex]} ");

                // for each of the $windowSize before that, see if any add up to the current value
                if (Problem1.IsValidValue(input, currentIndex, windowSize) == false)
                {
                    // find the combination before it that adds up to it
                    var result = FindCombination(input, currentIndex);

                    Console.Out.WriteLine("Result: " + String.Join(", ", result));
                    return result.Min() + result.Max();
                }

                Console.Out.WriteLine();
            }

            return 0;
        }

        public static List<Int64> FindCombination(List<Int64> input, int currentIndex)
        {
            var currentValue = input[currentIndex];

            for (var i = 0; i < currentIndex; i++)
            {
                var iValue = input[i];

                var currentValues = new List<Int64>();
                for (int j = i+1; j < currentIndex; j++)
                {
                    var jValue = input[j];

                    currentValues.Add(jValue);

                    if (currentValues.Sum() == currentValue)
                    {
                        return currentValues;
                    }
                }
            }

            return null;
        }
    }
}