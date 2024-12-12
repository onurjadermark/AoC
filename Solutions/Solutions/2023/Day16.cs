using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day16
{
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

        if (part == 1) return GetCount(grid[0, 0], (1, 0));

        var count = 0;
        foreach (var node in grid.Nodes.Where(x => grid.IsOnBoundary(x)))
        {
            if (node.X == 0) count = Math.Max(GetCount(node, (1, 0)), count);
            if (node.Y == 0) count = Math.Max(GetCount(node, (0, 1)), count);
            if (node.X == grid.Width - 1) count = Math.Max(GetCount(node, (-1, 0)), count);
            if (node.Y == grid.Height - 1) count = Math.Max(GetCount(node, (0, -1)), count);
        }

        return count;
    }

    private static int GetCount(Node<char> startNode, (int X, int Y) startDirection)
    {
        var queue = new Queue<(Node<char> Node, (int X, int Y) Direction)>();
        var seen = new HashSet<(Node<char> Node, (int X, int Y) Direction)>();
        queue.Enqueue((startNode, startDirection));

        while (queue.Count > 0)
        {
            var (cur, direction) = queue.Dequeue();
            seen.Add((cur, direction));
            switch (cur.Value)
            {
                case '.':
                    EnqueueIfNotSeen(cur, direction, seen, queue);
                    break;
                case '/':
                    direction = (-direction.Y, -direction.X);
                    EnqueueIfNotSeen(cur, direction, seen, queue);
                    break;
                case '\\':
                    direction = (direction.Y, direction.X);
                    EnqueueIfNotSeen(cur, direction, seen, queue);
                    break;
                case '-':
                    if (direction.Y == 0)
                    {
                        EnqueueIfNotSeen(cur, direction, seen, queue);
                        continue;
                    }
                    direction = DirectionUtils.TurnLeft(direction);
                    EnqueueIfNotSeen(cur, direction, seen, queue);
                    direction = DirectionUtils.TurnAround(direction);
                    EnqueueIfNotSeen(cur, direction, seen, queue);
                    break;
                case '|':
                    if (direction.X == 0)
                    {
                        EnqueueIfNotSeen(cur, direction, seen, queue);
                        continue;
                    }
                    direction = DirectionUtils.TurnLeft(direction);
                    EnqueueIfNotSeen(cur, direction, seen, queue);
                    direction = DirectionUtils.TurnAround(direction);
                    EnqueueIfNotSeen(cur, direction, seen, queue);
                    break;
            }
        }

        return seen.GroupBy(x => x.Node).Count();
    }

    private static void EnqueueIfNotSeen(Node<char> node, (int X, int Y) direction, 
        HashSet<(Node<char> Node, (int X, int Y) Direction)> seen,
        Queue<(Node<char> Node, (int X, int Y) Direction)> queue)
    {
        var next = (Node: node.GetNeighbor(direction), Direction: direction);
        if (next.Node != null && !seen.Contains(next!))
        {
            queue.Enqueue(next!);
        }
    }
}