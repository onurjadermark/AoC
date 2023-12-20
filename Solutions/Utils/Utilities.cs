namespace Solutions.Utils;

public static class Utilities
{
    public static Direction GetDirection(int x, int y)
    {
        return x switch
        {
            0 when y == -1 => Direction.N,
            1 when y == 0 => Direction.E,
            0 when y == 1 => Direction.S,
            -1 when y == 0 => Direction.W,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static Direction Flip(this Direction direction)
    {
        return (Direction) (((int) direction + 2) % 4);
    }

    public static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);

    public static long LCM(long a, long b) => a / GCD(a, b) * b;

    public static long LCM(IEnumerable<long> values) => values.Aggregate(LCM);

    public static long LCM(IEnumerable<int> values) => LCM(values.Select(x => (long) x));
}