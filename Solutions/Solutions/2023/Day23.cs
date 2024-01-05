using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day23
{
    public int Part1(string[] input)
    {
        return Solve(input);
    }

    public int Part2(string[] input)
    {
        return Solve(RemoveSlopes(input));
    }

    private int Solve(string[] input)
    {
        var grid = GridFactory.FromInputStrings(input);
        var segments = FindPathSegments(grid);

        var start = grid[1, 0];
        var longest = 0;
        var queue = new Queue<(Node<char> Node, HashSet<Node<char>> PassedIntersections, int PathLength)>();
        queue.Enqueue((start, [start], 0));
        while (queue.Any())
        {
            var (node, passedIntersections, pathLength) = queue.Dequeue();
            if (node.Y == grid.Height - 1)
            {
                if (longest < pathLength)
                {
                    longest = pathLength;
                }

                continue;
            }

            var nextSegments = segments[node].Where(x => !passedIntersections.Contains(x.End));
            foreach (var nextSegment in nextSegments)
            {
                queue.Enqueue((nextSegment.End, [nextSegment.End, ..passedIntersections], pathLength + nextSegment.Length));
            }
        }

        return longest;
    }

    private static Dictionary<Node<char>, List<(Node<char> End, int Length)>> FindPathSegments(Grid<char> grid)
    {
        var junctions = new List<Node<char>>();
        foreach (var node in grid.Nodes)
        {
            if (node.Value == '#') continue;
            if (node.Y == 0 || node.Y == grid.Height - 1) junctions.Add(node);
            if (node.Neighbors.Count(x => x.Value != '#') > 2) junctions.Add(node);
        }

        var segments = new Dictionary<Node<char>, List<(Node<char> End, int Length)>>();
        foreach (var junction in junctions.Where(x => x.Y < grid.Height - 1))
        {
            var queue = new Queue<(Node<char> Start, HashSet<Node<char>> Path)>();
            queue.Enqueue((junction, [junction]));

            while (queue.TryDequeue(out var next))
            {
                var (node, path) = next;
                foreach (var neighbor in node.Neighbors)
                {
                    switch (neighbor.Value)
                    {
                        case '>':
                            if (neighbor.X != node.X + 1) continue;
                            break;
                        case 'v':
                            if (neighbor.Y != node.Y + 1) continue;
                            break;
                    }

                    if (path.Contains(neighbor) || neighbor.Value == '#') continue;
                    if (neighbor.Y == 0) continue;
                    if (junctions.Contains(neighbor))
                    {
                        if (!segments.ContainsKey(junction)) segments[junction] = [];
                        segments[junction].Add((neighbor, path.Count));
                    }
                    else
                    {
                        queue.Enqueue((neighbor, [neighbor, ..path]));
                    }
                }
            }
        }

        return segments;
    }

    private static string[] RemoveSlopes(string[] str) => str.Select(x => x.Replace(">", ".").Replace("v", ".")).ToArray();
}