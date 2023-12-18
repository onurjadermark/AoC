namespace Solutions.Solutions._2023;

public class Day18
{
    public double Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public double Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static double Solve(string[] input, long part)
    { 
        return CalculateArea(GetCorners(input, part));
    }

    private static List<(long X, long Y)> GetCorners(string[] input, long part)
    {
        var instructions = input.Select(x =>
        {
            var split = x.Split(' ');
            return part == 1
                ? (Direction: split[0][0], Count: long.Parse(split[1]))
                : (Direction: "RDLU"[split[2].Skip(7).Take(1).Single() - '0'], Count: Convert.ToInt32(string.Join("", split[2].Skip(2).Take(5)), 16));
        }).ToList();

        var corners = new List<(long X, long Y)>();
        var cur = (X: 0L, Y: 0L);
        foreach (var dig in instructions)
        {
            corners.Add((cur.X, cur.Y));
            cur = dig.Direction switch
            {
                'U' => (cur.X, cur.Y - dig.Count),
                'R' => (cur.X + dig.Count, cur.Y),
                'D' => (cur.X, cur.Y + dig.Count),
                'L' => (cur.X - dig.Count, cur.Y),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        return corners;
    }
    
    static double CalculateArea(List<(long X, long Y)> corners)
    {
        var pairs = corners.Zip(corners.Skip(1).Concat([corners[0]]));

        var area = 0.0;
        foreach (var pair in pairs)
        {
            area += pair.First.X * pair.Second.Y - pair.Second.X * pair.First.Y;
            area += Math.Abs(pair.First.X - pair.Second.X) + Math.Abs(pair.First.Y - pair.Second.Y);
        }

        return area / 2 + 1;
    }
}