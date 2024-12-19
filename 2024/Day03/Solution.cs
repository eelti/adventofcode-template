namespace AdventOfCode.Y2024.Day03;

using System.Text.RegularExpressions;

[ProblemName("Mull It Over")]
class Solution : Solver {

    public object PartOne(string input) {
                var match =Regex.Matches(input, @"mul\(\d{1,99999999},\d{1,99999999}\)");
        var acumulator = 0;
        foreach (Match o in match)
        {
            var extractmultiplier = Regex.Match(o.Value, @"\d{1,999999999},\d{1,999999999}");
            var values = extractmultiplier.Value.Split(",");
            acumulator += int.Parse(values[0]) * int.Parse(values[1]);
           // Console.WriteLine(acumulator);
        }
        return acumulator;
    }

/*     public object PartTwo(string input) {
         var inputCleaned = Regex.Replace(input, @"(don't\(\)).*?(do\(\))","");
         inputCleaned =Regex.Replace(inputCleaned, @"(don't\(\))((.|\n)*)", "");

  //              var inputCleaned =Regex.Replace(input, @"(don't\(\)).*?(do\(\))", "");
    //            inputCleaned =Regex.Match(inputCleaned, @".*?(?<=don't\(\))").Value;
        var match =Regex.Matches(inputCleaned, @"mul\(\d{1,99999999},\d{1,99999999}\)");
        var acumulator = 0;
        foreach (Match o in match)
        {
            var extractmultiplier = Regex.Match(o.Value, @"\d{1,99999999},\d{1,99999999}");
            var values = extractmultiplier.Value.Split(",");
            acumulator += int.Parse(values[0]) * int.Parse(values[1]);
           // Console.WriteLine(acumulator);
        }
        return acumulator;
    } */

/* public object PartTwo(string input) {
    var match = Regex.Matches(input, @"(do\(\)|don't\(\)|mul\(\d{1,99999999},\d{1,99999999}\))");
    var acumulator = 0;
    var mulEnabled = true;

    foreach (Match o in match) {
        if (o.Value == "do()") {
            mulEnabled = true;
        } else if (o.Value == "don't()") {
            mulEnabled = false;
        } else if (mulEnabled && o.Value.StartsWith("mul(")) {
            var extractmultiplier = Regex.Match(o.Value, @"\d{1,99999999},\d{1,99999999}");
            var values = extractmultiplier.Value.Split(",");
            acumulator += int.Parse(values[0]) * int.Parse(values[1]);
        }
    }

    return acumulator;
} */
public object PartTwo(string input) {
    var acumulator = 0;
    var mulEnabled = true;
    var regex = new Regex(@"(do\(\)|don't\(\)|mul\((\d+),(\d+)\))");

    foreach (Match match in regex.Matches(input)) {
        if (match.Value == "do()") {
            mulEnabled = true;
        } else if (match.Value == "don't()") {
            mulEnabled = false;
        } else if (mulEnabled && match.Groups[2].Success && match.Groups[3].Success) {
            var val1 = int.Parse(match.Groups[2].Value);
            var val2 = int.Parse(match.Groups[3].Value);
            acumulator += val1 * val2;
        }
    }

    return acumulator;
}

}