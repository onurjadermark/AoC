namespace Solutions.Solutions._2022;

public class Day16
{
    private readonly Dictionary<long, int> _cache = new();

    public int Part1(string[] input)
    {
        var valves = input.Select(ParseValve).ToHashSet();
        ParseValveConnections(input, valves);
        return Navigate(valves, valves.Single(x => x.Name == "AA"), new List<Valve>(), 30, false);
    }

    public int Part2(string[] input)
    {
        var valves = input.Select(ParseValve).ToHashSet();
        ParseValveConnections(input, valves);
        return Navigate(valves, valves.Single(x => x.Name == "AA"), new List<Valve>(), 26, true);
    }

    private void ParseValveConnections(string[] input, HashSet<Valve> valves)
    {
        foreach (var line in input)
        {
            var curValve = valves.Single(x => x.Name == line.Split(" ")[1]);
            var connectionNamesStr = line.Split(line.Split("valves").Length == 2 ? "valves" : "valve")[1].Trim();
            var connectionNames = connectionNamesStr.Split(",").Select(x => x.Trim()).ToList();
            foreach (var connectionName in connectionNames)
            {
                curValve.Connections.Add(valves.Single(x => x.Name == connectionName));
            }
        }
    }

    private Valve ParseValve(string line, int index)
    {
        return new Valve(line.Split(" ")[1], int.Parse(line.Split(" ")[4].Split("=")[1].Trim(';')));
    }

    private int Navigate(HashSet<Valve> allValves, Valve current, List<Valve> opened, int timeLeft, bool hasElephant)
    {
        if (timeLeft == 0)
        {
            return hasElephant ? Navigate(allValves, allValves.Single(x => x.Name == "AA"), opened, 26, false) : 0;
        }

        var hashCode = GetHashCode(current, opened, timeLeft, hasElephant);
        if (_cache.ContainsKey(hashCode)) return _cache[hashCode];

        var pressure = Math.Max(0,
            current.Connections.Select(x => Navigate(allValves, x, opened, timeLeft - 1, hasElephant)).Max());

        if (current.Pressure > 0 && !opened.Contains(current))
        {
            pressure = Math.Max(pressure, OpenValve(allValves, current, opened, timeLeft, hasElephant));
        }

        _cache[hashCode] = pressure;

        return pressure;
    }
    
    private long GetHashCode(Valve valve, List<Valve> opened, int timeLeft, bool hasElephant)
    {
        var hash = 17L;
        hash = hash * 23 + valve.Name.GetHashCode();
        hash = opened.Aggregate(hash, (current, valve) => current * 23 + valve.GetHashCode());
        hash = hash * 23 + timeLeft.GetHashCode();
        hash = hash * 23 + hasElephant.GetHashCode();
        return hash;
    }

    private int OpenValve(HashSet<Valve> allValves, Valve current, List<Valve> opened, int timeLeft, bool hasElephant)
    {
        var pressureToRelease = (timeLeft - 1) * current.Pressure;
        opened.Add(current);
        opened.Sort();
        var pressureTotal = Navigate(allValves, current, opened, timeLeft - 1, hasElephant) + pressureToRelease;
        opened.Remove(current);
        return pressureTotal;
    }

    private class Valve : IComparable<Valve>
    {
        public Valve(string name, int pressure)
        {
            Name = name;
            Pressure = pressure;
        }

        public string Name { get; }
        public int Pressure { get; }
        public HashSet<Valve> Connections { get; } = new();

        public int CompareTo(Valve? valve)
        {
            return string.Compare(Name, valve!.Name, StringComparison.Ordinal);
        }
    }
}