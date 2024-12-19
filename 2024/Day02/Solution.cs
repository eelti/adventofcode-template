namespace AdventOfCode.Y2024.Day02;

using System;
using System.Collections.Generic;
using System.Linq;

[ProblemName("Red-Nosed Reports")]
class Solution : Solver {

    public object PartOne(string input) {
        var lines = input.Split("\n");
        var counter = 0;
        foreach (var line in lines) {
            var ll = line.Split(" ").ToList();
            var tester = Sol1(ll);
                       if (ll.Count -1 == tester) {
                counter++;
            }
        }
        return counter;
    }

    private static int Sol1(List<string> ll) {
                bool isInc = int.Parse(ll[0]) < int.Parse(ll[1]);
        var counter = 0;
        for (int i = 0; i < ll.Count - 1; i++) {
            var validator = Math.Abs(int.Parse(ll[i]) - int.Parse(ll[i+ 1]));
            if (validator > 3 || validator == 0 || (int.Parse(ll[i]) < int.Parse(ll[i + 1])) != isInc) {
                continue;
            };
            if (ll.Count > 0) counter++;
        }
        return counter;
    }
    public object PartTwo(string input) {
               var lines = input.Split("\n");
        var counter = 0;
        foreach (var line in lines) {
            var ll = line.Split(" ").ToList();
            var objective = ll.Count() -1;
            for (int i = 0; i < ll.Count; i++) {
                var ll2 = new List<string>(ll);
                ll2.RemoveAt(i);
                var sol1 = Sol1( ll2);
                if (sol1 == ll2.Count - 1)
                {
                    counter++;
                    break;
                };
            }
        }
        return counter;
    }

}