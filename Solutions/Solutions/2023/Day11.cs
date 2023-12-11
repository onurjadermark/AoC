using Solutions.Utils;

namespace Solutions.Solutions._2023;

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

    private static long Solve(string[] input, int part)
    {
        var emptyRows = GetEmptyRowIndices(input);
        var emptyColumns = GetEmptyRowIndices(StringArrayUtils.RotateStringArray(input));
        var nodes = GridFactory.FromInputStrings(input).Nodes.Where(x => x.Value == '#').ToList();

        var sum = 0L;
        foreach (var node1 in nodes)
        {
            foreach (var node2 in nodes.Where(x => x.Id > node1.Id))
            {
                var distance = (long) node1.ManhattanDistance(node2);
                var x1 = Math.Min(node1.X, node2.X);
                var x2 = Math.Max(node1.X, node2.X);
                var y1 = Math.Min(node1.Y, node2.Y);
                var y2 = Math.Max(node1.Y, node2.Y);
                distance += emptyColumns.Count(x => x > x1 && x < x2) * (part == 1 ? 1 : 999999);
                distance += emptyRows.Count(x => x > y1 && x < y2) * (part == 1 ? 1 : 999999);
                sum += distance;
            }
        }

        return sum;
    }

    private static List<int> GetEmptyRowIndices(IEnumerable<string> input)
    {
        return input.Select((x, i) => (IsEmpty: x.All(y => y == '.'), i)).Where(x => x.IsEmpty).Select(x => x.i).ToList();
    }
}