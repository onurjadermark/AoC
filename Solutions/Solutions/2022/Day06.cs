namespace Solutions.Solutions._2022;

public class Day06
{
    public int Part1(string[] input)
    {
        return Solve(input, 4);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 14);
    }

    private static int Solve(string[] input, int length)
    {
        var cur = "";
        foreach (var ch in input[0])
        {
            cur += ch;
            if (cur.Length > length)
            {
                cur = cur.Substring(1);
            }

            if (cur.Length == length && cur.Distinct().Count() == length)
            {
                return input[0].IndexOf(cur, StringComparison.Ordinal) + length;
            }
        }

        return 0;
    }
}