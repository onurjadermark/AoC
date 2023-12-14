using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day14
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
        var dict = new Dictionary<string, string>();
        var numIter = 0;
        for (var i = 0; i < 1000000000; i++)
        {
            var key = GetKey(grid);
            if (dict.ContainsKey(key))
            {
                numIter = i;
                break;
            }

            TiltNorth(grid);
            if (part == 1) return GetResult(grid);
            TiltWest(grid);
            TiltSouth(grid);
            TiltEast(grid);
            var nextKey = GetKey(grid);
            dict[key] = nextKey;
        }

        var loop = new List<string>();
        var cur = GetKey(grid);
        while (!loop.Contains(cur))
        {
            loop.Add(cur);
            cur = dict[cur];
        }

        var index = (1000000000 - numIter) % loop.Count;
        var lastKey = loop[index];
        SetValues(lastKey, grid);

        return GetResult(grid);
    }

    private static void SetValues(string values, Grid<char> grid)
    {
        for (var i = 0; i < values.Length; i++)
        {
            grid[i / grid.Height, i % grid.Width].Value = values[i];
        }
    }

    private static string GetKey(Grid<char> grid)
    {
        return string.Join("", grid.Nodes.Select(x => x.Value));
    }

    private static int GetResult(Grid<char> grid)
    {
        var sum = 0;
        for (var i = 0; i < grid.Width; i++)
        {
            for (var j = 0; j < grid.Height; j++)
            {
                sum += grid[i, j].Value == 'O' ? grid.Height - j : 0;
            }
        }

        return sum;
    }

    private static void TiltNorth(Grid<char> grid)
    {
        for (var i = 0; i < grid.Width; i++)
        {
            for (var j = 0; j < grid.Height; j++)
            {
                var node = grid[i, j];
                if (node.Value != 'O') continue;
                while (node != null && node.Up is {Value: '.'})
                {
                    node.Up.Value = 'O';
                    node.Value = '.';
                    node = node.Up;
                }
            }
        }
    }

    private static void TiltEast(Grid<char> grid)
    {
        for (var i = grid.Width - 1; i >= 0; i--)
        {
            for (var j = 0; j < grid.Height; j++)
            {
                var node = grid[i, j];
                if (node.Value != 'O') continue;
                while (node != null && node.Right is {Value: '.'})
                {
                    node.Right.Value = 'O';
                    node.Value = '.';
                    node = node.Right;
                }
            }
        }
    }

    private static void TiltSouth(Grid<char> grid)
    {
        for (var i = 0; i < grid.Width; i++)
        {
            for (var j = grid.Height - 1; j >= 0; j--)
            {
                var node = grid[i, j];
                if (node.Value != 'O') continue;
                while (node != null && node.Down is {Value: '.'})
                {
                    node.Down.Value = 'O';
                    node.Value = '.';
                    node = node.Down;
                }
            }
        }
    }

    private static void TiltWest(Grid<char> grid)
    {
        for (var i = 0; i < grid.Width; i++)
        {
            for (var j = 0; j < grid.Height; j++)
            {
                var node = grid[i, j];
                if (node.Value != 'O') continue;
                while (node != null && node.Left is {Value: '.'})
                {
                    node.Left.Value = 'O';
                    node.Value = '.';
                    node = node.Left;
                }
            }
        }
    }
}