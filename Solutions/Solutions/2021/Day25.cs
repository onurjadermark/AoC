using Solutions.Utils;

namespace Solutions.Solutions._2021;

public class Day25
{
    public long Part1(string[] grid)
    {
        var time = 0;
        while (true)
        {
            var start = FindStartCoordinate(grid);
            if (start == null) return -1;
            var moved = false;
            var newGrid = new string[grid.Length];
            for (var i = 0; i < grid.Length; i++) newGrid[i] = grid[i];

            for (var i = start.X + grid[0].Length - 1; i >= start.X; i--)
            for (var j = start.Y + grid.Length - 1; j >= start.Y; j--)
                if (GetValue(grid, i, j) == '>' && GetValue(grid, i + 1, j) == '.')
                {
                    SetValue(newGrid, i, j, '.');
                    SetValue(newGrid, i + 1, j, '>');
                    moved = true;
                }

            grid = newGrid;
            newGrid = new string[grid.Length];
            for (var i = 0; i < grid.Length; i++) newGrid[i] = grid[i];

            for (var i = start.X + grid[0].Length - 1; i >= start.X; i--)
            for (var j = start.Y + grid.Length - 1; j >= start.Y; j--)
                if (GetValue(grid, i, j) == 'v' && GetValue(grid, i, j + 1) == '.')
                {
                    SetValue(newGrid, i, j, '.');
                    SetValue(newGrid, i, j + 1, 'v');
                    moved = true;
                }

            grid = newGrid;

            time++;
            if (!moved) break;
        }

        return time;
    }

    private void SetValue(string[] grid, int x, int y, char value)
    {
        FixCoords(grid, ref x, ref y);
        grid[y] = grid[y].Remove(x, 1).Insert(x, value.ToString());
    }

    private Coordinate? FindStartCoordinate(string[] grid)
    {
        Coordinate? start = null;
        for (var i = 0; i < grid[0].Length; i++)
        {
            if (start != null) break;
            for (var j = 0; j < grid.Length; j++)
                if (GetValue(grid, i - 1, j) == '.' && GetValue(grid, i, j - 1) == '.')
                {
                    start = new Coordinate(i, j);
                    break;
                }
        }

        return start;
    }

    private int GetValue(string[] grid, int x, int y)
    {
        FixCoords(grid, ref x, ref y);
        return grid[y][x];
    }

    private static void FixCoords(string[] grid, ref int x, ref int y)
    {
        if (x < 0) x += grid[0].Length;
        if (x >= grid[0].Length) x -= grid[0].Length;
        if (y < 0) y += grid.Length;
        if (y >= grid.Length) y -= grid.Length;
    }
}