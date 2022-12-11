namespace Solutions.Solutions._2022;

public class Day09
{
    private readonly Dictionary<char, (int x, int y)> _moves = new()
    {
        {'U', (1, 0)},
        {'R', (0, 1)},
        {'D', (-1, 0)},
        {'L', (0, -1)}
    };

    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 9);
    }

    private int Solve(string[] input, int knot)
    {
        var trails = new HashSet<(int x, int y)>[10];
        var rope = new (int x, int y)[10];
        for (var i = 0; i < 10; i++)
        {
            trails[i] = new HashSet<(int x, int y)>();
            rope[i] = (x: 0, y: 0);
            trails[i].Add(rope[i]);
        }

        foreach (var line in input)
        {
            var direction = line.Split(" ")[0][0];
            var distance = int.Parse(line.Split(" ")[1]);
            for (var i = 0; i < distance; i++)
            {
                var move = _moves[direction];

                rope[0].x += move.x;
                rope[0].y += move.y;
                for (var j = 0; j + 1 < 10; j++)
                {
                    var dx = Math.Abs(rope[j].x - rope[j + 1].x);
                    var dy = Math.Abs(rope[j].y - rope[j + 1].y);
                    if (dx <= 1 && dy <= 1) continue;
                    rope[j + 1].x += Math.Clamp(rope[j].x - rope[j + 1].x, -1, 1);
                    rope[j + 1].y += Math.Clamp(rope[j].y - rope[j + 1].y, -1, 1);
                }

                for (var j = 0; j < 10; j++)
                {
                    trails[j].Add(rope[j]);
                }
            }
        }

        return trails[knot].Count;
    }
}