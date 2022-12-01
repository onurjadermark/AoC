namespace Solutions.Solutions._2020;

public class Day07
{
    public long Part1(string[] input)
    {
        var bags = ParseBags(input);
        var bag = bags["shiny gold"];

        var possibleParents = bag.Parents;
        var stack = new Stack<string>(possibleParents);
        while (stack.Any())
        {
            var cur = stack.Pop();
            var curParents = bags[cur].Parents;
            curParents.ForEach(x => stack.Push(x));
            possibleParents.AddRange(curParents);
        }

        return possibleParents.ToHashSet().Count;
    }

    public int Part2(string[] input)
    {
        var bags = ParseBags(input);
        var bag = bags["shiny gold"];

        var contained = new List<(string, int)>();
        var stack = new Stack<(string Name, int Count)>(new (string, int)[] {(bag.Name, 1)});

        while (stack.Any())
        {
            var (name, curCount) = stack.Pop();
            var curBag = bags[name];
            foreach (var curBagChild in curBag.Children)
            {
                contained.Add((curBagChild.Key, curBagChild.Value * curCount));
                stack.Push((curBagChild.Key, curBagChild.Value * curCount));
            }
        }

        return contained.Sum(x => x.Item2);
    }

    private Dictionary<string, Bag> ParseBags(string[] input)
    {
        var result = new Dictionary<string, Bag>();

        foreach (var line in input)
        {
            var split = line.Split("bags contain");
            var name = split[0].Trim();
            var children = split[1].Split(',', '.').Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x));

            var parent = new Bag(name);
            result[name] = parent;

            foreach (var child in children)
            {
                var childCountAndName = string.Join(" ", child.Split(" ").SkipLast(1));
                if (childCountAndName.StartsWith("no other")) continue;
                var childCount = int.Parse(childCountAndName.Split(" ")[0]);
                var childName = string.Join(" ", childCountAndName.Split(" ").Skip(1));
                parent.Children[childName] = childCount;
            }
        }

        foreach (var bag in result)
        {
            var name = bag.Key;
            var cur = bag.Value;
            foreach (var child in cur.Children.Keys) result[child].Parents.Add(name);
        }

        return result;
    }

    private class Bag
    {
        public readonly List<string> Parents = new();

        public Bag(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public Dictionary<string, int> Children { get; } = new();
    }
}