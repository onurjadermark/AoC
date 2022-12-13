using Solutions.Utils;

namespace Solutions.Solutions._2022;

public class Day12
{
    private int _shortestPathLength = int.MaxValue;
    private readonly Dictionary<Node<char>, int> _shortestDistances = new();

    public int Part1(string[] input)
    {
        return Solve(input, 'S', 'E');
    }
    
    public int Part2(string[] input)
    {
        return Solve(input, 'E', 'a');
    }

    private int Solve(string[] input, char startChar, char endChar)
    {
        var grid = new Grid<char>(input.Length, input[0].Length, false);

        for (var i = 0; i < input.Length; i++)
        for (var j = 0; j < input[i].Length; j++)
        {
            grid[i, j].Value = input[i][j];
            _shortestDistances[grid[i, j]] = int.MaxValue;
        }

        var start = grid.Nodes.Single(x => x.Value == startChar);
        var end = grid.Nodes.Where(x => x.Value == endChar).ToList();
        foreach (var node in grid.Nodes)
        {
            if (node.Value == 'S') node.Value = 'a';
            if (node.Value == 'E') node.Value = 'z';
        }

        var isAscending = start.Value < end.First().Value;

        var paths = new Queue<List<Node<char>>>();
        paths.Enqueue(new List<Node<char>>() {start});
        
        while (paths.Any())
        {
            var nodes = paths.Dequeue();
            if (end.Contains(nodes.Last()))
            {
                if (_shortestPathLength > nodes.Count)
                {
                    _shortestPathLength = nodes.Count;
                }
                continue;
            }

            var cur = nodes.Last();
            foreach (var neighbor in cur.Neighbors)
            {
                if (nodes.Contains(neighbor)) continue;
                if (isAscending ? neighbor.Value > cur.Value + 1 : neighbor.Value < cur.Value - 1) continue;
                if (_shortestDistances[neighbor] <= nodes.Count + 1) continue;
                _shortestDistances[neighbor] = nodes.Count + 1;
                var newPath = nodes.ToList();
                newPath.Add(neighbor);
                paths.Enqueue(newPath);
            }
        }

        return _shortestPathLength - 1;
    }
}