namespace Solutions.Utils;

public static class Utilities
{
    public static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);

    public static long LCM(long a, long b) => a / GCD(a, b) * b;

    public static long LCM(IEnumerable<long> values) => values.Aggregate(LCM);

    public static long LCM(IEnumerable<int> values) => LCM(values.Select(x => (long) x));
}