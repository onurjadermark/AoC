using Solutions.Utils;

namespace Solutions.Solutions._2024;

public class Day06
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
        var grid = GridFactory.FromInputStrings(input);
        var originalPosition = grid.Nodes.Single(x => DirectionUtils.DirectionChars.Contains(x.Value));
        var originalDirection = DirectionUtils.FromChar(originalPosition.Value);
        originalPosition.Value = '.';

        var originalVisited = Solve(originalPosition, originalDirection, null).Visited;
        if (part == 1) return originalVisited.Select(x => x.Position).Distinct().Count();
        var toCheck = originalVisited.Select(x => x.Position).Distinct()
            .Where(x => x.Value != '#' && x != originalPosition).ToHashSet();

        return toCheck.Count(x => Solve(originalPosition, originalDirection, x).IsLoop);
    }

    private static Solution Solve(Node<char> currentPosition, (int X, int Y) currentDirection, Node<char>? obstruction)
    {
        var visited = new HashSet<(Node<char> Position, (int X, int Y) Direction)>();
        var isLoop = false;

        while (true)
        {
            var lastVisitedCount = visited.Count;
            visited.Add((currentPosition, currentDirection));

            var nextPosition = currentPosition.GetNeighbor(currentDirection);
            if (nextPosition == null) break;

            if (nextPosition.Value == '#' || nextPosition == obstruction)
            {
                currentDirection = DirectionUtils.TurnRight(currentDirection);
            }
            else
            {
                currentPosition = nextPosition;
            }

            if (visited.Count != lastVisitedCount) continue;
            isLoop = true;
            break;
        }

        return new Solution(visited, isLoop);
    }

    private class Solution(HashSet<(Node<char> Position, (int X, int Y) Direction)> visited, bool isLoop)
    {
        public HashSet<(Node<char> Position, (int X, int Y) Direction)> Visited { get; } = visited;
        public bool IsLoop { get; } = isLoop;
    }
}