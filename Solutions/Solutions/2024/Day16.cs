using Solutions.Utils;

namespace Solutions.Solutions._2024;

public class Day16
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
        var (start, end) = ParseGrid(input);
        var dict = new Dictionary<(Node<char> Node, (int X, int Y) Direction), int> {[(start, (1, 0))] = 0};
        var queue = new PriorityQueue<(List<Node<char>> Path, (int X, int Y) Direction, int Score), int>();
        queue.Enqueue(([start], (1, 0), 0), 0);
        var seats = new Dictionary<int, HashSet<Node<char>>>();
        
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var lastNode = current.Path.Last();
            
            if (dict.TryGetValue((lastNode, current.Direction), out var score) && score < current.Score)
            {
                continue;
            }
            
            if (seats.Any() && seats.Min(x => x.Key) < current.Score)
            {
                continue;
            }

            dict[(lastNode, current.Direction)] = current.Score;

            if (lastNode == end)
            {
                if (seats.ContainsKey(current.Score))
                {
                    current.Path.ForEach(x => seats[current.Score].Add(x));
                }
                else
                {
                    seats[current.Score] = [..current.Path];
                }
            }

            var turnRight = DirectionUtils.TurnRight(current.Direction);
            if (lastNode.GetNeighbor(turnRight)?.Value == '.')
            {
                queue.Enqueue((current.Path, turnRight, current.Score + 1000), current.Score + 1000);
            }

            var turnLeft = DirectionUtils.TurnLeft(current.Direction);
            if (lastNode.GetNeighbor(turnLeft)?.Value == '.')
            {
                queue.Enqueue((current.Path, turnLeft, current.Score + 1000), current.Score + 1000);
            }

            var neighbor = lastNode.GetNeighbor(current.Direction);
            if (neighbor?.Value == '.')
            {
                queue.Enqueue((current.Path.ToList().Concat([neighbor]).ToList(), current.Direction, current.Score + 1), current.Score + 1);
            }
        }

        return part == 1 ? dict.Where(x => x.Key.Node == end).Min(x => x.Value) : seats[seats.Keys.Min()].Count;
    }

    private static (Node<char> start, Node<char> end) ParseGrid(string[] input)
    {
        var grid = GridFactory.FromInputStrings(input);
        var start = grid.Nodes.Single(x => x.Value == 'S');
        start.Value = '.';
        var end = grid.Nodes.Single(x => x.Value == 'E');
        end.Value = '.';
        return (start, end);
    }
}