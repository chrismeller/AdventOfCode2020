﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    public class Problem1
    {
        public const string TestInput = @"
light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

        public static int Solve()
        {
            var rules = ParseRules(TestInput);

            rules.ForEach(Console.Out.WriteLine);

            return 0;
        }

        public static List<Bag> ParseRules(string input)
        {
            var lines = input.Trim().Split("\r\n");
            return lines.Select(ParseRule).ToList();
        }

        public static Bag ParseRule(string text)
        {
            // we could do this with regex, but I'm going to be lazy and just pick it apart with string logic

            // the bag color is everything up to "bags contain"
            var bagColor = text.Substring(0, text.IndexOf("bags contain")).Trim();

            // the bags this bag can contain is the part after "bags contain"
            var containsString = text.Substring(text.IndexOf("bags contain") + "bags contain".Length).Trim();

            if (containsString == "no other bags.")
            {
                return new Bag(){ Color = bagColor };
            }

            // split the list, remove "bags" and "bag", and trim periods and white space so we end up with a number and a bag color for each
            var containsList = containsString.Split(", ").Select(x =>
                {
                    return x
                        .Replace("bags", "")
                        .Replace("bag", "")
                        .Trim('.')
                        .Trim();
                })
                .ToList();

            // now split them into the color and number - the color is the key, the number is the value
            var contains = containsList.Select(x =>
            {
                var count = Convert.ToInt32(x.Substring(0, x.IndexOf(" ")));
                var color = x.Substring(x.IndexOf(" ") + 1);
                return new Bag()
                {
                    Color = color,
                    Count = count,
                };
            }).ToList();

            return new Bag()
            {
                Color = bagColor,
                ContainsBags = contains,
            };
        }

        public class Bag
        {
            public string Color { get; set; }

            public int Count { get; set; }
            public List<Bag> ContainsBags { get; set; }

            public override string ToString()
            {
                var containsStr = "";
                if (ContainsBags != null)
                {
                    var contains = ContainsBags.Select(x => x.ToString());
                    containsStr = String.Join(", ", contains);
                }

                return $"{Count}x {Color}: {containsStr}";
            }
        }
    }
}
