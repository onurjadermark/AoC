namespace Solutions.Solutions._2020;

public class Day16
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string[] input, int part)
    {
        var lines = input;

        var rules = new List<Rule>();
        var myTicket = new List<int>();
        var tickets = new List<List<int>>();

        var reading = 0;
        foreach (var line in lines)
        {
            if (line.StartsWith("your") || line.StartsWith("nearby")) continue;

            if (string.IsNullOrWhiteSpace(line))
            {
                reading++;
                continue;
            }

            if (reading == 0)
            {
                var split = line.Split(":").ToList();
                split = split.SelectMany(x => x.Split(" or ")).ToList();
                split = split.SelectMany(x => x.Split("-")).ToList();
                split = split.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var rule = new Rule(split[0], new List<(int Min, int Max)>());
                rules.Add(rule);
                rule.Intervals.Add((int.Parse(split[1]), int.Parse(split[2])));
                rule.Intervals.Add((int.Parse(split[3]), int.Parse(split[4])));
            }

            if (reading == 1) myTicket = line.Split(",").Select(int.Parse).ToList();

            if (reading == 2) tickets.Add(line.Split(",").Select(int.Parse).ToList());
        }

        var invalidTickets = new List<List<int>>();

        var result = 0;
        foreach (var ticket in tickets)
        foreach (var value in ticket)
        {
            var valid = false;
            foreach (var rule in rules)
            foreach (var interval in rule.Intervals)
                if (interval.Min <= value && value <= interval.Max)
                    valid = true;

            if (!valid)
            {
                result += value;
                invalidTickets.Add(ticket);
            }
        }

        var validTickets = tickets.Except(invalidTickets).ToList();
        validTickets.Add(myTicket);

        var wantedFields = new List<long>();
        var foundRules = new Rule[rules.Count];

        while (foundRules.Any(x => x == null))
            for (var i = 0; i < myTicket.Count; i++)
            {
                var validRules = new List<Rule>();
                foreach (var rule in rules.Except(foundRules))
                {
                    var valid = true;
                    foreach (var ticket in validTickets)
                        if (ticket[i] < rule.Intervals[0].Min
                            || (rule.Intervals[0].Max < ticket[i] && ticket[i] < rule.Intervals[1].Min)
                            || rule.Intervals[1].Max < ticket[i])
                            valid = false;

                    if (valid) validRules.Add(rule);
                }

                if (validRules.Count == 1)
                {
                    foundRules[i] = validRules.Single();
                    if (validRules.Single().Name.ToLower().Contains("departure"))
                    {
                        wantedFields.Add(myTicket[i]);
                        break;
                    }
                }
            }

        return part == 1 ? result : wantedFields.Aggregate((x, y) => x * y);
    }

    private static bool InInterval((int Min, int Max) interval, int value)
    {
        return interval.Min <= value && value <= interval.Max;
    }

    private class Rule
    {
        public Rule(string name, List<(int Min, int Max)> intervals)
        {
            Name = name;
            Intervals = intervals;
        }

        public string Name { get; set; }
        public List<(int Min, int Max)> Intervals { get; set; }
    }
}