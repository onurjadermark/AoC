namespace Solutions.Solutions._2020;

public class Day03
{
    public long Part1(string[] input)
    {
        return GetNumTrees(input, 3, 1);
    }

    public long Part2(string[] input)
    {
        var slopes = new[] {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)};
        return slopes.Select(x => GetNumTrees(input, x.Item1, x.Item2)).Aggregate((long) 1, (acc, x) => acc * x);
    }

    private static long GetNumTrees(string[] lines, int right, int down)
    {
        var trees = 0;
        var x = 0;
        for (var i = down; i < lines.Length; i += down)
        {
            var line = lines[i];
            x += right;
            x %= line.Length;
            if (line[x] == '#') trees++;
        }

        return trees;
    }
}