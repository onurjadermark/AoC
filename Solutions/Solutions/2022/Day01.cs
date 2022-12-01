namespace Solutions.Solutions._2022;

public class Day01
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 3);
    }

    private static int Solve(string[] input, int take)
    {
        var lines = input.ToList();
        var calories = new List<int>();
        var curTotal = 0;
        foreach (var line in lines)
            if (string.IsNullOrWhiteSpace(line))
            {
                calories.Add(curTotal);
                curTotal = 0;
            }
            else
            {
                curTotal += int.Parse(line);
            }

        calories.Add(curTotal);

        return calories.OrderByDescending(x => x).Take(take).Sum();
    }
}