using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day02 : ASolution
    {
        string[] _input;
        
        public Day02() : base(02, 2020, "")
        {
            _input = Input.Split("\n");
        }

        protected override string SolvePartOne()
        {
            int returnSum = 0;
            
            foreach (var line in _input)
            {
                var policy = ExtractPolicy(line);
            }
            return returnSum.ToString();
        }

        record Challenge
        {
            public Policy Policy;
            public string Password { get; init; }
        }
        
        record Policy
        {
            public char? ChallengeChar { get; init; }
            public string LowerBound { get; init; }
            public string UpperBound { get; init; }
        }

        private Challenge ExtractPolicy(string line)
        {
            return new Challenge();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
