namespace Solutions.Solutions._2023;

public class Day08
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
        var moves = input[0];
        var nodes = input.Skip(2).Select(x => x.Split(',', '(', ')', '=').Select(y => y.Trim()).Where(y => !string.IsNullOrWhiteSpace(y)).ToList())
            .ToDictionary(x => x[0], x => x.Skip(1).ToList());

        var steps = 0;
        var curNodes = nodes.Select(x => x.Key).Where(x => part == 1 ? x == "AAA" : x.Last() == 'A').ToList();
        var indexes = new long?[curNodes.Count];
        
        while (indexes.Any(x => !x.HasValue))
        {
            var move = moves[steps % moves.Length];
            curNodes = curNodes.Select(x => nodes[x].ElementAt(move == 'L' ? 0 : 1)).ToList();
            steps++;

            for (var i = 0; i < curNodes.Count; i++)
            {
                if (curNodes[i].Last() == 'Z' && !indexes[i].HasValue)
                {
                    indexes[i] = steps;
                }
            }
        }
        
        return LCM(indexes.Select(x => x!.Value).ToArray());
    }

    private static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);

    private static long LCM(long a, long b) => a / GCD(a, b) * b;

    private static long LCM(IEnumerable<long> values) => values.Aggregate(LCM);
}