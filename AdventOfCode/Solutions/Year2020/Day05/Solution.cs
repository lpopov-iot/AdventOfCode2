using System;
using System.Collections.Generic;
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

                var seatId = row * 8 + column;
                curMaxSeatId = seatId > curMaxSeatId ? seatId : curMaxSeatId;
            }

            return curMaxSeatId.ToString();
        }

        private int BSPFind(int min, int max, char[] instruction)
        {
            var mid = (min + max + 1) / 2;

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

            return mid - 1;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
