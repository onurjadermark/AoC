using System.Drawing;

namespace Solutions.Solutions._2022;

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
        var map = ParseInput(input, part);

        PourSand(map, part);

        var result = CountSand(map);

        return result;
    }

    private static void PourSand(int[,] map, int part)
    {
        var done = false;
        
        while (!done)
        {
            var x = 500;
            var y = 0;

            if (part == 2 && map[x, y] == 1)
            {
                done = true;
            }

            while (!done)
            {
                if (part == 1 && y >= 999)
                {
                    done = true;
                    break;
                }

                if (map[x, y + 1] == 0)
                {
                    y += 1;
                    continue;
                }

                if (map[x - 1, y + 1] == 0)
                {
                    x -= 1;
                    y += 1;
                    continue;
                }

                if (map[x + 1, y + 1] == 0)
                {
                    x += 1;
                    y += 1;
                    continue;
                }

                map[x, y] = 1;
                break;
            }
        }
    }

    private static int CountSand(int[,] map)
    {
        var result = 0;
        
        for (var i = 0; i < 1000; i++)
        {
            for (var j = 0; j < 1000; j++)
            {
                if (map[i, j] == 1) result++;
            }
        }

        return result;
    }

    private static int[,] ParseInput(string[] input, int part)
    {
        var map = new int[1000, 1000];
        var floorY = 0;
        foreach (var line in input)
        {
            var points = line.Split(" -> ").Select(x => new Point(int.Parse(x.Split(",")[0]), int.Parse(x.Split(",")[1]))).ToList();
            for (var i = 0; i < points.Count - 1; i++)
            {
                var first = points[i];
                var second = points[i + 1];
                var minX = Math.Min(first.X, second.X);
                var maxX = Math.Max(first.X, second.X);
                var minY = Math.Min(first.Y, second.Y);
                var maxY = Math.Max(first.Y, second.Y);
                for (var j = minX; j <= maxX; j++)
                {
                    for (var k = minY; k <= maxY; k++)
                    {
                        map[j, k] = 2;
                        if (floorY < k + 2) floorY = k + 2;
                    }
                }
            }
        }

        if (part == 1) return map;
        for (var i = 0; i < 1000; i++) map[i, floorY] = 2;
        return map;
    }
}