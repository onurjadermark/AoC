using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day17
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
        var grid = GridFactory.FromInputStringsToInt(input);
        var start = grid.Nodes.MinBy(x => x.X + x.Y)!;
        var end = grid.Nodes.MaxBy(x => x.X + x.Y)!;
        var path = AStar(start, end, part);
        return path.Skip(1).Sum(x => x.Value);
    }

    private static IEnumerable<Node<int>> AStar(Node<int> start, Node<int> goal, int part)
    {
        var open = new PriorityQueue<(Node<int>, (int X, int Y)?, int), long>();
        var history = new Dictionary<(Node<int>, (int X, int Y)?, int), (Node<int>, (int X, int Y)?, int)>();
        var gScores = new Dictionary<(Node<int>, (int X, int Y)?, int), long> {[(start, null, 0)] = 0};
        open.Enqueue((start, null, 0), 0);

        while (open.Count > 0)
        {
            var (cur, direction, count) = open.Dequeue();
            if (cur.Equals(goal))
            {
                var result = new List<Node<int>> {cur};
                var curKey = (cur, direction, count);
                while (history.ContainsKey(curKey))
                {
                    curKey = history[curKey];
                    result.Add(curKey.cur);
                }

                result.Reverse();
                return result;
            }

            foreach (var n in cur.Neighbors)
            {
                var nextGScore = gScores[(cur, direction, count)] + n.Value;
                var nextDirection = (n.X - cur.X, n.Y - cur.Y);
                var nextCount = direction == nextDirection ? count + 1 : 0;

                if (direction != null && DirectionUtils.TurnAround(direction.Value) == nextDirection)
                {
                    nextGScore = long.MaxValue;
                }

                if (nextCount == (part == 1 ? 3 : 10))
                {
                    nextGScore = long.MaxValue;
                }

                if (part == 2 && direction != nextDirection && cur != start && count < 3)
                {
                    nextGScore = long.MaxValue;
                }

                if (part == 2 && n == goal && nextCount < 3)
                {
                    nextGScore = long.MaxValue;
                }

                if (nextGScore < gScores.GetValueOrDefault((n, nextDirection, nextCount), long.MaxValue))
                {
                    history[(n, nextDirection, nextCount)] = (cur, direction, count);
                    gScores[(n, nextDirection, nextCount)] = nextGScore;
                    open.Enqueue((n, nextDirection, nextCount), nextGScore + cur.ManDistance(goal));
                }
            }
        }

        throw new Exception();
    }
}