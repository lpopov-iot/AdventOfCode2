using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day03 : ASolution
    {
        string[] _input;

        const char OPEN = '.';
        const char TREE = '#';

        public Day03() : base(03, 2020, "")
        {
            _input = Input.Split("\n");
        }

        protected override string SolvePartOne()
        {
            return TreesHitAfterSteps(3, 1).ToString();
        }

        private int TreesHitAfterSteps(int movesX, int movesY)
        {
            int treesHit = 0;
            int levelLoc = 0;
            int lenLevel = _input[0].Length;

            for (int i = 0; i < _input.Length; i = i + movesY)
            {
                if (_input[i][levelLoc] == TREE)
                {
                    treesHit++;
                }

                levelLoc += movesX;

                if (levelLoc > lenLevel - 1)
                {
                    levelLoc = Math.Abs(lenLevel - levelLoc);
                }
            }

            return treesHit;
        }

        protected override string SolvePartTwo()
        {

            BigInteger result = 214;

            {
                var inputs = new (int, int)[]
                {
                    (1, 1),
                    (5, 1),
                    (7, 1),
                    (1, 2)
                };

                foreach (var input in inputs)
                {
                    var hit = TreesHitAfterSteps(input.Item1, input.Item2);

                    result = result * hit;
                }

                return result.ToString();
            }
        }
    }
}
