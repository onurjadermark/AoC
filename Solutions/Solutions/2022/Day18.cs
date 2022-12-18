namespace Solutions.Solutions._2022;

public class Day18
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
        var cubes = input.Select(ParseCube).ToHashSet();

        var emptyNeighbors = new List<(int X, int Y, int Z)>();
        foreach (var cube in cubes)
        {
            if (!cubes.Contains((cube.X + 1, cube.Y, cube.Z))) emptyNeighbors.Add((cube.X + 1, cube.Y, cube.Z));
            if (!cubes.Contains((cube.X - 1, cube.Y, cube.Z))) emptyNeighbors.Add((cube.X - 1, cube.Y, cube.Z));
            if (!cubes.Contains((cube.X, cube.Y + 1, cube.Z))) emptyNeighbors.Add((cube.X, cube.Y + 1, cube.Z));
            if (!cubes.Contains((cube.X, cube.Y - 1, cube.Z))) emptyNeighbors.Add((cube.X, cube.Y - 1, cube.Z));
            if (!cubes.Contains((cube.X, cube.Y, cube.Z + 1))) emptyNeighbors.Add((cube.X, cube.Y, cube.Z + 1));
            if (!cubes.Contains((cube.X, cube.Y, cube.Z - 1))) emptyNeighbors.Add((cube.X, cube.Y, cube.Z - 1));
        }

        if (part == 1) return emptyNeighbors.Count;

        var water = new HashSet<(int X, int Y, int Z)>();
        var queue = new Queue<(int X, int Y, int Z)>();
        queue.Enqueue((-1, -1, -1));
        while (queue.Any())
        {
            var cube = queue.Dequeue();
            var neighbors = GetNeighbors(cube)
                .Where(x => !water.Contains(x) && !queue.Contains(x) && !cubes.Contains(x))
                .Where(x => x is {X: >= -1, Y: >= -1, Z: >= -1} and {X: < 50, Y: < 50, Z: < 50}).ToList();
            neighbors.ForEach(x => water.Add(x));
            neighbors.ForEach(x => queue.Enqueue(x));
        }

        return emptyNeighbors.Count(x => water.Contains(x));
    }

    private List<(int X, int Y, int Z)> GetNeighbors((int X, int Y, int Z) cube)
    {
        return new List<(int X, int Y, int Z)>
        {
            (cube.X + 1, cube.Y, cube.Z),
            (cube.X - 1, cube.Y, cube.Z),
            (cube.X, cube.Y + 1, cube.Z),
            (cube.X, cube.Y - 1, cube.Z),
            (cube.X, cube.Y, cube.Z + 1),
            (cube.X, cube.Y, cube.Z - 1)
        };
    }

    private (int X, int Y, int Z) ParseCube(string line)
    {
        var split = line.Split(",");
        return (int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
    }
}