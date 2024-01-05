namespace Solutions.Solutions._2023;

public class Day24
{
    public int Part1(string[] input)
    {
        var hailstones = ParseHailstones(input);
        var min = hailstones.Count > 10 ? 200000000000000 : 7;
        var max = hailstones.Count > 10 ? 400000000000000 : 27;

        var count = hailstones.SelectMany(x => hailstones.Where(y => x != y)
                .Select(y => x.FindFutureIntersectionPoint(y, 0, 0))
                .Where(z => z != null && z.Value.X >= min && z.Value.Y >= min && z.Value.X <= max && z.Value.Y <= max))
            .Count();

        var result = count / 2;
        return result;
    }

    private static List<Hailstone> ParseHailstones(string[] input)
    {
        var hailstones = new List<Hailstone>();

        foreach (var line in input)
        {
            var coordinates = line.Split('@')[0].Trim().Split(',');
            var speeds = line.Split('@')[1].Trim().Split(',');
            var hailstone = new Hailstone(long.Parse(coordinates[0]), long.Parse(coordinates[1]), long.Parse(coordinates[2]),
                int.Parse(speeds[0]), int.Parse(speeds[1]), int.Parse(speeds[2]));
            hailstones.Add(hailstone);
        }

        return hailstones;
    }

    public double Part2(string[] input)
    {
        var hailstones = ParseHailstones(input);

        for (var i = -500; i < 500; i++)
        {
            for (var j = -500; j < 500; j++)
            {
                var xyIntersections = Enumerable.Range(1, 3).Select(x => hailstones[x].FindFutureIntersectionPoint(hailstones[0], i, j)).ToList();
                if (xyIntersections.Any(x => !x.HasValue || Math.Abs(x.Value.X - xyIntersections[0]!.Value.X) > 0
                                                       || Math.Abs(x.Value.Y - xyIntersections[0]!.Value.Y) > 0)) continue;
                
                for (var k = -500; k < 500; k++)
                {
                    var zIntersections = Enumerable.Range(1, 3)
                        .Select(x => hailstones[x].Z + xyIntersections[x - 1]!.Value.Time * (hailstones[x].SpeedZ + k)).ToList();
                    if (zIntersections.Any(x => Math.Abs(x - zIntersections[0]) > 0)) continue;
                    return xyIntersections[0]!.Value.X + xyIntersections[0]!.Value.Y + zIntersections.First();
                }
            }
        }

        throw new Exception();
    }

    public class Hailstone(double x, double y, double z, double speedX, double speedY, double speedZ)
    {
        private double X { get; } = x;
        private double Y { get; } = y;
        public double Z { get; } = z;
        private double SpeedX { get; } = speedX;
        private double SpeedY { get; } = speedY;
        public double SpeedZ { get; } = speedZ;

        public (double X, double Y, double Time)? FindFutureIntersectionPoint(Hailstone other, int speedOffsetX, int speedOffsetY)
        {
            var speedX = SpeedX + speedOffsetX;
            var speedY = SpeedY + speedOffsetY;
            var otherSpeedX = other.SpeedX + speedOffsetX;
            var otherSpeedY = other.SpeedY + speedOffsetY;
            var crossProduct = speedX * otherSpeedY - speedY * otherSpeedX;
            if (Math.Abs(crossProduct) == 0) return null;

            var time1 = ((other.X - X) * otherSpeedY - (other.Y - Y) * otherSpeedX) / crossProduct;
            var time2 = ((other.X - X) * speedY - (other.Y - Y) * speedX) / crossProduct;
            if (time1 < 0 || time2 < 0) return null;

            return (X + speedX * time1, Y + speedY * time1, time1);
        }
    }
}