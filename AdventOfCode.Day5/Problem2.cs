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

            // we're told that our seat is not the very front or back, so eliminate those two rows
            missingSeats = missingSeats.Where(seat => seat.Row != 0 && seat.Row != availableSeats.Max(x => x.Row)).ToList();

            // at this point it's pretty obvious from looking at the list what the answer is, but here goes...

            // we're also told that the ID of our seat +1 and -1 is in the list of taken seats
            missingSeats = missingSeats.Where(seat =>
                takenSeats.Any(ts => ts.Id == seat.Id + 1) && takenSeats.Any(ts => ts.Id == seat.Id - 1)).ToList();

            return missingSeats.Select(x => x.Id).Single();
        }
    }
}