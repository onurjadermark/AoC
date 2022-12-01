namespace Solutions.Solutions._2018;

public class Day08
{
    public int Part1(string input)
    {
        var numbers = input.Split().Select(int.Parse).ToList();

        var nodes = new List<Node>();
        var index = 0;
        FillNodes(numbers, ref index, nodes, null);

        return nodes.Sum(x => x.Metadata.Sum());
    }

    private void FillNodes(List<int> numbers, ref int currentIndex, List<Node> nodes, Node? parent)
    {
        var numChildren = numbers[currentIndex];
        var numMetadata = numbers[currentIndex + 1];
        var node = new Node
            {
            };
        nodes.Add(node);
        parent?.Children.Add(node);
        currentIndex += 2;
        for (var i = 0; i < numChildren; i++) FillNodes(numbers, ref currentIndex, nodes, node);
        for (var i = 0; i < numMetadata; i++)
        {
            node.Metadata.Add(numbers[currentIndex]);
            currentIndex++;
        }
    }

    public int Part2(string input)
    {
        var numbers = input.Split().Select(int.Parse).ToList();

        var nodes = new List<Node>();
        var index = 0;
        FillNodes(numbers, ref index, nodes, null);

        return GetValue(nodes.First());
    }

    private int GetValue(Node node)
    {
        return !node.Children.Any()
            ? node.Metadata.Sum()
            : node.Metadata.Select(x => x <= node.Children.Count ? GetValue(node.Children[x - 1]) : 0).Sum();
    }

    private class Node
    {
        public List<Node> Children { get; } = new();

        public List<int> Metadata { get; } = new();
    }
}