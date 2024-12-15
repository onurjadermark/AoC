using MoreLinq;
using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day03
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static int Solve(string[] input, int part)
    {
        var result = 0;
        var grid = InitializeGrid(input);

        foreach (var node in grid.Nodes.Where(n => char.IsDigit(n.Value)))
        {
            if (node.X > 0 && char.IsDigit(node.Left!.Value)) continue;
            var digits = FindAdjacentDigits(node);
            var value = CalculateValue(digits);

            switch (part)
            {
                case 1:
                    if (digits.Any(x => x.Neighbors.Any(y => !char.IsDigit(y.Value) && y.Value != '.')))
                    {
                        result += value;
                    }

                    break;
                case 2:
                {
                    var gearNode = FindGearNode(digits);
                    if (gearNode == null) continue;

                    var neighboringNodes = gearNode.Neighbors.Where(x => !digits.Contains(x) && char.IsDigit(x.Value)).ToList();
                    if (!neighboringNodes.Any()) continue;

                    var neighboringDigits = FindAdjacentDigits(neighboringNodes.First());
                    if (neighboringDigits.First().Id > digits.First().Id)
                    {
                        result += value * CalculateValue(neighboringDigits);
                    }

                    break;
                }
            }
        }

        return result;
    }

    private static Node<char>? FindGearNode(List<Node<char>> digits)
    {
        return digits.SelectMany(x => x.Neighbors).FirstOrDefault(x => x.Value == '*');
    }

    private static Grid<char> InitializeGrid(string[] input)
    {
        var grid = new Grid<char>(input.Length, input[0].Length, true);
        grid.Nodes.ForEach(x => x.Value = input[x.Y][x.X]);
        return grid;
    }

    private static List<Node<char>> FindAdjacentDigits(Node<char> node)
    {
        while (node.Left != null && char.IsDigit(node.Left.Value))
        {
            node = node.Left;
        }

        var cur = node;
        var digits = new List<Node<char>> {cur};
        while (true)
        {
            var neighbor = cur.Right;
            if (neighbor == null || !char.IsDigit(neighbor.Value)) break;
            cur = neighbor;
            digits.Add(cur);
        }

        return digits;
    }

    private static int CalculateValue(List<Node<char>> digits)
    {
        var value = digits.First().Value - '0';
        foreach (var digit in digits.Skip(1))
        {
            value *= 10;
            value += digit.Value - '0';
        }

        return value;
    }
}