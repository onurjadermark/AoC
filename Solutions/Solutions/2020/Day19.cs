using System.Text.RegularExpressions;

namespace Solutions.Solutions._2020;

public static class StringExtensionMethods
{
    public static string ReplaceFirst(this string text, string search, string replace, int pos)
    {
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }
}

public class Day19
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
        var messages = new List<string>();
        var rules = new Dictionary<string, string>();
        var doneWithRules = false;
        foreach (var line in input.Select(x => x.Trim().Replace("\"", "")))
        {
            if (string.IsNullOrWhiteSpace(line)) doneWithRules = true;

            if (doneWithRules)
            {
                messages.Add(line);
                continue;
            }

            rules.Add(line.Split(":").First().Trim(), line.Split(":").Last().Trim());
        }

        if (part == 2)
        {
            rules["8"] = "42 | 42 42 | 42 42 42 | 42 42 42 42 | 42 42 42 42 42";
            rules["11"] =
                "42 31 | 42 42 31 31 | 42 42 42 31 31 31 | 42 42 42 42 31 31 31 31 | 42 42 42 42 42 31 31 31 31 31";
        }

        var rule = rules["0"];
        while (true)
        {
            var cur = "";
            var index = -1;
            for (var i = 0; i < rule.Length; i++)
            {
                var c = rule[i];
                if (c >= '0' && c <= '9')
                {
                    cur += c;
                    if (index == -1) index = i;
                }
                else if (cur.Length > 0)
                {
                    break;
                }
            }

            if (index == -1) break;

            var matchingRule = rules[cur];
            if (matchingRule.Contains("|"))
            {
                var split = matchingRule.Split("|").Select(x => "(" + x.Trim() + ")").ToList();
                matchingRule = "(" + string.Join("|", split) + ")";
            }
            else if (!matchingRule.Contains("a") && !matchingRule.Contains("b"))
            {
                matchingRule = "(" + matchingRule + ")";
            }

            rule = rule.ReplaceFirst(cur, matchingRule, index);
        }

        rule = "^" + rule.Replace(" ", "") + "$";
        var regex = new Regex(rule);

        var count = 0;
        foreach (var message in messages)
        {
            var match = regex.Match(message);
            if (match.Success) count++;
        }


        return count;
    }
}