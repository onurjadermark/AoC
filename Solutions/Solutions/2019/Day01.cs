namespace Solutions.Solutions._2019;

public class Day01
{
    public int Part1(string[] input)
    {
        return input.Select(int.Parse).Sum(x => GetFuel(x, false));
    }

    public int Part2(string[] input)
    {
        return input.Select(int.Parse).Sum(x => GetFuel(x, true));
    }

    private static int GetFuel(int x, bool calculateFuelForFuel)
    {
        return x <= 0 ? 0 : Math.Max(x / 3 - 2 + (calculateFuelForFuel ? GetFuel(x / 3 - 2, true) : 0), 0);
    }
}