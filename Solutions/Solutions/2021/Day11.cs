using Solutions.Utils;

namespace Solutions.Solutions._2021;

public class Day11
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
        var grid = new Grid<int>(input.Length, input[0].Length, true);
        grid.Nodes.ForEach(x => x.Value = input[x.X][x.Y] - '0');

        var count = 0;
        for (var t = 0; t < (part == 1 ? 100 : 1000); t++)
        {
            var flashed = new Dictionary<Node<int>, bool>();

            grid.Nodes.ForEach(x => x.Value++);

            grid.Nodes.Where(x => x.Value == 10).ForEach(x => Flash(grid, x, flashed));
            flashed.ForEach(x => x.Key.Value = 0);
            count += flashed.Count;

            if (part == 2 && flashed.Count == grid.Width * grid.Height) return t + 1;
        }

        return count;
    }

    private void Flash(Grid<int> grid, Node<int> node, Dictionary<Node<int>, bool> flashed)
    {
        if (flashed.ContainsKey(node)) return;
        flashed[node] = true;
        var neighbors = grid[node.X, node.Y].Neighbors;
        neighbors = neighbors.Where(x => !flashed.ContainsKey(x)).ToList();
        neighbors.ForEach(x => x.Value++);
        neighbors.Where(x => x.Value > 9).ForEach(x => Flash(grid, x, flashed));
    }
}