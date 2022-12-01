namespace Solutions.Solutions._2020;

public class Day13
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
        var earliest = part == 1 ? int.Parse(input[0]) : 0;
        var busIds = input[1].Split(',').Select(x => int.TryParse(x, out var _) ? int.Parse(x) : long.MaxValue)
            .ToList();

        if (part == 1)
        {
            var cur = earliest;
            while (true)
            {
                foreach (var curBusId in busIds)
                    if (cur % curBusId == 0)
                        return (cur - earliest) * curBusId;

                cur++;
            }
        }

        var ids = busIds.Where(x => x < 100000000).ToArray();
        var plus = new long[ids.Length];
        for (var i = 0; i < plus.Length; i++)
        {
            var index = busIds.IndexOf(ids[i]);
            plus[i] = i == 0 ? 0 : busIds[index] - index;
        }

        return ChineseRemainderTheorem.Solve(ids, plus);
    }

    private static class ChineseRemainderTheorem
    {
        public static long Solve(long[] n, long[] a)
        {
            var prod = n.Aggregate(1, (long i, long j) => i * j);
            long p;
            long sm = 0;
            for (var i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }

            return sm % prod;
        }

        private static long ModularMultiplicativeInverse(long a, long mod)
        {
            var b = a % mod;
            for (long x = 1; x < mod; x++)
                if (b * x % mod == 1)
                    return x;
            return 1;
        }
    }
}