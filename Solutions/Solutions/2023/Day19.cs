using MoreLinq.Extensions;

namespace Solutions.Solutions._2023;

public class Day19
{
    public long Part1(string[] input)
    {
        var rulesInput = input.TakeUntil(string.IsNullOrWhiteSpace).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        var partsInput = input.SkipUntil(string.IsNullOrWhiteSpace).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

        var rules = ParseRules(rulesInput);
        var parts = ParseParts(partsInput);

        var accepted = new List<Part>();

        var segments = GetSegments(rules);

        foreach (var part in parts)
        {
            var matching = segments.Single(x => part.A >= x.MinA && part.A <= x.MaxA
                                                                 && part.M >= x.MinM && part.M <= x.MaxM
                                                                 && part.X >= x.MinX && part.X <= x.MaxX
                                                                 && part.S >= x.MinS && part.S <= x.MaxS);
            if (matching.Accepted!.Value)
            {
                accepted.Add(part);
            }
        }

        return accepted.Sum(x => x.A + x.M + x.S + x.X);
    }

    public long Part2(string[] input)
    {
        var rulesInput = input.TakeUntil(string.IsNullOrWhiteSpace).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        var rules = ParseRules(rulesInput);
        var combinations = GetSegments(rules);
        return CountCombinations(combinations.Where(x => x.Accepted!.Value));
    }

    private List<Part> ParseParts(List<string> partsInput)
    {
        var parsedParts = new List<Part>();

        foreach (var partString in partsInput)
        {
            var part = new Part();

            foreach (var pair in partString.Trim('{', '}').Split(','))
            {
                var split = pair.Split('=');
                var value = int.Parse(split[1]);
                switch (split[0])
                {
                    case "x":
                        part.X = value;
                        break;
                    case "m":
                        part.M = value;
                        break;
                    case "a":
                        part.A = value;
                        break;
                    case "s":
                        part.S = value;
                        break;
                }
            }

            parsedParts.Add(part);
        }

        return parsedParts;
    }
    
    private static Dictionary<string, Rule> ParseRules(IEnumerable<string> ruleStrings)
    {
        var rules = new Dictionary<string, Rule>();

        foreach (var ruleString in ruleStrings)
        {
            var parts = ruleString.Trim().Split(new []{'{', '}'}, StringSplitOptions.RemoveEmptyEntries);
            var rule = new Rule
            {
                Name = parts[0],
                Cases = new List<RuleCase>()
            };

            foreach (var caseString in parts[1].Split(','))
            {
                var conditionSplit = caseString.Split(':');
                rule.Cases.Add(new RuleCase
                {
                    Condition = conditionSplit.Length > 1 ? ParseCondition(conditionSplit[0]) : null,
                    NextRule = conditionSplit.Length > 1 ? conditionSplit[1] : caseString
                });
            }

            rules.Add(rule.Name, rule);
        }

        return rules;
    }

    private static RuleCondition ParseCondition(string condition)
    {
        var parts = condition.Split('<', '>');

        var ruleCondition = new RuleCondition
        {
            Name = parts[0],
            Operator = condition[parts[0].Length],
            Value = int.Parse(parts[1])
        };

        return ruleCondition;
    }

    private static long CountCombinations(IEnumerable<Segment> combinations)
    {
        return combinations.Sum(x => ((long) x.MaxX - x.MinX + 1) * (x.MaxA - x.MinA + 1) * (x.MaxS - x.MinS + 1) * (x.MaxM - x.MinM + 1));
    }

