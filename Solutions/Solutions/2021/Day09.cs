using Solutions.Utils;

namespace Solutions.Solutions._2021;

public class Day09
{
    private readonly Dictionary<(int X, int Y), List<(int X, int Y)>> _lowestPointsMemo = new();

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
        var grid = new Grid<int>(input.Length, input[0].Length, false);
        var basins = new Dictionary<(int X, int Y), int>();

        for (var i = 0; i < input.Length; i++)
        for (var j = 0; j < input[i].Length; j++)
            grid[i, j].Value = input[i][j] - '0';

        for (var i = 0; i < grid.Width; i++)
        for (var j = 0; j < grid.Height; j++)
        {
            if (grid[i, j].Value == 9) continue;
            var lowestPoints = GetLowestPoints(grid, i, j);
            if (lowestPoints.Count != 1) continue;
            var lowPoint = lowestPoints.Single();
            basins[lowPoint] = basins.ContainsKey(lowPoint) ? basins[lowPoint] + 1 : 1;
        }

        return part == 1
            ? basins.Select(x => x.Key).Select(x => grid[x.X, x.Y].Value + 1).Sum()
            : basins.OrderByDescending(x => x.Value).Take(3).Select(x => x.Value).Aggregate(1, (x, y) => x * y);
    }

    private List<(int X, int Y)> GetLowestPoints(Grid<int> grid, int i, int j)
    {
        if (_lowestPointsMemo.ContainsKey((i, j))) return _lowestPointsMemo[(i, j)];

        var lowerNeighbors = grid[i, j].Neighbors.Where(z => grid[z.X, z.Y].Value < grid[i, j].Value).ToList();

        var lowestPoints = new List<(int X, int Y)>();
        lowerNeighbors.ForEach(z => lowestPoints.AddRange(GetLowestPoints(grid, z.X, z.Y)));

        if (!lowestPoints.Any()) lowestPoints.Add((i, j));

        return _lowestPointsMemo[(i, j)] = lowestPoints.Distinct().ToList();
    }
}