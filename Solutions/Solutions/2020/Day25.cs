namespace Solutions.Solutions._2020;

public class Day25
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
        var a = long.Parse(input[0]);
        var b = long.Parse(input[1]);

        var x = GetLoopSize(a);
        var y = GetLoopSize(b);

        return part == 1 ? GetKey(a, y) : GetKey(b, x);
    }

    private static long GetKey(long sn, long loopSize)
    {
        var result = 1L;
        for (var i = 0; i < loopSize; i++)
        {
            result *= sn;
            result %= 20201227;
        }

        return result;
    }

    private static long GetLoopSize(long num)
    {
        long x = 1;
        var loopSize = 0;
        while (x != num)
        {
            x *= 7;
            x %= 20201227;
            loopSize++;
        }

        return loopSize;
    }
}