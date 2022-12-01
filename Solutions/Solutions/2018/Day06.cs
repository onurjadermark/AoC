using MoreLinq;

namespace Solutions.Solutions._2018;

public class Day06
{
    public int Part1(string[] input)
    {
        var points = input
            .Select(x => x.Split(' ', ',').Where(y => !string.IsNullOrWhiteSpace(y)).Select(int.Parse).ToList())
            .ToList()
            .Select((x, i) => (X: x.ElementAt(0), Y: x.ElementAt(1), Id: i)).ToList();

        var currentPoints = new HashSet<(int X, int Y, int Id)>(points);
        var grid = new (int PointId, int MinDistance)[1000, 1000];
        for (var i = 0; i < 1000; i++)
        for (var j = 0; j < 1000; j++)
        {
            grid[i, j].PointId = -1;
            grid[i, j].MinDistance = -1;
        }

        var currentDistance = 0;
        while (currentPoints.Any())
        {
            foreach (var (x, y, id) in currentPoints)
                if (grid[x, y].MinDistance == -1)
                    grid[x, y] = (id, currentDistance);
                else
                    grid[x, y] = (-2, currentDistance);

            var newPoints = new HashSet<(int X, int Y, int Id)>();
            foreach (var (x, y, id) in currentPoints)
            {
                if (x > 0 && grid[x - 1, y].PointId == -1)
                    newPoints.Add((x - 1, y, id));
                if (y > 0 && grid[x, y - 1].PointId == -1)
                    newPoints.Add((x, y - 1, id));
                if (x < 1000 - 1 && grid[x + 1, y].PointId == -1)
                    newPoints.Add((x + 1, y, id));
                if (y < 1000 - 1 && grid[x, y + 1].PointId == -1)
                    newPoints.Add((x, y + 1, id));
            }

            currentPoints = newPoints;

            currentDistance++;
        }

        var count = new int[1000];
        for (var i = 0; i < 1000; i++)
        for (var j = 0; j < 1000; j++)
        {
            if (grid[i, j].PointId == -2) continue;
            count[grid[i, j].PointId]++;
        }

        for (var i = 0; i < 1000; i++)
        {
            if (grid[i, 0].PointId >= 0)
                count[grid[i, 0].PointId] = 0;
            if (grid[0, i].PointId >= 0)
                count[grid[0, i].PointId] = 0;
            if (grid[i, 1000 - 1].PointId >= 0)
                count[grid[i, 1000 - 1].PointId] = 0;
            if (grid[1000 - 1, i].PointId >= 0)
                count[grid[1000 - 1, i].PointId] = 0;
        }

        return count.OrderByDescending(x => x).Take(1).Single();
    }

    public int Part2(string[] input)
    {
        var maxTotalDistance = input.Length == 50 ? 10000 : 32;
        var points = input
            .Select(x => x.Split(' ', ',').Where(y => !string.IsNullOrWhiteSpace(y)).Select(int.Parse).ToList())
            .ToList()
            .Select((x, i) => (X: x.ElementAt(0), Y: x.ElementAt(1), Id: i)).ToList();

        (int, int) boundaryPoint = FindBoundaryPoint(points, maxTotalDistance);

        var grid = new bool?[1000, 1000];
        var stack = new Stack<(int X, int Y)>();
        stack.Push(boundaryPoint);
        var count = 0;
        while (stack.Any())
        {
            var (i, y) = stack.Pop();
            if (points.Sum(x => ManhattanDistance(i, y, x.X, x.Y)) < maxTotalDistance)
            {
                if (grid[i, y] != true)
                {
                    count++;
                    grid[i, y] = true;
                }

                var neighbors = new (int X, int Y)[]
                {
                    (i, y - 1),
                    (i + 1, y - 1),
                    (i + 1, y),
                    (i + 1, y + 1),
                    (i, y + 1),
                    (i - 1, y + 1),
                    (i - 1, y),
                    (i - 1, y - 1)
                };
                neighbors.Where(x => grid[x.X, x.Y] == null).ForEach(x => stack.Push(x));
            }
            else
            {
                grid[i, y] = false;
            }
        }

        return count;
    }

    private (int X, int Y) FindBoundaryPoint(List<(int X, int Y, int Id)> points, int maxTotalDistance)
    {
        var random = new Random();
        var randomRows = Enumerable.Range(0, 1000).OrderBy(x => random.Next()).ToList();
        var randomColumns = Enumerable.Range(0, 1000).OrderBy(x => random.Next()).ToList();
        foreach (var i in randomRows)
        foreach (var j in randomColumns)
            if (points.Sum(x => ManhattanDistance(i, j, x.X, x.Y)) < maxTotalDistance)
                return (i, j);

        throw new Exception();
    }

    private int ManhattanDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
}