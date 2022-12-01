using System.Text.RegularExpressions;

namespace Solutions.Solutions._2020;

public class Day18
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string[] input, int part)
    {
        long sum = 0;
        foreach (var line in input)
        {
            var cur = line.Trim();
            while (true)
            {
                var regex1 = new Regex(@"\(\d+\s\+\s\d+\)");
                var regex2 = new Regex(@"\(\d+\s\*\s\d+\)");
                var regex3 = new Regex(@"\d+\s\+\s\d+");
                var regex4 = new Regex(@"\d+\s\*\s\d+");
                var regex5 = new Regex(@"^\d+$");
                var regex6 = new Regex(@"(?<=\()\d+\s\+\s\d+");
                var regex7 = new Regex(@"\d+\s\*\s\d+(?=\))");

                var match1 = regex1.Match(cur);
                var match2 = regex2.Match(cur);
                var match3 = regex3.Match(cur);
                var match4 = regex4.Match(cur);
                var match5 = regex5.Match(cur);
                var match6 = regex6.Match(cur);
                var match7 = regex7.Match(cur);

                var regexes = new[] {regex1, regex2, regex6, regex3, regex7, regex4, regex5}.ToList();
                var matches = new[] {match1, match2, match6, match3, match7, match4, match5}.ToList();
                var successful = part == 1
                    ? matches.Where(x => x.Success).OrderBy(x => x.Index).Take(1).SingleOrDefault()
                    : matches.First(x => x.Success);

                var multiply = successful == match2 || successful == match7 || successful == match4;

                if (successful == match5)
                {
                    sum += long.Parse(cur);
                    break;
                }

                var regex = regexes[matches.IndexOf(successful!)];
                var match = regex.Match(cur);
                var values = match.Value.Split(multiply ? "*" : "+")
                    .Select(x => x.Replace("(", "").Replace(")", "")).Select(long.Parse);
                var result = values.Aggregate((x, y) => multiply ? x * y : x + y);
                cur = regex.Replace(cur, result.ToString(), 1);
            }
        }

        return sum;
    }
}