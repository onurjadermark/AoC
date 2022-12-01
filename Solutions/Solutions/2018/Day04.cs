namespace Solutions.Solutions._2018;

public class Day04
{
    public int Part1(string[] input)
    {
        var asleepMinutes = GetEntries(input);

        var mostAsleepGuard = asleepMinutes.MaxBy(x => x.Value.Sum(y => y.Value));
        var chosenMinute = 0;
        var chosenMinuteSleep = 0;
        for (var i = 0; i < 60; i++)
            if (mostAsleepGuard.Value[i] > chosenMinuteSleep)
            {
                chosenMinute = i;
                chosenMinuteSleep = mostAsleepGuard.Value[i];
            }

        return mostAsleepGuard.Key * chosenMinute;
    }

    public int Part2(string[] input)
    {
        var asleepMinutes = GetEntries(input);
        var chosenGuardId = 0;
        var chosenMinuteSleep = 0;
        var chosenMinute = 0;

        foreach (var guardId in asleepMinutes.Keys)
            for (var i = 0; i < 60; i++)
                if (asleepMinutes[guardId][i] > chosenMinuteSleep)
                {
                    chosenGuardId = guardId;
                    chosenMinuteSleep = asleepMinutes[guardId][i];
                    chosenMinute = i;
                }

        return chosenMinute * chosenGuardId;
    }

    private Dictionary<int, Dictionary<int, int>> GetEntries(string[] input)
    {
        var entries = input.Select(ToEntry).OrderBy(x => x.Month).ThenBy(x => x.Day).ThenBy(x => x.Hour)
            .ThenBy(x => x.Minute).ToList();

        var asleepMinutes = new Dictionary<int, Dictionary<int, int>>();
        var fallAsleepMinute = 0;
        var guardId = 0;
        foreach (var entry in entries)
            if (entry.EventType == EventType.StartShift)
            {
                guardId = entry.GuardId ?? -1;
                if (!asleepMinutes.ContainsKey(guardId))
                {
                    asleepMinutes[guardId] = new Dictionary<int, int>();
                    for (var i = 0; i < 60; i++) asleepMinutes[guardId][i] = 0;
                }
            }
            else if (entry.EventType == EventType.FallAsleep)
            {
                fallAsleepMinute = entry.Minute;
            }
            else if (entry.EventType == EventType.WakeUp)
            {
                for (var i = fallAsleepMinute; i < entry.Minute; i++) asleepMinutes[guardId][i]++;
            }

        return asleepMinutes;
    }

    private Entry ToEntry(string line)
    {
        var split = line.Split('[', '-', ':', ']', ' ', '#').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        return new Entry
        {
            Month = int.Parse(split[1]),
            Day = int.Parse(split[2]),
            Hour = int.Parse(split[3]),
            Minute = int.Parse(split[4]),
            GuardId = int.TryParse(split[6], out _) ? int.Parse(split[6]) : null,
            EventType = GetEventType(split[5])
        };
    }

    private static EventType GetEventType(string str)
    {
        return str switch
        {
            "Guard" => EventType.StartShift,
            "falls" => EventType.FallAsleep,
            "wakes" => EventType.WakeUp,
            _ => throw new Exception()
        };
    }

    private enum EventType
    {
        StartShift,
        FallAsleep,
        WakeUp
    }

    private class Entry
    {
        public int? GuardId { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public EventType EventType { get; set; }
    }
}