using System;
using System.Linq;

namespace AdventOfCode.Day1
{
    public class Problem2
    {
        public static int Solve()
        {
            var expenses = Problem1.Expenses.Trim().Split(new string[] { "\n" }, StringSplitOptions.None)
                .Select(x => Convert.ToInt16(x)).ToList();

            foreach (var i in expenses)
            {
                foreach (var j in expenses)
                {
                    foreach (var k in expenses)
                    {
                        if (i + j + k == 2020)
                        {
                            return i * j * k;
                        }
                    }
                }
            }

            throw new Exception("Unable to find match");
        }
    }
}