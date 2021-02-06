using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            int validPassports = 0;
            foreach (var data in _input)
            {
                var dataDict = data.Split(" ")
                    .Select(s => s.Split(':'))
                    .ToDictionary(k => k[0], v => v[1]);
                foreach (var field in _expectedFields)
                {
                    if (field != "cid" && (!dataDict.TryGetValue(field, out string value) || !IsValidPassportField(field, value)))
                    {
                        validPassports--;
                        break;
                    }
                }

                validPassports++;
            }

            return validPassports.ToString();
        }

        private bool IsValidPassportField(string field, string value)
        {
            switch (field)
            {
                case "byr":
                    var intValByr = Int32.Parse(value);
                    return value.Length == 4 && intValByr >= 1920 && intValByr <= 2002;
                case "iyr":
                    var intValIyr = Int32.Parse(value);
                    return value.Length == 4 && intValIyr >= 2010 && intValIyr <= 2020;
                case "eyr":
                    var intValEyr = Int32.Parse(value);
                    return value.Length == 4 && intValEyr >= 2020 && intValEyr <= 2030;
                case "hgt":
                    var isNum = Int32.TryParse(value.Substring(0, value.Length - 2), out int intValhgt);
                    if (isNum)
                    {
                        var unitSpaces = value.Substring(value.Length - 2);

                        if (unitSpaces == "cm")
                        {
                            return intValhgt >= 150 && intValhgt <= 193;
                        }

                        if(unitSpaces == "in")
                        {
                            return intValhgt >= 59 && intValhgt <= 76;
                        }
                    }
                    return false;
                case "hcl":
                    return Regex.Match(value, @"^#(?:[0-9a-f]{6})$").Success;
                case "ecl":
                    return _allowedEyeColours.Contains(value);
                case "pid":
                    return Regex.Match(value, @"^\d{9}$").Success;
                case "cid":
                    return true;
            }

            return true;
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

        private HashSet<string>_allowedEyeColours = new HashSet<string>()
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };
    }
}
