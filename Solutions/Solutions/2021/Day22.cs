namespace Solutions.Solutions._2021;

public class Day22
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
        var grid = new List<Cube>();
        foreach (var cube in Parse(input.TakeWhile(x => part == 2 || x.Length < 40).ToArray()))
        {
            foreach (var existingCube in grid.ToList())
            {
                if (!AreIntersecting(cube, existingCube)) continue;
                var intersection = Intersect(cube, existingCube);
                intersection.Value = !existingCube.Value;
                grid.Add(intersection);
            }

            if (cube.Value) grid.Add(cube);
        }

        return grid.Sum(x => x.Size());
    }

    private bool AreIntersecting(Cube a, Cube b)
    {
        return !(a.X1 > b.X2 || a.X2 < b.X1 || a.Y1 > b.Y2 || a.Y2 < b.Y1 || a.Z1 > b.Z2 || a.Z2 < b.Z1);
    }

    private Cube Intersect(Cube a, Cube b)
    {
        return new Cube(Math.Max(a.X1, b.X1), Math.Min(a.X2, b.X2), Math.Max(a.Y1, b.Y1), Math.Min(a.Y2, b.Y2),
            Math.Max(a.Z1, b.Z1), Math.Min(a.Z2, b.Z2));
    }

    private List<Cube> Parse(string[] input)
    {
        return (from line in input
            let split = line.Split(new[] {'=', '.', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsNumber(x[0]) || x[0] == '-')
                .Select(int.Parse)
                .ToList()
            select new Cube(split[0], split[1], split[2], split[3], split[4], split[5], line[1] == 'n')).ToList();
    }

    private class Cube
    {
        public readonly long X1, X2, Y1, Y2, Z1, Z2;

        public Cube(long x1, long x2, long y1, long y2, long z1, long z2, bool value = false)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            Z1 = z1;
            Z2 = z2;
            Value = value;
        }

        public bool Value { get; set; }

        public long Size()
        {
            return (X2 - X1 + 1) * (Y2 - Y1 + 1) * (Z2 - Z1 + 1) * (Value ? 1 : -1);
        }
    }
}