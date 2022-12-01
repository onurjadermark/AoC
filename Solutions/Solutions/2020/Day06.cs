namespace Solutions.Solutions._2020;

public class Day06
{
    public long Part1(string[] input)
    {
        var count = 0;
        var currentGroup = new List<string>();

        Array.Resize(ref input, input.Length + 1);
        input[^1] = "\n";

        foreach (var line in input)
            if (string.IsNullOrWhiteSpace(line))
            {
                count += currentGroup.Distinct().Count();
                currentGroup.Clear();
            }
            else
            {
                currentGroup = currentGroup
                    .Concat(line.ToList().Select(x => x.ToString()).Where(x => !string.IsNullOrWhiteSpace(x)))
                    .ToList();
            }

        return count;
    }

    public int Part2(string[] input)
    {
        var count = 0;
        var currentGroup = new List<string>();

        Array.Resize(ref input, input.Length + 1);
        input[^1] = "\n";

        foreach (var line in input)
            if (string.IsNullOrWhiteSpace(line))
            {
                foreach (var question in string.Join("", currentGroup).Distinct().Select(x => x.ToString())
                             .Where(x => !string.IsNullOrWhiteSpace(x)))
                    if (currentGroup.All(x => x.Contains(question)))
                        count += 1;
                currentGroup.Clear();
            }
            else
            {
                currentGroup.Add(line);
            }

        return count;
    }
}