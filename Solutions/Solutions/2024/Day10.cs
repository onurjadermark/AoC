using Solutions.Utils;

namespace Solutions.Solutions._2024;

public class Day10
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private int Solve(string[] input, int part)
    {
        var grid = GridFactory.FromInputStringsToInt(input);
        var sum = 0;
        
        foreach (var node in grid.Nodes.Where(x => x.Value == 0))
        {
            var visited = new Dictionary<Node<int>, int>();
            var toVisit = new Queue<Node<int>>();
            toVisit.Enqueue(node);
            while (toVisit.Any())
            {
                var current = toVisit.Dequeue();
                visited[current] = part == 1 ? 1 : visited.GetValueOrDefault(current) + 1;
                foreach (var neighbor in current.Neighbors)
                {
                    if (neighbor.Value == current.Value + 1)
                    {
                        toVisit.Enqueue(neighbor);
                    }
                }
            }

            sum += visited.Where(x => x.Key.Value == 9).Sum(x => x.Value);
        }

        return sum;
    }
}