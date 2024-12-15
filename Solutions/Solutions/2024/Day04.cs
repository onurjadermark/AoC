using MoreLinq;
using Solutions.Utils;

namespace Solutions.Solutions._2024;

public class Day04
{
    public int Part1(string[] input)
    {
        var grid = GetGrid(input);
        var count = 0;
        
        foreach (var node in grid.Nodes)
        {
            if (node.Value != 'X') continue;

            foreach (var direction in DirectionUtils.GetAllDirections())
            {
                var neighbor = node.GetNeighbor(direction);
                if (neighbor?.Value != 'M') continue;
                        
                var nextNeighbor = neighbor.GetNeighbor(direction);
                if (nextNeighbor?.Value != 'A') continue;

                var nextNextNeighbor = nextNeighbor.GetNeighbor(direction);
                if (nextNextNeighbor?.Value != 'S') continue;

                count++;
            }
        }

        return count;
    }

    public int Part2(string[] input)
    {
        var grid = GetGrid(input);
        var count = 0;
        
        foreach (var node in grid.Nodes)
        {
            var masCount = 0;
            if (node.Value != 'A') continue;
            foreach (var direction in DirectionUtils.GetDiagonalDirections())
            {
                var neighbor = node.GetNeighbor(direction);
                if (neighbor?.Value != 'M') continue;

                var oppositeNeighbor = node.GetNeighbor((-direction.X, -direction.Y));
                if (oppositeNeighbor?.Value != 'S') continue;
                        
                masCount++;
            }

            if (masCount == 2) count++;
        }

        return count;
    }

    private static Grid<char> GetGrid(string[] input)
    {
        var grid = new Grid<char>(input.Length, input.Length, true);
        grid.Nodes.ForEach(x => x.Value = input[x.X][x.Y]);
        return grid;
    }
} 