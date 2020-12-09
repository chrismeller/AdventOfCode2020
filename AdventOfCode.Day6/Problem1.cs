using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    public class Problem1
    {
        public const string TestInput = @"
abc

a
b
c

ab
ac

a
a
a
a

b";

        public static int Solve()
        {
            var groups = Parse(TestInput);

            var sum = groups.Sum(x => x.Count);

            return sum;
        }

        public static IEnumerable<List<string>> Parse(string input)
        {
            var lines = input.Trim().Split("\r\n", StringSplitOptions.None);
            var currentBatch = new List<string>();
            foreach (var line in lines)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    var result = ParseGroup(currentBatch);
                    currentBatch = new List<string>();

                    yield return result;
                }
                else
                {
                    currentBatch.Add(line);
                }
            }

            // and if we have anything left at the end, parse that too
            if (currentBatch.Any())
            {
                yield return ParseGroup(currentBatch);
            }
        }

        public static List<string> ParseGroup(List<string> lines)
        {
            var yesQuestions = new List<string>();

            // each persons' answers are on a single line
            foreach (var personAnswers in lines)
            {
                var answers = personAnswers.ToCharArray().Select(x => Convert.ToString(x));

                foreach (var answer in answers)
                {
                    if (yesQuestions.Contains(answer) == false)
                    {
                        yesQuestions.Add(answer);
                    }
                }
            }

            return yesQuestions;
        }
    }
}
