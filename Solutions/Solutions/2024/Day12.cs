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
            var queue = new Queue<Node<char>>();
            queue.Enqueue(node);
            var perimeterNodes = new HashSet<(Node<char> Node, (int X, int Y) Direction)>();
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
                        perimeterNodes.Add((current, direction));
                    }
                }
                
                foreach (var neighbor in current.GetOrthogonalNeighbors().Where(x => x.X == current.X || x.Y == current.Y).Where(x => x.Value == current.Value))
                {
                    queue.Enqueue(neighbor);
                }
            }

            var edgeCount = 0;
            var visitedPerimeterNodes = new HashSet<(Node<char> Node, (int X, int Y) Direction)>();
            foreach (var perimeterNode in perimeterNodes)
            {
                if (visitedPerimeterNodes.Contains(perimeterNode)) continue;
                edgeCount++;
                visitedPerimeterNodes.Add(perimeterNode);
                foreach (var directionToCheck in new [] {DirectionUtils.TurnLeft(perimeterNode.Direction), DirectionUtils.TurnRight(perimeterNode.Direction)})
                {
                    var next = perimeterNode;
                    while (true)
                    {
                        next = perimeterNodes.FirstOrDefault(x => x.Node == next.Node.Move(directionToCheck) && x.Direction == perimeterNode.Direction);
                        if (next == default) break;
                        visitedPerimeterNodes.Add(next);
                    }
                }
            }
            
            sum += size * (part == 1 ? perimeterNodes.Count : edgeCount);
        }
        
        return sum;
    }
}