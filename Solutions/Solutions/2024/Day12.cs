using MoreLinq;
using Solutions.Utils;

namespace Solutions.Solutions._2024;

public class Day12
{
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
        var grid = GridFactory.FromInputStrings(input, true);
        var sum = 0;
        var visited = new HashSet<Node<char>>();
        var directions = DirectionUtils.GetOrthogonalDirections();

        foreach (var node in grid.Nodes)
        {
            var size = 0;
            if (visited.Contains(node)) continue;
            
            var edgeParts = new HashSet<(Node<char> Node, (int X, int Y) Direction)>();
            var queue = new Queue<Node<char>>();
            queue.Enqueue(node);
            
            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (!visited.Add(current)) continue;
                size++;

                foreach (var direction in directions)
                {
                    var neighbor = current.GetNeighbor(direction);
                    if (neighbor == null || neighbor.Value != current.Value)
                    {
                        edgeParts.Add((current, direction));
                    }
                }

                current.GetOrthogonalNeighbors()
                    .Where(x => x.Value == current.Value)
                    .ForEach(x => queue.Enqueue(x));
            }

            var edgeCount = 0;
            var visitedEdgeParts = new HashSet<(Node<char> Node, (int X, int Y) Direction)>();
            
            foreach (var edgePart in edgeParts)
            {
                if (!visitedEdgeParts.Add(edgePart)) continue;
                edgeCount++;

                foreach (var directionToCheck in new[] {DirectionUtils.TurnLeft(edgePart.Direction), DirectionUtils.TurnRight(edgePart.Direction)})
                {
                    var cur = edgePart;
                    while (true)
                    {
                        var nextEdge = cur.Node.GetNeighbor(directionToCheck);
                        if (nextEdge == null) break;
                        cur = (nextEdge, cur.Direction);
                        if (!edgeParts.Contains(cur)) break;
                        
                        cur = edgeParts.FirstOrDefault(x => x.Node == nextEdge && x.Direction == edgePart.Direction);
                        visitedEdgeParts.Add(cur);
                    }
                }
            }

            sum += size * (part == 1 ? edgeParts.Count : edgeCount);
        }

        return sum;
    }
}