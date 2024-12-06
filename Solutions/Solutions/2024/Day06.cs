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
        
        for (var j = 0; j < input.Length; j++)
        {
            for (var i = 0; i < input[j].Length; i++)
            {
                var visited = new HashSet<(Node<char> Position, (int X, int Y) Direction)>();
                var currentPosition = originalPosition;
                var currentDirection = originalDirection;
                var obstruction = part == 1 ? null : grid[i, j];
                if (obstruction?.Value == '#' || obstruction == originalPosition) continue;

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
                    loopCount++;
                    break;
                }

                if (part == 1)
                {
                    return visited.Select(x => x.Position).Distinct().Count();
                }
            }
        }


        return loopCount;
    }
}