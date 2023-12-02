namespace Solutions.Solutions._2023;

public class Day02
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
        var sum = 0;

        foreach (var line in input)
        {
            var id = GetId(line);
            var counts = GetCounts(line);

            if (part == 1)
            {
                sum += IsPart1Possible(counts) ? id : 0;
            }
            else
            {
                sum += GetPart2Sum(counts);
            }
        }

        return sum;
    }

    private static bool IsPart1Possible((string Color, int Count)[] counts)
    {
        return counts.All(c => c.Color switch
        {
            "red" => c.Count <= 12,
            "green" => c.Count <= 13,
            "blue" => c.Count <= 14,
            _ => throw new Exception("Invalid color")
        });
    }

    private static int GetPart2Sum((string Color, int Count)[] counts)
    {
        var redMax = counts.Where(x => x.Color == "red").MaxBy(x => x.Count).Count;
        var greenMax = counts.Where(x => x.Color == "green").MaxBy(x => x.Count).Count;
        var blueMax = counts.Where(x => x.Color == "blue").MaxBy(x => x.Count).Count;

        return redMax * greenMax * blueMax;
    }

    private static int GetId(string line)
    {
        return int.Parse(line.Split(':')[0][4..]);
    }

    private static (string Color, int Count)[] GetCounts(string line)
    {
        return line.Split(':')[1].Split(';')
            .SelectMany(s => s.Split(',').Select(x => x.Trim()))
            .Select(x => (x.Split(" ")[1], int.Parse(x.Split(" ")[0]))).ToArray();
    }
}