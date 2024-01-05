namespace Solutions.Solutions._2023;

public class Day22
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
        var bricks = input.Select(ParseCoordinates).ToList();
        bricks = bricks.OrderBy(b => b.Z1).ToList();

        ProcessGravity(bricks);

        return part == 1
            ? bricks.Count(b => b.Supports.All(a => a.IsSupportedBy.Count > 1))
            : bricks.SelectMany(BreadthFirstTraversal).Count();
    }

    private static void ProcessGravity(List<Brick> bricks)
    {
        for (var i = 0; i < bricks.Count; i++)
        {
            var currentBrick = bricks[i];
            var z = currentBrick.Z1;

            while (z > 0)
            {
                var below = GetBricksBelow(currentBrick, bricks);

                if (below.Count == 0 && z != 1)
                {
                    z--;
                    currentBrick = currentBrick with
                    {
                        Z1 = z,
                        Z2 = z + currentBrick.Z2 - currentBrick.Z1 + 1 - 1
                    };
                }
                else
                {
                    foreach (var b in below)
                    {
                        b.Supports.Add(currentBrick);
                        currentBrick.IsSupportedBy.Add(b);
                    }

                    bricks[i] = currentBrick;
                    break;
                }
            }
        }
    }

    private static List<Brick> GetBricksBelow(Brick currentBrick, List<Brick> bricks)
    {
        return bricks.Where(b => b.Z2 == currentBrick.Z1 - 1 && OverlapsXY(currentBrick, b)).ToList();
    }

    private static IEnumerable<Brick> BreadthFirstTraversal(Brick brick)
    {
        var queue = new Queue<Brick>();
        var destroyed = new HashSet<Brick>();

        queue.Enqueue(brick);

        while (queue.TryDequeue(out var current))
        {
            destroyed.Add(current);
            foreach (var toFall in current.Supports.Where(x => x.IsSupportedBy.All(destroyed.Contains)))
            {
                yield return toFall;
                queue.Enqueue(toFall);
            }
        }
    }

    private static Brick ParseCoordinates(string line)
    {
        var coordinates = line.Split(',', '~').Select(int.Parse).ToArray();
        return new Brick
        {
            X1 = coordinates[0],
            Y1 = coordinates[1],
            Z1 = coordinates[2],
            X2 = coordinates[3],
            Y2 = coordinates[4],
            Z2 = coordinates[5]
        };
    }

    private static bool OverlapsXY(Brick first, Brick second) =>
        Enumerable.Range(first.X1, first.X2 - first.X1 + 1)
            .Intersect(Enumerable.Range(second.X1, second.X2 - second.X1 + 1))
            .Any() && Enumerable.Range(first.Y1, first.Y2 - first.Y1 + 1)
            .Intersect(Enumerable.Range(second.Y1, second.Y2 - second.Y1 + 1))
            .Any();

    internal struct Brick
    {
        public Brick()
        {
        }

        public List<Brick> Supports { get; } = [];
        public List<Brick> IsSupportedBy { get; } = [];

        public int X1 { get; init; } = 0;
        public int Y1 { get; init; } = 0;
        public int Z1 { get; init; } = 0;
        public int X2 { get; init; } = 0;
        public int Y2 { get; init; } = 0;
        public int Z2 { get; init; } = 0;
    }
}