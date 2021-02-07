using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day05 : ASolution
    {

        string[] _input;

        public Day05() : base(05, 2020, "")
        {
            _input = Input.Split("\n");
        }

        protected override string SolvePartOne()
        {
            var curMaxSeatId = 0;

            foreach (var instruction in _input)
            {
                var row = BSPFind(0, 127, instruction.Substring(0, instruction.Length - 3).ToCharArray());
                var column = BSPFind(0, 7, instruction.Substring(instruction.Length - 3).ToCharArray());

                var seatId = GetSeatId(row, column);
                curMaxSeatId = seatId > curMaxSeatId ? seatId : curMaxSeatId;
            }

            return curMaxSeatId.ToString();
        }

        protected override string SolvePartTwo()

        {
            var seats = new List<Tuple<int, int>>();
            foreach (var instruction in _input)
            {
                var row = BSPFind(0, 127, instruction.Substring(0, instruction.Length - 3).ToCharArray());
                var column = BSPFind(0, 7, instruction.Substring(instruction.Length - 3).ToCharArray());

                seats.Add(new Tuple<int, int>(row, column));
            }

            var orderedSeats = seats.OrderBy(tuple => tuple.Item1)
                .ThenBy(tuple => tuple.Item2).ToList();

            for (var i = 0; i < 127; i++)
            {
                var row = orderedSeats.Where(x => x.Item1 == i).ToList();

                if (row.Any())
                {
                    for (var x = 0; x < row.Count - 1; x++)
                    {
                        if (row[x + 1].Item2 - row[x].Item2 == 2)
                        {
                            return GetSeatId(row[x].Item1, row[x].Item2 + 1).ToString();
                        }
                    }
                }
            }

            return null;
        }

        private int GetSeatId(int row, int column)
        {
            return  row * 8 + column;
        }

        private int BSPFind(int min, int max, char[] instruction)
        {
            var mid = (min + max) / 2;

            for (var i = 0; i < instruction.Length; i++)
            {
                if (instruction[i] == 'F' || instruction[i] == 'L')
                {
                    return BSPFind(min, mid, instruction[(i+1)..]);
                }

                if (instruction[i] == 'B' || instruction[i] == 'R')
                {
                    return BSPFind(mid, max, instruction[(i+1)..]);
                }
            }

            return mid + 1;
        }
    }
}
