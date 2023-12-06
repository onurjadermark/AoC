namespace Solutions.Solutions._2023;

public class Day06
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static int Solve(string[] input, int part)
    {
        var times = input[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
        var distances = input[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();

        if (part == 2)
        {
            times = new[] {long.Parse(string.Join("", times))};
            distances = new[] {long.Parse(string.Join("", distances))};
        }

        var counts = new List<int>();

        for (var i = 0; i < times.Length; i++)
        {
            counts.Add((int) GetCount(times[i], distances[i]));
        }

        return counts.Where(x => x != 0).Aggregate((x, y) => x * y);
    }

    private static long GetCount(long time, long distance)
    {
        var disc = time * time - 4 * distance;
        var min = (long) (time - Math.Sqrt(disc)) / 2 + 1;
        var max = time - min;
        return max - min + 1;
    }
}