using System.Text;

namespace Solutions.Solutions._2018;

public class Day12
{
    public long Part1(string input)
    {
        var states = new string[21];
        var lines = input.Split('\n');
        var rules = GetRules(lines);
        states[0] = GetInitialState(lines);

        for (var i = 1; i <= 20; i++)
        {
            var state = "";
            for (var j = 0; j < states[i - 1].Length; j++)
            {
                var cur = GetState(states[i - 1], j);
                var rule = rules.FirstOrDefault(x => x.State == cur);
                if (rule != null)
                    state += rule.PutPlant ? "#" : ".";
                else
                    state += ".";
            }

            states[i] = state;
        }

        return GetSum(states, 20);
    }

    public long Part2(string input)
    {
        var states = new string[200];
        var lines = input.Split('\n');
        var rules = GetRules(lines).ToList();
        states[0] = GetInitialState(lines);

        var currentDay = 1;
        while (currentDay < 200)
        {
            var stringBuilder = new StringBuilder();
            for (var j = 0; j < states[currentDay - 1].Length; j++)
            {
                var cur = GetState(states[currentDay - 1], j);
                var rule = rules.FirstOrDefault(x => x.State == cur);
                if (rule != null)
                    stringBuilder.Append(rule.PutPlant ? "#" : ".");
                else
                    stringBuilder.Append(".");
            }

            stringBuilder.Append("..........");
            states[currentDay] = stringBuilder.ToString();
            currentDay++;
        }

        var diff = GetSum(states, 129) - GetSum(states, 128);
        return (50000000000 - 129) * diff + GetSum(states, 129);
    }

    private static string GetInitialState(string[] lines)
    {
        return string.Join("", Enumerable.Repeat(".", 5)) + lines[0][15..].Trim() +
               string.Join("", Enumerable.Repeat(".", 1000));
    }

    private static IEnumerable<Rule> GetRules(string[] lines)
    {
        return lines.Skip(2).Select(x => new Rule(x.Split(" => ")[0], x.Split(" => ")[1].StartsWith("#")));
    }

    private static int GetSum(string[] states, int i)
    {
        var sum = 0;
        for (var z = 0; z < states[i].Length; z++)
            if (states[i][z] == '#')
                sum += z - 5;

        return sum;
    }

    private string GetState(string str, int i)
    {
        var result = "";
        for (var j = i - 2; j < i + 3; j++)
            if (j < 0 || j >= str.Length)
                result += ".";
            else
                result += str[j];
        return result;
    }

    private class Rule
    {
        public Rule(string state, bool putPlant)
        {
            State = state;
            PutPlant = putPlant;
        }

        public string State { get; }
        public bool PutPlant { get; }
    }
}