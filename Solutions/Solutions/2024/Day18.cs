using MoreLinq;
using Solutions.Utils;

namespace Solutions.Solutions._2024;

public class Day18
{
    public string Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public string Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private string Solve(string[] input, int part)
    {
        var bytes = input.Select(ParseByte).ToArray();
        var size = input.Length < 100 ? 7 : 71;
        var count = input.Length < 100 ? 12 : 1024;

        return part == 1 ? 
            FindPath(bytes.Take(count).ToArray(), size).Value!.ToString()! : 
            Format(Find(bytes, count, x => FindPath(x, size).Value == int.MaxValue));

        string Format(int x) => $"{bytes[x - 1].X},{bytes[x - 1].Y}";
    }
    
    private static int Find((int X, int Y)[] bytes, int count, Func<(int X, int Y)[], bool> condition)
    {
        var low = count;
        var high = bytes.Length;
        while (low < high)
        {
            var mid = (low + high) / 2;
            if (condition(bytes[..mid])) high = mid;
            else low = mid + 1;
        }
        return low;
    }

    private static Node<int?> FindPath((int X, int Y)[] bytes, int size)
    {
        var grid = new Grid<int?>(size, size, false);
        var start = grid[(0, size - 1)];
        var end = grid[(size - 1, 0)];
        grid.Nodes.ForEach(x => x.Value = int.MaxValue);
        bytes.ForEach(x => grid[x.X, size - 1 - x.Y].Value = null);

        var stack = new Queue<(Node<int?> Node, int Distance)>();
        stack.Enqueue((start, 0));
        var visited = new HashSet<Node<int?>>();
        while (stack.Any())
        {
            var current = stack.Dequeue();
        
            if (!visited.Add(current.Node)) continue;

            if (current.Node.Value >= current.Distance)
            {
                current.Node.Value = current.Distance;
            }

            if (current.Node == end) break;

            foreach (var neighbor in current.Node.Neighbors.Where(x => x.Value is not null))
            {
                if (visited.Contains(neighbor)) continue;
                stack.Enqueue((neighbor, current.Distance + 1));
            }
        }

        return end;
    }

    private static (int X, int Y) ParseByte(string line)
    {
        var nums = line.Split(",").Select(int.Parse).ToArray();
        return (nums[0], nums[1]);
    }
}