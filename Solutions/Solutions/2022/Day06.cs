namespace Solutions.Solutions._2022;

public class Day06
{
    public int Part1(string[] input)
    {
        return Solve(input[0], 4);
    }

    public int Part2(string[] input)
    {
        return Solve(input[0], 14);
    }

    private static int Solve(string input, int length)
    {
        for (var i = 0; i < input.Length - length; i++)
        {
            if (input.Substring(i, length).Distinct().Count() == length)
            {
                return i + length;
            }
        }

        throw new Exception();
    }
}