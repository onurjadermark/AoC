using System.Text.RegularExpressions;

namespace Solutions.Solutions._2022;

public class Day21
{
    private class Monkey
    {
        public string Name { get; set; }
        public string? Number { get; set; }
        public string? FirstOperand { get; set; }
        public string? SecondOperand { get; set; }
        public string? Operation { get; set; }
        public string? Value { get; set; }
    }
    
    public long Part1(string[] input)
    {
        var monkeys = input.Select(ParseMonkey).ToList();
        var dict = monkeys.ToDictionary(x => x.Name);
        var root = monkeys.Single(x => x.Name == "root");
        while (root.Number == null)
        {
            var target = monkeys.First(x =>
                x.Number == null &&
                dict[x.FirstOperand!].Number != null &&
                dict[x.SecondOperand!].Number != null);
            var monkey1 = dict[target.FirstOperand!];
            var monkey2 = dict[target.SecondOperand!];
            target.Number = target.Operation switch
            {
                "+" => (long.Parse(monkey1.Number!) + long.Parse(monkey2.Number!)).ToString(),
                "-" => (long.Parse(monkey1.Number!) - long.Parse(monkey2.Number!)).ToString(),
                "*" => (long.Parse(monkey1.Number!) * long.Parse(monkey2.Number!)).ToString(),
                "/" => (long.Parse(monkey1.Number!) / long.Parse(monkey2.Number!)).ToString(),
                _ => target.Number
            };
        }
        return long.Parse(root.Number);
    }
    
    public long Part2(string[] input)
    {
        var monkeys = input.Select(ParseMonkey).ToList();
        var dict = monkeys.ToDictionary(x => x.Name);
        var root = monkeys.Single(x => x.Name == "root");
        var human = monkeys.Single(x => x.Name == "humn");
        human.Number = "X";
        root.Operation = "=";
        foreach (var monkey in monkeys.Where(x => x.Number != null)) monkey.Value = monkey.Number;
        while (root.Value == null)
        {
            var target = monkeys.First(x =>
                x.Value == null &&
                dict[x.FirstOperand!].Value != null &&
                dict[x.SecondOperand!].Value != null);
            var monkey1 = dict[target.FirstOperand!];
            var monkey2 = dict[target.SecondOperand!];
            target.Value = "(" + monkey1.Value + target.Operation + monkey2.Value + ")";
        }

        var split = root.Value.Substring(1, root.Value.Length - 2).Split('=');
        var first = split.Single(x => !x.Contains("X"));
        var second = split.Single(x => x.Contains("X"));
        var result = Solve(first);
        var expression = '(' + second + '-' + result + ')';
        result = Solve(expression);
        return SolveBackwards(result);
    }

    private string Solve(string str)
    {
        while (true)
        {
            var regex = new Regex("\\(\\d+.\\d+\\)");
            if (!regex.IsMatch(str)) break;
            var match = regex.Match(str);
            var cur = match.Value;
            var split = cur.Split('+', '-', '/', '*');
            var first = long.Parse(split[0].Trim('('));
            var second = long.Parse(split[1].Trim(')'));
            var result = cur.Substring(split[0].Length, 1) switch
            {
                "+" => first + second,
                "-" => first - second,
                "*" => first * second,
                "/" => first / second,
                _ => 0L
            };

            str = str.Replace(cur, result.ToString());
        }

        return str;
    }

    private long SolveBackwards(string str)
    {
        var value = 0L;
        while (str != "X")
        {
            while (str[0] == '(' && str[^1] == ')') str = str.Substring(1, str.Length - 2);
            var takeFromEnd = str[0] == '(' || str[0] == 'X';
            var numStr = takeFromEnd
                ? string.Join("", str.Reverse().TakeWhile(x => x is >= '0' and <= '9').Reverse())
                : string.Join("", str.TakeWhile(x => x is >= '0' and <= '9'));
            var op = takeFromEnd ? str[str.Length - 1 - numStr.Length] : str[numStr.Length];
            var num = long.Parse(numStr);
            value = op switch
            {
                '+' => value - num,
                '-' => takeFromEnd ? value + num : num - value,
                '*' => value / num,
                '/' => takeFromEnd ? value * num : value / num,
                _ => 0L
            };

            str = takeFromEnd ? str[..(str.Length - numStr.Length - 1)] : str[(numStr.Length + 1)..];
        }

        return value;
    }

    private Monkey ParseMonkey(string line)
    {
        var split = line.Split(" ");
        var isNum = int.TryParse(split[1], out int number);
        var monkey = new Monkey()
        {
            Name = split[0].Trim(':'),
            Number = isNum ? split[1] : null,
            FirstOperand = isNum ? null : split[1],
            SecondOperand = isNum ? null : split[3],
            Operation = isNum ? null : split[2]
        };
        return monkey;
    }
}