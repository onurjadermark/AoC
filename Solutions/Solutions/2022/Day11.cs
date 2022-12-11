using System.Numerics;

namespace Solutions.Solutions._2022;

public class Day11
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
        var monkeys = new List<Monkey>();
        for (var i = 0; i < input.Length; i += 7)
        {
            var monkey = ParseInput(input.Skip(i).Take(6).ToArray());
            monkeys.Add(monkey);
        }

        var commonDivisor = monkeys.Select(x => x.DivisibleByTest).Aggregate((x, y) => x * y);

        for (var i = 0; i < (part == 1 ? 20 : 10000); i++)
        {
            foreach (var cur in monkeys)
            {
                foreach (var item in cur.Items.ToList())
                {
                    cur.Inspect(item);
                    cur.Adjust(item, part, commonDivisor);
                    cur.Throw(item, monkeys);
                }
            }
        }

        return monkeys.OrderByDescending(x => x.NumberOfInspections).Take(2).Select(x => x.NumberOfInspections).Aggregate((x, y) => x * y);
    }

    private static Monkey ParseInput(IReadOnlyList<string> lines)
    {
        return new Monkey
        {
            Id = lines[0].Split(" ")[1][0] - '0',
            Items = lines[1].Split(" ").Skip(4).Select(x => x.Trim(',')).Select(long.Parse).Select(x => new Item {Value = x}).ToList(),
            OperationType = lines[2].Contains("+") ? OperationType.Add : OperationType.Multiply,
            OperationTarget = lines[2].Split("old").Length == 2 ? OperationTarget.Number : OperationTarget.Self,
            OperationTargetInt = int.TryParse(lines[2].Split(" ").Last(), out _) ? int.Parse(lines[2].Split(" ").Last()) : null,
            DivisibleByTest = int.Parse(lines[3].Split(" ").Last()),
            TrueTestThrowTo = int.Parse(lines[4].Split(" ").Last()),
            FalseTestThrowTo = int.Parse(lines[5].Split(" ").Last())
        };
    }
    
    private sealed class Item
    {
        public long Value { get; set; }
    }

    private enum OperationType
    {
        Add,
        Multiply
    }

    private enum OperationTarget
    {
        Number,
        Self
    }

    private sealed class Monkey
    {
        public int Id { get; init; }
        public List<Item> Items { get; init; } = new();
        public OperationType OperationType { get; init; }
        public OperationTarget OperationTarget { get; init; }
        public int? OperationTargetInt { get; init; }
        public int DivisibleByTest { get; init; }
        public int TrueTestThrowTo { get; init; }
        public int FalseTestThrowTo { get; init; }
        public long NumberOfInspections { get; private set; }

        public void Inspect(Item item)
        {
            switch (OperationType)
            {
                case OperationType.Add:
                    item.Value += OperationTarget == OperationTarget.Number ? OperationTargetInt!.Value : item.Value + item.Value;
                    break;
                case OperationType.Multiply:
                    item.Value *= OperationTarget == OperationTarget.Number ? OperationTargetInt!.Value : item.Value;
                    break;
                default:
                    throw new NotImplementedException();
            }

            NumberOfInspections++;
        }

        public void Adjust(Item item, int part, int commonDivisor)
        {
            if (part == 1) item.Value /= 3;
            item.Value %= commonDivisor;
        }

        public void Throw(Item item, List<Monkey> monkeys)
        {
            var targetId = item.Value % DivisibleByTest == 0 ? TrueTestThrowTo : FalseTestThrowTo;
            monkeys.Single(x => x.Id == targetId).Items.Add(item);
            Items.Remove(item);
        }
    }
}