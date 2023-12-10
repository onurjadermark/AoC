using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day10
{
    private static readonly Dictionary<char, (int X, int Y)[]> Map = new()
    {
        {'.', Array.Empty<(int X, int Y)>()},
        {'|', new[] {(0, -1), (0, 1)}},
        {'-', new[] {(-1, 0), (1, 0)}},
        {'F', new[] {(1, 0), (0, 1)}},
        {'J', new[] {(-1, 0), (0, -1)}},
        {'7', new[] {(-1, 0), (0, 1)}},
        {'L', new[] {(1, 0), (0, -1)}},
        {'S', new[] {(0, -1), (0, 1), (-1, 0), (1, 0)}}
    };

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
        var grid = GridFactory.FromInputStrings(input);
        var loop = GetLoopNodes(grid);
        ReplaceStartNode(loop);
        return part == 1 ? loop.Count / 2 : GetEnclosedNodes(grid, loop).Count;
    }

    private static void ReplaceStartNode(HashSet<Node<char>> loop)
    {
        var start = loop.Single(x => x.Value == 'S');
        var neighbors = new List<Node<char>> {loop.ElementAt(1), loop.Last()};
        var diffs = neighbors.Select(x => (x.X - start.X, x.Y - start.Y)).ToList();
        var key = Map.Keys.Skip(1).Single(x => Map[x].All(y => diffs.Contains(y)));
        start.Value = key;
    }

    private static HashSet<Node<char>> GetLoopNodes(Grid<char> grid)
    {
        var cur = grid.Nodes.Single(x => x.Value == 'S');
        var loop = new HashSet<Node<char>>();
        while (cur != null)
        {
            loop.Add(cur);
            cur = cur.Neighbors.FirstOrDefault(x => !loop.Contains(x) && IsConnected(x, cur));
        }

        return loop;
    }

    private static List<Node<char>> GetEnclosedNodes(Grid<char> grid, HashSet<Node<char>> loop)
    {
        var enclosedNodes = new List<Node<char>>();
        for (var j = 0; j < grid.Height; j++)
        {
            var enclosed = false;
            for (var i = 0; i < grid.Width; i++)
            {
                var node = grid[i, j];
                if (loop.Contains(node) && node.Value == '|')
                {
                    enclosed = !enclosed;
                }
                else if (loop.Contains(node) && Map[node.Value].Contains((1, 0)))
                {
                    var next = node;
                    while (true)
                    {
                        next = next.Right;
                        if (next!.Value == '-') continue;
                        if (!Map[node.Value].Intersect(Map[next.Value]).Any())
                        {
                            enclosed = !enclosed;
                        }

                        break;
                    }
                }
                else if (!loop.Contains(node) && enclosed)
                {
                    enclosedNodes.Add(node);
                }
            }
        }

        return enclosedNodes;
    }

    private static bool IsConnected(Node<char> node1, Node<char> node2)
    {
        var coords1 = Map[node1.Value].Select(x => (node1.X + x.X, node1.Y + x.Y));
        var coords2 = Map[node2.Value].Select(x => (node2.X + x.X, node2.Y + x.Y));
        return coords1.Contains((node2.X, node2.Y)) && coords2.Contains((node1.X, node1.Y));
    }
}