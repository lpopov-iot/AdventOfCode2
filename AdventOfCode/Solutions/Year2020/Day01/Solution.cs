using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day01 : ASolution
    {

        public Day01() : base(01, 2020, "")
        {
            
        }

        protected override string SolvePartOne()
        {
            var target = 2020;
            var seen = new HashSet<int>();

            var nums = Input.Split("\n");
            
            foreach (var numStr in nums)
            {
                if (Int32.TryParse(numStr, out var num))
                {
                    var difference = target - num;
                    
                    if (difference > 0)
                    {
                        if (seen.TryGetValue(difference, out var found))
                        {
                            return (num * found).ToString();
                        }

                        seen.Add(num);
                    }
                }
            }

            return null;
        }

        protected override string SolvePartTwo()
        {
            var target = 2020;

            var arr = Input.Split("\n");
            
            var input =  Array.ConvertAll(arr, int.Parse);
            Array.Sort(input);
            
            for (var i = 0; i < input.Length - 1; i++)
            {
                var set = new HashSet<int>();

                var diffInitial = target - input[i];
                
                for (var j = i + 1; j < input.Length; j++)
                {
                    var nextDiffNeeded = diffInitial - input[j];
                    
                    if (set.TryGetValue(nextDiffNeeded, out var finalDiff))
                    {
                        return (input[i] * input[j] * finalDiff).ToString();
                    }

                    set.Add(input[j]);
                }
            }

            return null;
        }
    }
}
