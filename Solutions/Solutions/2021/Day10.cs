namespace Solutions.Solutions._2021;

public class Day10
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(string[] input, int part)
    {
        var points = new List<long>();
        var translate = new Dictionary<char, char>
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
            {'<', '>'}
        };
        var errorPoints = new Dictionary<char, int>
        {
            {')', 3},
            {']', 57},
            {'}', 1197},
            {'>', 25137}
        };
        var autoCompletePoints = new Dictionary<char, int>
        {
            {')', 1},
            {']', 2},
            {'}', 3},
            {'>', 4}
        };

        foreach (var line in input)
        {
            var stack = new Stack<char>();

            var valid = true;
            for (var i = 0; i < line.Length; i++)
            {
                var cur = line[i];
                if (translate.Keys.Contains(cur))
                {
                    stack.Push(cur);
                }
                else
                {
                    var prev = stack.Pop();
                    if (translate[prev] == cur) continue;

                    valid = false;
                    if (part == 1) points.Add(errorPoints[cur]);
                }
            }

            if (part == 1 || !valid) continue;

            long curPoints = 0;
            while (stack.Any())
            {
                var cur = stack.Pop();
                curPoints *= 5;
                curPoints += autoCompletePoints[translate[cur]];
            }

            points.Add(curPoints);
        }

        return part == 1 ? points.Sum() : points.OrderBy(x => x).ElementAt(points.Count / 2);
    }
}