    private List<Segment> GetSegments(Dictionary<string, Rule> rules)
    {
        var segments = new List<Segment> {new() {NextRule = "in", MinX = 1, MinA = 1, MinM = 1, MinS = 1, MaxA = 4000, MaxM = 4000, MaxS = 4000, MaxX = 4000}};

        while (segments.Any(x => !x.Accepted.HasValue))
        {
            var curSegment = segments.First(x => !x.Accepted.HasValue);

            var rule = rules[curSegment.NextRule];

            foreach (var ruleCase in rule.Cases)
            {
                if (ruleCase.Condition == null)
                {
                    curSegment.NextRule = ruleCase.NextRule;
                    switch (ruleCase.NextRule)
                    {
                        case "A":
                            curSegment.Accepted = true;
                            continue;
                        case "R":
                            curSegment.Accepted = false;
                            break;
                    }
                }
                else
                {
                    var newSegment = new Segment(curSegment);
                    segments.Add(newSegment);
                    newSegment.NextRule = ruleCase.NextRule;
                    if (ruleCase.Condition.Operator == '<')
                    {
                        switch (ruleCase.Condition.Name)
                        {
                            case "x":
                                curSegment.MinX = Math.Max(curSegment.MinX, ruleCase.Condition.Value);
                                newSegment.MaxX = Math.Min(newSegment.MaxX, ruleCase.Condition.Value - 1);
                                break;
                            case "m":
                                curSegment.MinM = Math.Max(curSegment.MinM, ruleCase.Condition.Value);
                                newSegment.MaxM = Math.Min(newSegment.MaxM, ruleCase.Condition.Value - 1);
                                break;
                            case "a":
                                curSegment.MinA = Math.Max(curSegment.MinA, ruleCase.Condition.Value);
                                newSegment.MaxA = Math.Min(newSegment.MaxA, ruleCase.Condition.Value - 1);
                                break;
                            case "s":
                                curSegment.MinS = Math.Max(curSegment.MinS, ruleCase.Condition.Value);
                                newSegment.MaxS = Math.Min(newSegment.MaxS, ruleCase.Condition.Value - 1);
                                break;
                        }
                    }
                    else if (ruleCase.Condition.Operator == '>')
                    {
                        switch (ruleCase.Condition.Name)
                        {
                            case "x":
                                curSegment.MaxX = Math.Min(curSegment.MaxX, ruleCase.Condition.Value);
                                newSegment.MinX = Math.Max(newSegment.MinX, ruleCase.Condition.Value + 1);
                                break;
                            case "m":
                                curSegment.MaxM = Math.Min(curSegment.MaxM, ruleCase.Condition.Value);
                                newSegment.MinM = Math.Max(newSegment.MinM, ruleCase.Condition.Value + 1);
                                break;
                            case "a":
                                curSegment.MaxA = Math.Min(curSegment.MaxA, ruleCase.Condition.Value);
                                newSegment.MinA = Math.Max(newSegment.MinA, ruleCase.Condition.Value + 1);
                                break;
                            case "s":
                                curSegment.MaxS = Math.Min(curSegment.MaxS, ruleCase.Condition.Value);
                                newSegment.MinS = Math.Max(newSegment.MinS, ruleCase.Condition.Value + 1);
                                break;
                        }
                    }

                    if (ruleCase.NextRule == "A")
                    {
                        newSegment.Accepted = true;
                        continue;
                    }

                    if (ruleCase.NextRule == "R")
                    {
                        newSegment.Accepted = false;
                    }
                }
            }
        }

        return segments;
    }

    private class Part
    {
        public int X { get; set; }
        public int M { get; set; }
        public int A { get; set; }
        public int S { get; set; }
    }

    private class Rule
    {
        public string Name { get; set; }
        public List<RuleCase> Cases { get; set; }
    }

    private class RuleCase
    {
        public RuleCondition? Condition { get; set; }
        public string NextRule { get; set; }
    }

    private class RuleCondition
    {
        public string Name { get; set; }
        public char Operator { get; set; }
        public int Value { get; set; }
    }

    private class Segment
    {
        public Segment(Segment cur)
        {
            MinX = cur.MinX;
            MaxX = cur.MaxX;
            MinS = cur.MinS;
            MaxS = cur.MaxS;
            MinA = cur.MinA;
            MaxA = cur.MaxA;
            MinM = cur.MinM;
            MaxM = cur.MaxM;
            Accepted = cur.Accepted;
            NextRule = cur.NextRule;
        }

        public Segment()
        {
        }

        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MinS { get; set; }
        public int MaxS { get; set; }
        public int MinA { get; set; }
        public int MaxA { get; set; }
        public int MinM { get; set; }
        public int MaxM { get; set; }
        public bool? Accepted { get; set; }
        public string NextRule { get; set; }
    }
}