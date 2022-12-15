using System.Numerics;

namespace Solutions.Solutions._2022;

public class Day15
{
    private class Sensor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ClosestBeaconX { get; set; }
        public int ClosestBeaconY { get; set; }

        public Sensor(int x, int y, int closestBeaconX, int closestBeaconY)
        {
            X = x;
            Y = y;
            ClosestBeaconX = closestBeaconX;
            ClosestBeaconY = closestBeaconY;
        }
    }
    
    public int Part1(string[] input)
    {
        var sensors = input.Select(ParseSensor);
        var y = input.Length < 20 ? 10 : 2000000;
        var result = 0;
        for (int x = -5000000; x < 8000000; x++)
        {
            foreach (var sensor in sensors)
            {
                var beaconDistance = Math.Abs(sensor.ClosestBeaconX - sensor.X) + 
                                     Math.Abs(sensor.ClosestBeaconY - sensor.Y);
                var pointDistance = Math.Abs(sensor.X - x) + Math.Abs(sensor.Y - y);
                if (pointDistance <= beaconDistance)
                {
                    if (sensors.Any(z => z.ClosestBeaconX == x && z.ClosestBeaconY == y)) continue;
                    result++;
                    break;
                }
            }
        }
        return result;
    }
    
    public long Part2(string[] input)
    {
        var sensors = input.Select(ParseSensor);
        var result = 0;
        var beaconBoundaries = new HashSet<(int x, int y)>();
        foreach (var sensor in sensors)
        {
            if (sensor.ClosestBeaconX < sensor.X)
            {
                sensor.ClosestBeaconX += 2 * (sensor.X - sensor.ClosestBeaconX);
            }

            if (sensor.ClosestBeaconY < sensor.Y)
            {
                sensor.ClosestBeaconY += 2 * (sensor.Y - sensor.ClosestBeaconY);
            }

            var sensorXOffset = sensor.ClosestBeaconX - sensor.X;
            sensor.ClosestBeaconX -= sensorXOffset;
            sensor.ClosestBeaconY += sensorXOffset;

            for (int i = 0; i < sensor.ClosestBeaconY - sensor.Y + 1; i++)
            {
                beaconBoundaries.Add((sensor.ClosestBeaconX + i, sensor.ClosestBeaconY - i));
                beaconBoundaries.Add((sensor.ClosestBeaconX - i, sensor.ClosestBeaconY - i));
            }
            for (int i = 0; i < sensor.ClosestBeaconY - sensor.Y + 1; i++)
            {
                beaconBoundaries.Add((sensor.ClosestBeaconX + i, sensor.Y - (sensor.ClosestBeaconY - sensor.Y) + i));
                beaconBoundaries.Add((sensor.ClosestBeaconX - i, sensor.Y - (sensor.ClosestBeaconY - sensor.Y) + i));
            }
        }

        var possibles = new HashSet<(int x, int y)>();
        foreach (var beaconBoundary in beaconBoundaries)
        {
            if (beaconBoundary.x <= 4000000 && beaconBoundary.y <= 4000000)
            {
                if (beaconBoundaries.Contains((beaconBoundary.x + 2, beaconBoundary.y)) &&
                    beaconBoundaries.Contains((beaconBoundary.x + 1, beaconBoundary.y - 1)) &&
                    beaconBoundaries.Contains((beaconBoundary.x + 1, beaconBoundary.y + 1)))
                {
                    possibles.Add((beaconBoundary.x, beaconBoundary.y));
                }
            }
        }

        var results = new List<(int x, int y)>();
        foreach (var possible in possibles.ToList())
        {
            var cur = possible with {x = possible.x + 1};
            var canReach = false;
            foreach (var sensor in sensors)
            {
                var beaconDistance = Math.Abs(sensor.ClosestBeaconX - sensor.X) + 
                                     Math.Abs(sensor.ClosestBeaconY - sensor.Y);
                var pointDistance = Math.Abs(sensor.X - cur.x) + Math.Abs(sensor.Y - cur.y);
                if (pointDistance <= beaconDistance)
                {
                    canReach = true;
                    break;
                }
            }

            if (!canReach)
            {
                results.Add(cur);
            }
        }

        return ((long) results.Single().x) * 4000000 + results.Single().y;
    }

    private Sensor ParseSensor(string s)
    {
        var split = s.Split(" ");
        return new Sensor(int.Parse(split[2].Substring(2).Trim(',')), 
            int.Parse(split[3].Substring(2).Trim(':')), 
            int.Parse(split[8].Substring(2).Trim(',')), 
            int.Parse(split[9].Substring(2)));
    }
}