using Solutions.Utils;

namespace Solutions.Solutions._2021;

public class Day15
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
        var size = input.Length * (part == 1 ? 1 : 5);
        var grid = new Grid<int>(size, size, false);
        var risk = new int[size, size];

        for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
        {
            grid[i, j].Value =
                (input[i % input.Length][j % input.Length] - 1 - '0' + i / input.Length + j / input.Length) % 9 + 1;
            risk[i, j] = int.MaxValue;
        }

        var queue = new Queue<Node<int>>();
        queue.Enqueue(grid[0, 0]);
        risk[0, 0] = 0;
        while (queue.Any())
        {
            var cur = queue.Dequeue();
            var curRisk = risk[cur.X, cur.Y];
            var neighbors = cur.Neighbors.Where(x => curRisk + x.Value < risk[x.X, x.Y]).ToList();
            neighbors.ForEach(x => risk[x.X, x.Y] = curRisk + x.Value);
            neighbors.ForEach(x => queue.Enqueue(x));
        }

        return risk[size - 1, size - 1];
    }
}