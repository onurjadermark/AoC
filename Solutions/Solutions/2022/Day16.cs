namespace Solutions.Solutions._2022;

public class Day16
{
    public int Part1(string[] input)
    {
        var valves = input.Select(ParseValve).ToList();
        ParseValveConnections(input, valves);

        var valvesWithPressure = valves.Where(x => x.Pressure > 0).ToList();
        var distances = new Dictionary<(Valve a, Valve b), int>();
        foreach (var a in valves)
        foreach (var b in valves)
        {
            distances[(a, b)] = int.MaxValue;
        }

        foreach (var curValve in valves)
        {
            var seen = new HashSet<Valve>();
            var queue = new Queue<(Valve Valve, int Distance)>();
            queue.Enqueue((curValve, 0));
            seen.Add(curValve);
            distances[(curValve, curValve)] = 0;
            while (queue.Any())
            {
                var cur = queue.Dequeue();
                foreach (var connection in cur.Valve.Connections)
                {
                    if (seen.Contains(connection)) continue;
                    seen.Add(connection);
                    if (distances[(curValve, connection)] > cur.Distance)
                        distances[(curValve, connection)] = cur.Distance + 1;
                    queue.Enqueue((connection, cur.Distance + 1));
                }
            }
        }

        var maxReleasedPressure = 0;
        var memo = new Dictionary<string, int>();
        var stack = new Stack<(HashSet<Valve> OpenedValves, Valve Location, int Pressure, int Time)>();
        stack.Push((new HashSet<Valve>(), valves.Single(x => x.Name == "AA"), 0, 0));

        while (stack.Any())
        {
            var cur = stack.Pop();
            var location = cur.Location;
            var releasedPressure = cur.Pressure;
            var openedValves = cur.OpenedValves.ToHashSet();
            var time = cur.Time;
            if (HasAlreadySeenBetter(memo, GetState(openedValves, location, time), releasedPressure)) continue;

            foreach (var valve in valvesWithPressure.Except(openedValves))
            {
                time = cur.Time;
                if (time > 30) continue;
                location = cur.Location;
                releasedPressure = cur.Pressure;
                openedValves = cur.OpenedValves.ToHashSet();

                if (maxReleasedPressure < releasedPressure) maxReleasedPressure = releasedPressure;
                if (time == 30) continue;

                var distance = distances[(location, valve)];
                for (var i = 0; i < distance; i++)
                {
                    releasedPressure += openedValves.Sum(x => x.Pressure);
                    time++;
                    if (time == 30) break;
                }

                if (maxReleasedPressure < releasedPressure) maxReleasedPressure = releasedPressure;
                if (time == 30) continue;

                releasedPressure += openedValves.Sum(x => x.Pressure);
                openedValves.Add(valve);
                time++;
                if (maxReleasedPressure < releasedPressure) maxReleasedPressure = releasedPressure;
                if (time == 30) continue;

                if (openedValves.Count == valvesWithPressure.Count)
                {
                    for (; time < 30; time++)
                    {
                        releasedPressure += openedValves.Sum(x => x.Pressure);
                    }
                }

                if (maxReleasedPressure < releasedPressure) maxReleasedPressure = releasedPressure;
                if (time == 30) continue;

                stack.Push((openedValves, valve, releasedPressure, time));
            }
        }

        return maxReleasedPressure;
    }

    private static bool HasAlreadySeenBetter(Dictionary<string, int> memo, string state, int releasedPressure)
    {
        if (memo.ContainsKey(state) && memo[state] > releasedPressure) return true;
        memo[state] = releasedPressure;
        return false;
    }

    private static string GetState(HashSet<Valve> openedValves, Valve location, int time)
    {
        return string.Join(",", openedValves.OrderBy(x => x.Name).Select(x => x.Name)) + ":" + location.Name + '@' +
               time;
    }

    private void ParseValveConnections(string[] input, List<Valve> valves)
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

    public int Part2(string[] input)
    {
        return 0;
    }

    private class Valve
    {
        public Valve(string name, int pressure)
        {
            Name = name;
            Pressure = pressure;
        }

        public string Name { get; }
        public int Pressure { get; }
        public HashSet<Valve> Connections { get; } = new();
    }
}