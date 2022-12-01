namespace Solutions.Solutions._2021;

public class Day14
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(string[] input, int part)
    {
        var rulesDict = GetRules(input.Skip(2));
        var counts = GetCounts(input[0]);

        for (var i = 0; i < (part == 1 ? 10 : 40); i++) counts = Iterate(counts, rulesDict);

        var chars = new Dictionary<char, long>();
        foreach (var (key, value) in counts)
        {
            chars[key[0]] = chars.GetValueOrDefault(key[0]) + value;
            chars[key[1]] = chars.GetValueOrDefault(key[1]) + value;
        }

        chars.Remove('*');
        return (chars.OrderBy(x => x.Value).Last().Value - chars.OrderBy(x => x.Value).First().Value) / 2;
    }

    private static Dictionary<string, long> Iterate(Dictionary<string, long> counts,
        Dictionary<string, string> rulesDict)
    {
        var newCounts = new Dictionary<string, long>(counts);
        foreach (var (ruleFrom, ruleTo) in rulesDict)
        {
            if (!counts.ContainsKey(ruleFrom)) continue;
            var first = ruleFrom[0] + ruleTo;
            var second = ruleTo + ruleFrom[1];
            var prevCount = counts[ruleFrom];
            newCounts[ruleFrom] = newCounts.GetValueOrDefault(ruleFrom) - prevCount;
            newCounts[first] = newCounts.GetValueOrDefault(first) + prevCount;
            newCounts[second] = newCounts.GetValueOrDefault(second) + prevCount;
        }

        counts = newCounts;
        return counts;
    }

    private static Dictionary<string, string> GetRules(IEnumerable<string> input)
    {
        return input.Select(x => x.Split(" -> ")).ToDictionary(x => x[0], x => x[1]);
    }

    private static Dictionary<string, long> GetCounts(string str)
    {
        var counts = new Dictionary<string, long>();
        counts["*" + str[0]] = 1;
        counts[str[^1] + "*"] = 1;
        for (var i = 0; i < str.Length - 1; i++)
        {
            var substring = str.Substring(i, 2);
            counts[substring] = counts.GetValueOrDefault(substring) + 1;
        }

        return counts;
    }
}