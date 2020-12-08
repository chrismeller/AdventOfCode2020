﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace AdventOfCode.Day3
{
    public class Problem1
    {
        public const string Input = @"
...#...#..#....#..#...#..##..#.
.#..#.....#.#............###...
.#...###....#.............##..#
...##...##....#.....##..#.##...
.....###.#.###..##.#.##.......#
#...##.....#..........#..#.#.#.
......##.......##..#....#.#....
....#.###.##..#.#..##.##....#.#
.......#.......###.#.#.##.....#
.........#.#....#..........#.#.
.#...##.....##.........#..#....
.##....#.#.#...##......#.......
##.#.#..#....#....#....#...#.#.
##....#.#..##......#....##...#.
....#..#..##..#.###.......#.#..
.....##....###...........#.#.##
#.....##.........#....##......#
........###.#..#....#....#.....
...#.......#.##..#.###......#..
...............#..#....#.##....
..#..###..#.#..#.........##..#.
####..#..####..................
#...####...#.......#.#.#...#...
......###.....#......#..#..#...
#...#.....##.....#.#..##...#.#.
#...........##.......#.........
.#..#.........#.#..##....#.....
........##...#................#
........#.###.#.###.#.#.##..##.
.#....##.....#...##.#..#.#.....
..#..#.....###....##.#....#.#.#
#......##.##...##..#.........#.
#..#..#.....#.....#.........#..
#....#.#...###.........#...#...
.#.#.....##......#.#......#....
..##......##...#.#.#.#.........
..#......#.....##.###.#.#..#...
....#..#.......#..#..#.....#...
.#.#.....#...#..........#......
#.#..#...........#.#.##.#...#.#
..#.#....###...#...#.....#.#...
....##.#.###....####.......#...
.....##....#.......#..#..#....#
...##..#.#.#.#......#......#...
...##...#....#...#......###...#
........#..#.#.....#.###.......
..#..##.#....#.#.........#...#.
.....#.####....#.##.........#..
......#...#...#.....#......###.
.##.....#....#..#.#....#.....#.
...........#...#....##..#...#..
.....#....#.....#...##..#...#.#
.#...#.........#.......#...#..#
...#..#...#........#......#....
..#..#####.#.....#.#....#...#.#
...#.......#.#....#...##..#..#.
####..#.#.###.#.#..............
.##........#...#.#....#..#.....
..#..............#.#..##...#.##
.###.#.....#.#.....##.#......##
....###.....#...#...#.#..#.....
....###.#.##.......#....#...#..
#..#...#......##..#.....#.#...#
....#.#.........#..............
#.##.##...#..#.#.#.....#...#.##
#...#...#......#...........##..
#.#.#......#............#.#....
.#.#..######...#.#.........#.##
..#.#..#...#......#............
....#.....#......##..#.....#...
.##............#....##..#......
.#.#.#...#.##.............###.#
#.#...#...#.....#....#.#.#.....
........#..#......##.##.#.....#
.....#.....#.#####...#....#....
.#...#......#.........#.#......
...#...#..##.....##....#..#....
....#....##..#.........#.......
..#........##..#.#........#....
...#...##...........#...#....#.
.....##.........#..#....#..#.#.
#..#....##..#...##.....#..##.#.
..#.#.#.#...#...#.....#.#....#.
.......#.###...#.#.......#.#...
....#..#..#.###.#.....###..#.#.
.#..##......#..#..#....#.####..
..##...........#...#.........#.
......#..#...#..........#......
....#..........#......##...#...
....#..#.##........#.#...##.#..
#.##......#........##.#...#...#
#..#....#.....###........##....
...........##.....##..#....#.##
..#....#..#..#......#.#.....#..
#....#.##....#.....##.......#..
.#.....#.#..............#.##..#
.#..#..#...#...#....#.#.....#..
...###...##.#...#..#........#..
#...#.##.#.....#.#....#..#.....
#.....###.#.......#.#..#.#..##.
....#..#..##.......###.#...#...
.#...####...............#.....#
.#.##.#.....#.....#.#......##.#
#...........#.##....###.##....#
...............#..........#....
.....#..#.##.###.#.............
...##.............#.....#.#..#.
....#.#...#.#..#..#..#....#....
..#.......#..........#...#...#.
...............#.#.#...###....#
....#...#.##....#..##....#.....
........#.#.##.........##.##.##
#.....###.......#.#....#..#..##
.#..#...#......#.#..##.......#.
#.....#.#........#.##..#..#....
.###..##.#.......#......###....
.#...###.....#.....#....###...#
........##.##......#.#....#...#
.#....#..#.........#..##...##..
.......#.......##.#..#..##.....
#..##..##......#.#......#.##...
..#..###..#...#....#..#...#....
#.............#.####.........##
..#..................#...#..#..
..#......#........##.......#.#.
.#.#.#.#..###.....#....#.#.....
...#.##.###.......#....#.......
................##...#.....#...
..#.###.#...#.####....#..#..#..
..#....###....##..#.#.........#
.#..#.#.....#........#....##...
.....#..#......#..#..##.#.#....
.#..#.........##....##......#..
.....#.#...#...#.#...#.#...#.#.
..#..#...#...#...##.#..###.....
..#..##......#..##.#...##......
.......#..##....##.#......#..#.
..#......#.#.....#.##....##....
..#....#......#......##........
....##.#.#....#.......#.##.....
#.....#...###....#....#...#....
............#.#..#...#...#..#..
..##.............##....#.......
.#.......#.##.#......#....##...
...##............#....#..#...#.
.##.####.....#.#..###.#....#.##
....##.#........#..#...#.......
...#...###.##...........##..#..
..##..##....#...#..#..........#
..#.........#.#...##..........#
.......##....#.#...##.....#..#.
.............#.....#.#.......#.
#.......#..##..##...##.#.......
..............#.....#.#..#...##
........##..#.....#...#...#.#..
###.#.................#........
...#........#...#.#######..#..#
...#.##...##.#.#..######...#...
#.......#..#....#..#.##.....#..
#..#....##....#.##.......#....#
#...#..#.#.#...#..#.##..#......
....#..##....#..#.#...........#
.##..#.#.............###.......
#....##......#..#..#.....###...
..#..........#...###.#.........
.####......#....#......#.#....#
..#....#.#.#......#....#.......
.....#.....#....#....#####....#
.##..........#...#.###....#....
....##.....##......#...#.#.....
.#...#...#..#.#.#...#####......
...#.##..####.##.##.......##...
............#.......#..........
.#..##.#..#####........#..#...#
#......##..##..##.........##...
....#....#.............#.#....#
###..#.....#.....#.#...#..#.###
#...#.......##......#....#.#.#.
...#......#..#...#....#...###.#
....#....##.......#....#......#
............#......##.##.....#.
...#.........#......#....##..##
.....##....##...#..###...#..#..
.......##.#..........#.##.##...
....##...........#.#..#..#.##.#
#...#..##.##.#....#....#.#.....
...##.#.....#..#..#..###....##.
#.##.#..#..#.#.............#...
..#.#.............###.....#....
...#..#....#..#.....#.#..#..#..
...#.....##.#...........#..##.#
.........#.#.##..#..#.#...#....
...#..##..#...#...###.##.#..#..
.#..##...##......##..##........
......##....##.#.##.#.#........
...#..................#.....#..
.##................#.#..#..###.
.##.##.....#................#..
.....#.#..........#...#..#.#..#
.............#......#..#.#..#..
...#...##..#........#....#.....
#......#........##.##...##.....
##..#..##....#...#............#
..##..##.##....##..##........#.
...#....#.#.#.#....#.#...##....
....#...##..##.#.##...#..#...#.
#..#....##.#.....#.......#...##
##.#....#.............#..#.....
.##..#..#.#.....#.......#.#..#.
.......#..#...##...#...###..#..
..........#...#.#..##.....#...#
..#....#...........#####....#..
#....#..#.......##.............
.........##..#####.......##....
#..#..........#.....###...#..#.
.#.#.#..#...#.......##...#####.
.....#....#.###...#.......#....
#.#.....##...###....###....#...
.#.....#..#.#.#........#...#...
.##.#.#.#......#....###....#...
.#..##..####......###......#...
......#.#.#.#.#...#...####.##..
.#........##..#.....#....#....#
.....###......##..#....#.......
#.#.##...#.#......###..........
........#.#...#..#......#....#.
..##...##.........#.......#.#..
..#.##....#...##.....#.###.....
.........#..#.#....#....#.#.##.
#.........#......#..#.......#..
...#...##.......#.........#....
............#......#...........
##.....#.....#.#...#.....#.....
..#.#...#..#...#.#...........#.
#.#.#..#..#...##.#...#.#.....#.
.#..###.#..##.#.....#.....#....
##....##....#.......##..##.....
.#..#...........###..........#.
.#..#..#..........###..#.......
#..###......#............##...#
#......#........#..#..#..#.#...
.......#.###...#.##............
.##....#.......#.#...##.....#.#
....#..#.#.......#.#...........
##....#.###.#....#.#..##.#....#
..#..#..#....#...#........##...
...#...##....#..#.#...#..#.....
......#..#......#....#.......#.
#.#..............#...###...#..#
...#....#..#..........#.#...#..
#.....##..##.....#........#....
.#...##..#.#..............#....
##.#....#..##...#..#.####.#..#.
.....#.......#.#.#.#..#.....###
...#.##....#.#........##.......
#...#.#...#.#..###..##.##...#.#
###..............#.#.###.......
...###..#.#..#....##...###.#...
......##...........#...#..#...#
.#..#.........##.......#..#...#
.#.......###......##...#...#...
.#......##...#........#.......#
.#..#.....#.........#.#........
#...#.#.....#...#..##.........#
......##.#......##.#..##.#.....
...............#.#..#....#....#
#....#..#..#..#.#.....##...##..
#.#......#.###......#..#...####
.#.#..#...#...#.#..#.##.##.#.#.
.....#.#...###...#.#.....##....
...#..#.#..........##.#....#.#.
...#..#.#.##.....###.##.#....#.
..........#..###......#..#.#...
###.....#..###..#...#..###.#...
..#..#.....##.#.#..###.......#.
....#....##........##..........
.......#..........#...#......#.
.#........#.#.#.#.#.......#....
.#..#.......##..##....#.#...#..
.#.#.#.......#..#..............
#.#....#.#...#.#.#.....#.#...##
.....#..........##..#.......#..
.##......#.#....#.#.......#....
..#.##....#.##.#...#...........
...##......##..##.............#
..........##.#.#..#..........#.
.##....#..#..#.#....##.#...#.#.
...........#....#.....#.#..#...
.#.....#....##..#.........#....
.....#.....#...#....#...#.###.#
..#....#....#.....#...#......#.
.....##..#.............#...#...
........#..#.......#.#.......#.
#...###..#.##.#...###...##..##.
....##..#.......#...#.#........
.#...#.#.##....####........#..#
.#...#.#.####.##.#.............
#..##...#....#...#.#.#.#.##..#.
.#.......#........#.....###....
#.#.....#....#..#....#..#....#.
...#..#...#.....#.........##...
.#....#......###...#....#.#.#..
#.#........#......#...#....##..
.....#..#......#..#..#......#..
.#.....#..#.##.#.#.#...#......#
##........#..#.#..#...#.####...
..........##....#.#..#.#....#..
#.##..#..#....#..#....##..#.#.#
..#......#.......#...##..#.....
##...#.........#......#......#.
.#.....................#..#.##.
.#.......#........#.#.#..##.#..
..#..........#........#..##.#..
.#...#...#.........##.#.#.#....
....#....#.###.#....###....#.##
....##......##........##.#.##..
....#.#......#.##.#...#.##.....
....#....#..#.#..###.#.#.......
....#......#..#.#.......#..##..
.....#..#.#.##.##..##.....#.#..
...#....................##.....
#.....#...##...#.#.............
..#.#...#.#.#.....##..#....#...";

        public static List<List<string>> ParsedInput
        {
            get
            {
                var parsed = new List<List<string>>();
                var lines = Input.Trim().Split("\r\n", StringSplitOptions.None);
                foreach(var line in lines)
                {
                    var parsedLine = line.Trim().ToCharArray().Select(x => x.ToString()).ToList();
                    parsed.Add(parsedLine);
                }

                return parsed;
            }
        }

        public static int Solve()
        {
            var stepX = 3;
            var stepY = 1;

            var trees = 0;

            var currentPosition = new Tuple<int, int>(0, 0);
            do
            {
                Console.Out.Write($"x: {currentPosition.Item1}, y: {currentPosition.Item2}");

                if (IsTree(currentPosition.Item1, currentPosition.Item2))
                {
                    Console.Out.Write("\tTree!");
                    trees++;
                }

                currentPosition = new Tuple<int, int>(currentPosition.Item1 + stepX, currentPosition.Item2 + stepY);

                Console.Out.WriteLine();
            } 
            while (IsEnd(currentPosition.Item1, currentPosition.Item2) == false);

            return trees;

        }

        public static bool IsEnd(int x, int y)
        {
            if (y > ParsedInput.Count - 1)
            {
                return true;
            }

            return false;
        }

        public static bool IsTree(int x, int y)
        {
            var line = ParsedInput[y];

            var pos = FindLinePos(line, x);

            if (pos == "#")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Since the lines repeat infinitely, this helper method handles that repetition.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static string FindLinePos(List<string> line, int pos)
        {
            var realPos = pos;
            if (realPos > line.Count)
            {
                realPos = realPos - line.Count;
                Console.Out.Write($"\t{pos} > {line.Count} - realPos: {realPos}");
            }

            return line[realPos];
        }
    }
}