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
        var originalPosition = grid.Nodes.Single(x => new [] { '^', '>', 'v', '<' }.Contains(x.Value));
        var originalDirection = DirectionUtils.FromChar(originalPosition.Value);
        originalPosition.Value = '.';
        var loopCount = 0;
        
        var (originalVisited, _) = Solve(originalPosition, originalDirection, null);
        if (part == 1) return originalVisited.Select(x => x.Position).Distinct().Count();
        
        foreach (var obstruction in grid.Nodes)
        {
            var currentPosition = originalPosition;
            var currentDirection = originalDirection;
            
            if (obstruction.Value == '#' || obstruction == originalPosition) continue;
            if (originalVisited.All(x => x.Position != obstruction)) continue;

            var (_, isLoop) = Solve(currentPosition, currentDirection, obstruction);
            if (isLoop) loopCount++;
        }

        return loopCount;
    }

    private static (HashSet<(Node<char> Position, (int X, int Y) Direction)> Visited, bool IsLoop) Solve(Node<char> currentPosition, (int X, int Y) currentDirection, Node<char>? obstruction)
    {
        var visited = new HashSet<(Node<char> Position, (int X, int Y) Direction)>();
        var isLoop = false;
        
        while (true)
        {
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

            if (!visited.Contains((currentPosition, currentDirection))) continue;
            isLoop = true;
            break;
        }

        return (visited, isLoop);
    }
}