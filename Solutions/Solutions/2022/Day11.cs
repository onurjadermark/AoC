using System.Numerics;

namespace Solutions.Solutions._2022;

public class Day11
{
    private class Item
    {
        public int Id { get; set; }
        public BigInteger Value { get; set; }
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
    
    private class Monkey
    {
        public int Id { get; init; }
        public List<Item> Items { get; set; } 
        public OperationType OperationType { get; set; }
        public OperationTarget OperationTarget { get; set; }
        public int OperationTargetInt { get; set; }
        public int DivisibleByTest { get; set; }
        public int TrueTestThrowTo { get; set; }
        public int FalseTestThrowTo { get; set; }
        public BigInteger NumberOfInspections { get; set; }
    }
    
    public BigInteger Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public BigInteger Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static BigInteger Solve(string[] input, int part)
    {
        var monkeys = new List<Monkey>();
        var commonDivisor = 1;
        for (var i = 0; i < input.Length; i+=7)
        {
            var line = input[i];
            var monkey = new Monkey()
            {
                Id = line.Split(" ")[1][0] - '0'
            };
            var itemIndex = 0;
            
            line = input[i + 1];
            monkey.Items = line.Split(" ").Skip(4).Select(x => x.Trim(',')).Select(BigInteger.Parse).Select(x => new Item() {Value = x}).ToList();
            foreach (var item in monkey.Items)
            {
                item.Id = itemIndex;
                itemIndex++;
            }
            
            line = input[i + 2];
            monkey.OperationType = line.Contains("+") ? OperationType.Add : OperationType.Multiply;
            monkey.OperationTarget = line.IndexOf("old") == line.LastIndexOf("old") ? OperationTarget.Number : OperationTarget.Self;
            if (monkey.OperationTarget == OperationTarget.Number)
            {
                monkey.OperationTargetInt = int.Parse(line.Split(" ").Last());
            }

            line = input[i + 3];
            monkey.DivisibleByTest = int.Parse(line.Split(" ").Last());
            commonDivisor *= monkey.DivisibleByTest;

            line = input[i + 4];
            monkey.TrueTestThrowTo = int.Parse(line.Split(" ").Last());

            line = input[i + 5];
            monkey.FalseTestThrowTo = int.Parse(line.Split(" ").Last());
            
            monkeys.Add(monkey);
        }
        
        for (var i = 0; i < (part == 1 ? 20 : 10000); i++)
        {
            for (var j = 0; j < monkeys.Count; j++)
            {
                var cur = monkeys.OrderBy(x => x.Id).ToList()[j];
                foreach (var item in cur.Items)
                {
                    if (cur.OperationType == OperationType.Add)
                    {
                        if (cur.OperationTarget == OperationTarget.Number)
                        {
                            item.Value += cur.OperationTargetInt;
                        }
                        else
                        {
                            item.Value += item.Value + item.Value;
                        }
                    }
                    else
                    {
                        if (cur.OperationTarget == OperationTarget.Number)
                        {
                            item.Value *= cur.OperationTargetInt;
                        }
                        else
                        {
                            item.Value *= item.Value;
                        }
                    }

                    if (part == 1)
                    {
                        item.Value /= 3;
                    }

                    item.Value %= commonDivisor;

                    if (item.Value % cur.DivisibleByTest == 0)
                    {
                        monkeys.First(x => x.Id == cur.TrueTestThrowTo).Items.Add(item);
                    }
                    else
                    {
                        monkeys.First(x => x.Id == cur.FalseTestThrowTo).Items.Add(item);
                    }
                }

                cur.NumberOfInspections += cur.Items.Count;
                cur.Items.Clear();
            }
        }

        monkeys = monkeys.OrderByDescending(x => x.NumberOfInspections).ToList();

        return monkeys[0].NumberOfInspections * monkeys[1].NumberOfInspections;
    }
}