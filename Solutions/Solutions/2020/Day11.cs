namespace Solutions.Solutions._2020;

public class Day11
{
    private readonly List<(int X, int Y)> _neighbors =
    [
        (0, 1),
        (1, 1),
        (1, 0),
        (1, -1),
        (0, -1),
        (-1, -1),
        (-1, 0),
        (-1, 1)
    ];

    private char[,] _grid = new char[0, 0];
    private char[,] _newGrid = new char[0, 0];
    private char[,] _emptyGrid = new char[0, 0];
    private int _turns;
    private int _width;
    private int _height;
    private int _part;

    private readonly Dictionary<long, List<(int X, int Y)>> _cache = new();

    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(string[] input, int part)
    {
        _part = part;
        var lines = input.Select(x => x.Trim()).ToList();
        _width = lines.Max(x => x.Trim().Length);
        _height = lines.Count();
        _grid = new char[_width, _height];
        _newGrid = new char[_width, _height];
        _emptyGrid = new char[_width, _height];
        _turns = 0;

        for (var i = 0; i < _width; i++)
        for (var j = 0; j < _height; j++)
        {
            _grid[i, j] = lines[j][i];
            _emptyGrid[i, j] = lines[j][i];
        }

        var done = false;
        while (!done)
        {
            done = true;
            for (var i = 0; i < _width; i++)
            for (var j = 0; j < _height; j++)
            {
                if (GetCurrentGrid()[i, j] == '.')
                {
                    SetNextGrid(i, j, '.');
                    continue;
                }

                var neighbors = GetNumNeighbors(GetCurrentGrid(), i, j);
                if (neighbors == 0 && GetCurrentGrid()[i, j] == 'L')
                {
                    SetNextGrid(i, j, '#');
                    if (done && GetNextGrid()[i, j] != GetCurrentGrid()[i, j]) done = false;
                }
                else if (neighbors >= (_part == 1 ? 4 : 5) && GetCurrentGrid()[i, j] == '#')
                {
                    SetNextGrid(i, j, 'L');
                    if (done && GetNextGrid()[i, j] != GetCurrentGrid()[i, j]) done = false;
                }
                else
                {
                    SetNextGrid(i, j, GetCurrentGrid()[i, j]);
                }
            }

            _turns++;
        }

        var count = 0;

        for (var i = 0; i < _width; i++)
        for (var j = 0; j < _height; j++)
            if (GetCurrentGrid()[i, j] == '#')
                count++;


        return count;
    }

    private void SetNextGrid(int i, int j, char c)
    {
        if (_turns % 2 == 1)
            _grid[i, j] = c;
        else
            _newGrid[i, j] = c;
    }

    private char[,] GetCurrentGrid()
    {
        return _turns % 2 == 0 ? _grid : _newGrid;
    }

    private char[,] GetNextGrid()
    {
        return _turns % 2 == 1 ? _grid : _newGrid;
    }

    private int GetNumNeighbors(char[,] grid, int x, int y)
    {
        var neighbors = GetNeighborsFromCache(x, y);

        return neighbors.Count(neighbor => grid[neighbor.X, neighbor.Y] == '#');
    }

    public List<(int X, int Y)> GetNeighborsFromCache(int x, int y)
    {
        long code = 103;
        code = code * 107 + x;
        code = code * 107 + y;
        code = code * 107 + _part;

        if (!_cache.ContainsKey(code)) _cache[code] = GetNeighbors(x, y, _width, _height, _part);

        return _cache[code];
    }

    private List<(int X, int Y)> GetNeighbors(int x, int y, int width, int height, int part)
    {
        var neighbors = new List<(int X, int Y)>();

        foreach (var neighbor in _neighbors)
        {
            var (nx, ny) = neighbor;
            var x2 = x + nx;
            var y2 = y + ny;
            while (true)
            {
                if (x2 >= 0 && x2 < width && y2 >= 0 && y2 < height)
                {
                    var cur = _emptyGrid[x2, y2];
                    if (cur == 'L')
                    {
                        neighbors.Add((x2, y2));
                        break;
                    }
                }
                else
                {
                    break;
                }

                if (part == 1) break;

                x2 += nx;
                y2 += ny;
            }
        }

        return neighbors;
    }
}