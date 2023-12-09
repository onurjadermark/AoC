namespace Solutions.Solutions._2023;

public class Day09
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
        var sum = 0L;
        foreach (var numbers in input.Select(x => x.Split(' ').Select(long.Parse).ToArray()).ToArray())
        {
            var cur = numbers.ToList();
            var diffs = new List<List<long>> {cur};
            while (cur.Any(x => x != 0))
            {
                cur = cur.Zip(cur.Skip(1)).Select(x => x.Second - x.First).ToList();
                diffs.Add(cur);
            }

            sum += diffs.Select((x, i) => part == 1 ? x.Last() : x.First() * (i % 2 == 0 ? 1 : -1)).Sum();
        }

        return sum;
    }
}