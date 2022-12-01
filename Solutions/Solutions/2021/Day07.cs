namespace Solutions.Solutions._2021;

public class Day07
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private int Solve(string[] input, int part)
    {
        var crabs = input.Single().Split(",").Select(int.Parse).ToList();

        var minCost = int.MaxValue;
        var minPos = crabs.Min();
        var maxPos = crabs.Max();
        for (var i = minPos; i < maxPos; i++)
        {
            var fuelCost = crabs.Select(x => CalculateFuel(part, i, x)).Sum();
            minCost = fuelCost < minCost ? fuelCost : minCost;
        }

        return minCost;
    }

    private static int CalculateFuel(int part, int a, int b)
    {
        var diff = Math.Abs(a - b);
        return part == 1 ? diff : (diff + 1) * diff / 2;
    }
}