using System.Linq;

namespace AdventOfCode.Day7
{
    public class Problem2
    {
        public const string TestInput = @"
shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";

        public const string TestTargetColor = "shiny gold";

        public static int Solve()
        {
            var rules = Problem1.ParseRules(TestInput);

            // for this one we only care about shiny gold bags
            var shinyGold = rules.Single(x => x.Color == TestTargetColor);

            // now we need to recurse down again, counting everything that is required
            var total = CountDependents(shinyGold);

            return total;
        }

        public static int CountDependents(Problem1.Bag bag)
        {
            if (bag.ContainsBags == null || bag.ContainsBags.Any() == false)
            {
                return 0;
            }

            var total = 0;
            foreach (var child in bag.ContainsBags)
            {
                total = total + child.Count + (child.Count * CountDependents(child));
            }

            return total;
        }
    }
}