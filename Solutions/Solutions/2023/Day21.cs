using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day21
{
    public int Part1(string[] input)
    {
        var steps = input.Length > 50 ? 64 : 6;
        var grid = GridFactory.FromInputStrings(input);
        var start = grid.Nodes.Single(x => x.Value == 'S');
        var moves = new (int X, int Y)[] {(0, -1), (1, 0), (0, 1), (-1, 0)};

        var possibilities = new HashSet<(int X, int Y)> {(start.X, start.Y)};
        for (var i = 0; i < steps; i++)
        {
            possibilities = possibilities.SelectMany(x => moves.Select(y => (X: x.X + y.X, Y: x.Y + y.Y))).ToHashSet()
                .Where(x => input[x.Y][x.X] != '#').ToHashSet();
        }

        return possibilities.GroupBy(x => x).Count();
    }

    public long Part2(string[] input)
    {
        var steps = input.Length > 50 ? 26501365 : 10;
        var grid = GridFactory.FromInputStrings(input);
        var size = grid.Width == grid.Height ? grid.Width : -1;
        var grids = steps / size;
        var extra = steps % size;
        var start = grid.Nodes.Single(x => x.Value == 'S');
        var moves = new (int X, int Y)[] {(0, -1), (1, 0), (0, 1), (-1, 0)};

        var possibilities = new HashSet<(int X, int Y)> {(start.X, start.Y)};
        var f = new List<long>();
        for (var i = 0; ; i++)
        {
            if ((i - extra) % size == 0)
            {
                f.Add(possibilities.Count);
                if (f.Count == 3)
                {
                    break;
                }
            }
            possibilities = possibilities.SelectMany(x => moves.Select(y => (X: x.X + y.X, Y: x.Y + y.Y))).ToHashSet()
                .Where(x => input[GetIndex(x.Y, size)][GetIndex(x.X, size)] != '#').ToHashSet();
        }
        
        var result = SolveQuadratic(f[0], f[1], f[2], grids);
        return result;
    }

    private static long SolveQuadratic(long x0, long x1, long x2, int solveFor)
    {
        var c = x0;
        var a = (x2 - 2 * x1 + c) / 2;
        var b = x0 - a - c;
        return a * solveFor * solveFor + b * solveFor + c;
    }

    private static int GetIndex(int index, int size)
    {
        return (index % size + size) % size;
    }
}