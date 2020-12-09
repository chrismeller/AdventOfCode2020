using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day6
{
    public class Problem2
    {
        public static int Solve()
        {
            var groups = Parse(Problem1.Input);

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

        public static List<string> ParseGroup(List<string> people)
        {
            // we're going to build a list of answers and the number of times they were marked yes in this group
            var answers = new Dictionary<string, int>();

            // each persons' answers are on a single line
            foreach (var person in people)
            {
                var personAnswers = person.ToCharArray().Select(x => Convert.ToString(x));

                foreach (var answer in personAnswers)
                {
                    if (answers.ContainsKey(answer))
                    {
                        answers[answer]++;
                    }
                    else
                    {
                        answers[answer] = 1;
                    }
                }
            }

            // now we just return all the keys where the value (the number of times it was a "yes") equals the number of people in this group
            return answers.Where(x => x.Value == people.Count).Select(x => x.Key).ToList();
        }
    }
}