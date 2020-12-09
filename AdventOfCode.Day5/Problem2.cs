using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day5
{
    public class Problem2
    {
        public static int Solve()
        {
            var takenSeats = Problem1.Input.Trim().Split("\r\n", StringSplitOptions.None).Select(Problem1.ParseSeat).ToList();

            // build a big list of all the possible seats on the plane
            var availableSeats = new List<Problem1.Seat>();
            foreach (var row in Enumerable.Range(0, 127 + 1))
            {
                foreach (var column in Enumerable.Range(0, 7 + 1))
                {
                    availableSeats.Add(new Problem1.Seat()
                    {
                        Row = row,
                        Column = column,
                    });
                }
            }

            // now, filter the available list down to only those seats which we don't have a boarding pass for
            var missingSeats = availableSeats.Where(seat => takenSeats.Any(ts => ts.Row == seat.Row && ts.Column == seat.Column) == false).ToList();

            return 0;
        }
    }
}