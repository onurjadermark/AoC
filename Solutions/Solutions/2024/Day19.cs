namespace Solutions.Solutions._2024;

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

    private long Solve(string[] input, long part)
    {
        var towels = input[0].Split(',').Select(x => x.Trim()).ToHashSet();
        var designs = input.Skip(2).ToArray();
        var max = towels.Max(x => x.Length);
        var dict = new Dictionary<string, (bool IsPossible, long Count)>();

        var result = designs.Select(x => IsPossible(x, towels, max, dict)).ToArray();
        return part == 1 ? result.Count(x => x.IsPossible) : result.Sum(x => x.Count);
    }

    private (bool IsPossible, long Count) IsPossible(string design, HashSet<string> towels, long max, Dictionary<string, (bool IsPossible, long Count)> dict)
    {
        if (dict.TryGetValue(design, out var cached)) return cached;
        if (design.Length == 0) return (true, 1);
        var isPossible = false;
        var count = 0L;
        
        for (var i = 1; i <= Math.Min(design.Length, max); i++)
        {
            if (!towels.Contains(design[..i])) continue;
            var result = IsPossible(design[i..], towels, max, dict);
            isPossible = isPossible || result.IsPossible;
            if (result.IsPossible) count+= result.Count;
        }

        dict[design] = (isPossible, count);
        return (isPossible, count);
    }
}