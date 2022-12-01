namespace Solutions.Solutions._2021;

public class Day05
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private int Solve(string[] input, int part)
    {
        var dict = new Dictionary<(int, int), int>();
        foreach (var line in input.Select(x => x.Split(" -> ")))
        {
            var (x1, y1) = ParsePosition(line[0]);
            var (x2, y2) = ParsePosition(line[1]);

            if (part == 1 && x1 != x2 && y1 != y2) continue;

            var diff = Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
            for (var z = 0; z <= diff; z++)
            {
                var x = x1 + (x1 == x2 ? 0 : x1 < x2 ? z : -z);
                var y = y1 + (y1 == y2 ? 0 : y1 < y2 ? z : -z);
                dict[(x, y)] = dict.ContainsKey((x, y)) ? dict[(x, y)] + 1 : 1;
            }
        }

        return dict.Values.Count(x => x > 1);
    }

    private static (int, int) ParsePosition(string position)
    {
        var split = position.Split(",");
        return (int.Parse(split[0]), int.Parse(split[1]));
    }
}