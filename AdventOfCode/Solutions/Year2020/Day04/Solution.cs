using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day04 : ASolution
    {
        string[] _input;

        public Day04() : base(04, 2020, "")
        {
            _input = Input.Split(new string[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < _input.Length; i++)
            {
                _input[i] = _input[i].Replace(Environment.NewLine, " ");
            }
        }

        protected override string SolvePartOne()
        {
            int validPassports = 0;
            foreach (var data in _input)
            {
                var dataDict = data.Split(" ")
                    .Select(s => s.Split(':'))
                    .ToDictionary(k => k[0], v => v[1]);

                foreach (var field in _expectedFields)
                {
                    if (field != "cid" && !dataDict.ContainsKey(field))
                    {
                        validPassports--;
                        break;
                    }
                }

                validPassports++;
            }

            return validPassports.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }

        private string[] _expectedFields = new[]
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
            "cid"
        };
    }
}
