namespace AdventOfCode.Y2024.Day01;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

[ProblemName("Historian Hysteria")]
class Solution : Solver {
    List<int> List1, List2;
    public object PartOne(string input) {

        SplitIn2List(input);

        var mySum = 0;
        for (int i = 0; i < List1.Count; i++) {
            mySum += int.Abs(List1[i] - List2[i]);
        }

        return mySum;
    }

    public object PartTwo(string input) {

        var mySum = 0;
        List1.ForEach((item) => {
            mySum += item * List2.Count(i => i.Equals(item));
        });

        return mySum;
    }

    public void SplitIn2List(string input) {
        List1 = input.Split("\n").Select(s => int.Parse(s.Split(" ").First()
       )).Order().ToList();
        List2 = input.Split("\n").Select(s => int.Parse(s.Split(" ").Last()
       )).Order().ToList();
    }
}