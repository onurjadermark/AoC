using MoreLinq;
using Solutions.Utils;

namespace Solutions.Solutions._2022;

public class Day15
{
    public int Part1(string[] input)
    {
        var sensors = input.Select(ParseSensor).ToList();
        var y = input.Length < 20 ? 10 : 2000000;
        var points = new HashSet<int>();
        foreach (var sensor in sensors)
        {
            var overlapSizeX = sensor.BeaconDistance - Math.Abs(sensor.Y - y);
            for (var i = 0; i <= overlapSizeX; i++)
            {
                points.Add(sensor.X - i);
                points.Add(sensor.X + i);
            }
        }

        sensors.Where(x => x.ClosestBeaconY == y).ForEach(x => points.Remove(x.ClosestBeaconX));
        return points.Count;
    }

    public long Part2(string[] input)
    {
        var sensors = input.Select(ParseSensor).ToHashSet();
        var searchArea = sensors.Count > 20 ? 4000000 : 20;
        
        sensors = SortSensorsWithBoundaryDistance(sensors);

        foreach (var sensor in sensors)
        {
            var candidateX = sensor.X;
            var candidateY = sensor.Y + sensor.BeaconDistance + 1;
            var edgeSize = sensor.BeaconDistance * 2 + 2;
            for (var i = 0; i < edgeSize; i++)
            {
                candidateX++;
                candidateY--;
                if (CheckCandidate(candidateX, candidateY, searchArea, sensors))
                {
                    return GetTuningFrequency(candidateX, candidateY);
                }
            }

            for (var i = 0; i < edgeSize; i++)
            {
                candidateX--;
                candidateY--;
                if (CheckCandidate(candidateX, candidateY, searchArea, sensors))
                {
                    return GetTuningFrequency(candidateX, candidateY);
                }
            }

            for (var i = 0; i < edgeSize; i++)
            {
                candidateX--;
                candidateY++;
                if (CheckCandidate(candidateX, candidateY, searchArea, sensors))
                {
                    return GetTuningFrequency(candidateX, candidateY);
                }
            }

            for (var i = 0; i < edgeSize; i++)
            {
                candidateX++;
                candidateY++;
                if (CheckCandidate(candidateX, candidateY, searchArea, sensors))
                {
                    return GetTuningFrequency(candidateX, candidateY);
                }
            }
        }

        return 0;
    }

    private static HashSet<Sensor> SortSensorsWithBoundaryDistance(HashSet<Sensor> sensors)
    {
        var distances = new List<(Sensor a, Sensor b, int distance)>();
        foreach (var sensor1 in sensors)
        foreach (var sensor2 in sensors.Where(x => x != sensor1))
        {
            distances.Add((sensor1, sensor2,
                Math.Abs(sensor1.DistanceTo(sensor2.X, sensor2.Y) - sensor1.BeaconDistance - sensor2.BeaconDistance)));
        }

        distances = distances.OrderBy(x => x.distance == 0 ? int.MaxValue : x.distance).ToList();
        sensors = sensors.OrderBy(x => distances.First(y => y.a == x || y.b == x).distance).ToHashSet();
        return sensors;
    }

    private static long GetTuningFrequency(int candidateX, int candidateY)
    {
        return 4000000L * candidateX + candidateY;
    }

    private static bool CheckCandidate(int candidateX, int candidateY, int searchArea, HashSet<Sensor> sensors)
    {
        return candidateX >= 0 && candidateY >= 0 && candidateX <= searchArea && candidateY <= searchArea &&
               sensors.All(x => x.DistanceTo(candidateX, candidateY) > x.BeaconDistance);
    }

    private static Sensor ParseSensor(string s)
    {
        var split = s.Split(" ");
        return new Sensor(int.Parse(split[2][2..].Trim(',')), int.Parse(split[3][2..].Trim(':')),
            int.Parse(split[8][2..].Trim(',')), int.Parse(split[9][2..]));
    }

    private class Sensor
    {
        public int BeaconDistance { get; }
        
        public Sensor(int x, int y, int closestBeaconX, int closestBeaconY)
        {
            X = x;
            Y = y;
            ClosestBeaconX = closestBeaconX;
            ClosestBeaconY = closestBeaconY;
            BeaconDistance = Math.Abs(ClosestBeaconX - X) + Math.Abs(ClosestBeaconY - Y);
        }

        public int X { get; }
        public int Y { get; }
        public int ClosestBeaconX { get; set; }
        public int ClosestBeaconY { get; set; }

        public int DistanceTo(int x, int y)
        {
            return Math.Abs(X - x) + Math.Abs(Y - y);
        }
    }
}