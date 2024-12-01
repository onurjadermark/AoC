namespace Solutions.Solutions._2024;

public class Day01
{
    public int Part1(string[] input)
    {
        var (numbers1, numbers2) = ParseInput(input);
        numbers1.Sort();
        numbers2.Sort();
        return numbers1.Zip(numbers2, (x, y) => Math.Abs(x - y)).Sum();
    }

    public int Part2(string[] input)
    {
        var (numbers1, numbers2) = ParseInput(input);
        return numbers1.Select(x => x * numbers2.Count(y => y == x)).Sum();
    }

    private static (List<int>, List<int>) ParseInput(string[] input)
    {
        var numbers1 = input.Select(x => int.Parse(x.Split()[0])).ToList();
        var numbers2 = input.Select(x => int.Parse(x.Split()[3])).ToList();
        return (numbers1, numbers2);
    }
}