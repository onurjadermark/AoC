using System.Text.RegularExpressions;

namespace Solutions.Solutions._2022;

public class Day19
{
    private Dictionary<long, int> _cache = new();
    private int _maxGeodesForFactory;

    public int Part1(string[] input)
    {
        var factories = input.Select(ParseFactory).ToList();
        var result = 0;

        foreach (var factory in factories)
        {
            _cache = new();
            _maxGeodesForFactory = 0;
            var quality = Solve(factory, new State(factory, 24));
            result += factory.Id * quality;
        }

        return result;
    }

    public int Part2(string[] input)
    {
        var factories = input.Select(ParseFactory).Take(3).ToList();
        var result = 1;

        foreach (var factory in factories)
        {
            _cache = new();
            _maxGeodesForFactory = 0;
            var quality = Solve(factory, new State(factory, 32));
            result *= quality;
        }

        return result;
    }

    private int Solve(Factory factory, State state)
    {
        var hashCode = GetHashCode(state);
        if (_cache.ContainsKey(hashCode)) return _cache[hashCode];

        if (state.Time == 0) return 0;
        var quality = 0;

        if (_maxGeodesForFactory < state.Geode + state.Time * state.GeodeRobots) _maxGeodesForFactory = state.Geode + state.Time * state.GeodeRobots;
        if (state.Geode + state.Time * state.GeodeRobots + state.Time * state.Time < _maxGeodesForFactory) return 0;

        if (state.Time > 1 && state.Ore >= factory.GeodeRobotOreCost && state.Obsidian >= factory.GeodeRobotObsidianCost)
        {
            var newState = state.Clone();
            newState.BuildGeodeRobot();
            quality = Math.Max(0, state.Time - 1) + Math.Max(quality, Solve(factory, newState));
        }

        if (state.Time > 2 && state.ObsidianRobots < factory.GeodeRobotObsidianCost && state.Ore >= factory.ObsidianRobotOreCost && state.Clay >= factory.ObsidianRobotClayCost)
        {
            var newState = state.Clone();
            newState.BuildObsidianRobot();
            quality = Math.Max(quality, Solve(factory, newState));
        }

        if (state.Time > 3 && state.ClayRobots < factory.ObsidianRobotClayCost && state.Ore >= factory.ClayRobotOreCost)
        {
            var newState = state.Clone();
            newState.BuildClayRobot();
            quality = Math.Max(quality, Solve(factory, newState));
        }

        if (state.Time > 2 && state.OreRobots < factory.MaxOreCost && state.Ore >= factory.OreRobotOreCost)
        {
            var newState = state.Clone();
            newState.BuildOreRobot();
            quality = Math.Max(quality, Solve(factory, newState));
        }

        var stateClone = state.Clone();
        stateClone.Wait();
        quality = Math.Max(quality, Solve(factory, stateClone));

        _cache[hashCode] = quality;

        return quality;
    }

    private long GetHashCode(State state)
    {
        var hash = 17L;
        hash = hash * 23 + state.Ore.GetHashCode();
        hash = hash * 23 + state.Clay.GetHashCode();
        hash = hash * 23 + state.Obsidian.GetHashCode();
        hash = hash * 23 + state.Geode.GetHashCode();
        hash = hash * 23 + state.OreRobots.GetHashCode();
        hash = hash * 23 + state.ClayRobots.GetHashCode();
        hash = hash * 23 + state.ObsidianRobots.GetHashCode();
        hash = hash * 23 + state.GeodeRobots.GetHashCode();
        hash = hash * 23 + state.Time.GetHashCode();
        return hash;
    }

    private Factory ParseFactory(string line)
    {
        var numbers = Regex.Matches(line, @"\d+").Select(x => int.Parse(x.Value)).ToList();
        var factory = new Factory
        {
            Id = numbers[0],
            OreRobotOreCost = numbers[1],
            ClayRobotOreCost = numbers[2],
            ObsidianRobotOreCost = numbers[3],
            ObsidianRobotClayCost = numbers[4],
            GeodeRobotOreCost = numbers[5],
            GeodeRobotObsidianCost = numbers[6]
        };
        factory.MaxOreCost = new[] {factory.OreRobotOreCost, factory.ClayRobotOreCost, factory.ObsidianRobotOreCost, factory.GeodeRobotOreCost}.Max();
        return factory;
    }

    public class State
    {
        public int Ore { get; private set; }
        public int Clay { get; private set; }
        public int Obsidian { get; private set; }
        public int Geode { get; private set; }
        public int OreRobots { get; private set; }
        public int ClayRobots { get; private set; }
        public int ObsidianRobots { get; private set; }
        public int GeodeRobots { get; private set; }
        public int Time { get; private set; }
        private Factory Factory { get; }

        public State(Factory factory, int time)
        {
            Factory = factory;
            OreRobots = 1;
            Time = time;
        }
        
        public State Clone()
        {
            return (State) MemberwiseClone();
        }

        public void BuildOreRobot()
        {
            Ore -= Factory.OreRobotOreCost;
            Tick();
            OreRobots++;
        }

        public void BuildClayRobot()
        {
            Ore -= Factory.ClayRobotOreCost;
            Tick();
            ClayRobots++;
        }

        public void BuildObsidianRobot()
        {
            Ore -= Factory.ObsidianRobotOreCost;
            Clay -= Factory.ObsidianRobotClayCost;
            Tick();
            ObsidianRobots++;
        }

        public void BuildGeodeRobot()
        {
            Ore -= Factory.GeodeRobotOreCost;
            Obsidian -= Factory.GeodeRobotObsidianCost;
            Tick();
            GeodeRobots++;
        }

        public void Wait()
        {
            Tick();
        }

        private void Tick()
        {
            Ore += OreRobots;
            if (Ore > Factory.MaxOreCost * (Time - 1)) Ore = Factory.MaxOreCost * (Time - 1);
            Clay += ClayRobots;
            if (Clay > Factory.ObsidianRobotClayCost * (Time - 2)) Ore = Factory.ObsidianRobotClayCost * (Time - 2);
            Obsidian += ObsidianRobots;
            if (Obsidian > Factory.GeodeRobotObsidianCost * (Time - 1)) Obsidian = Factory.GeodeRobotObsidianCost * (Time - 1);
            Geode += GeodeRobots;
            Time--;
        }
    }

    public class Factory
    {
        public int Id { get; init; }
        public int OreRobotOreCost { get; init; }
        public int ClayRobotOreCost { get; init; }
        public int ObsidianRobotOreCost { get; init; }
        public int ObsidianRobotClayCost { get; init; }
        public int GeodeRobotOreCost { get; init; }
        public int GeodeRobotObsidianCost { get; init; }
        public int MaxOreCost { get; set; }
    }
}