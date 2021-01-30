using System;
using System.Collections.Generic;
using System.Linq;
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
            
            foreach (var input in _input)
            {
                var challenge = CreateChallenge(input);
                var result = challenge.EvaluatePasswordPart1();
                
                returnSum += result ? 1 : 0;
            }
            return returnSum.ToString();
        }

        protected override string SolvePartTwo()
        {
            int returnSum = 0;
            
            foreach (var input in _input)
            {
                var challenge = CreateChallenge(input);
                var result = challenge.EvaluatePasswordPart2();
                
                returnSum += result ? 1 : 0;
            }
            return returnSum.ToString();
        }
        
        record Challenge
        {
            public Policy Policy;
            public string Password { get; init; }

            public bool EvaluatePasswordPart1()
            {
                if (Policy != null && Password != null)
                {
                    var totalCharOccurences = Password.AllIndexesOf(Policy.ChallengeChar.ToString()).Count();

                    if (totalCharOccurences < Policy.LowerBound || totalCharOccurences > Policy.UpperBound)
                    {
                        return false;
                    }

                    return true;
                }
                return false;
            }
            
            public bool EvaluatePasswordPart2()
            {
                if (Policy != null && Password != null)
                {
                    var lowerChar = Password[Policy.LowerBound - 1];
                    var upperChar = Password[Policy.UpperBound - 1];

                    if (lowerChar == Policy.ChallengeChar ^ upperChar == Policy.ChallengeChar )
                    {
                        return true;
                    }

                    return false;
                }

                return false;
            }
        }
        
        record Policy
        {
            public char? ChallengeChar { get; init; }
            public int LowerBound { get; init; }
            public int UpperBound { get; init; }
        }

        private Challenge CreateChallenge(string line)
        {
            // 5-6 s: zssmssbsms
            var posColon = line.IndexOf(':');
                
            var left = line.Substring(0, posColon - 1).Trim();
            var right = line.Substring(posColon + 1, line.Length - posColon - 1).Trim();

            var bounds = left.Split('-');

            return new Challenge()
            {
                Policy = new Policy()
                {
                    ChallengeChar = line[posColon - 1],
                    LowerBound = Convert.ToInt32(bounds[0]),
                    UpperBound = Convert.ToInt32(bounds[1])
                },
                Password = right
            };
        }
    }
}
