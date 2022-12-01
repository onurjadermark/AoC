namespace Solutions.Solutions._2021;

public class Day08
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static int Solve(string[] input, int part)
    {
        var result = 0;
        foreach (var line in input)
        {
            var parts = line.Split("|")
                .Select(x => x.Trim().Split(" ").Select(y => new string(y.OrderBy(z => z).ToArray())).ToList())
                .ToArray();
            var numbers = parts[0];
            var output = parts[1];

            var fiveSegmented = numbers.Where(x => x.Length == 5).ToList(); // 2, 3, 5
            var sixSegmented = numbers.Where(x => x.Length == 6).ToList(); // 0, 6, 9
            var one = numbers.Single(x => x.Length == 2);
            var four = numbers.Single(x => x.Length == 4);
            var seven = numbers.Single(x => x.Length == 3);
            var eight = numbers.Single(x => x.Length == 7);
            var three = fiveSegmented.Single(x => one.All(x.Contains));
            var eg = eight.Except(one).Except(four).Except(seven);
            var two = fiveSegmented.Single(x => eg.All(x.Contains));
            var five = fiveSegmented.Except(new[] {two, three}).Single();
            var six = sixSegmented.Single(x => !one.All(x.Contains));
            var zero = sixSegmented.Except(new[] {six}).Single(x => eg.All(x.Contains));
            var nine = sixSegmented.Except(new[] {zero, six}).Single();

            var translated = new List<string> {zero, one, two, three, four, five, six, seven, eight, nine};

            if (part == 1)
            {
                var easyNumbers = new[] {one, four, seven, eight};
                result += output.Count(x => easyNumbers.Contains(x));
            }
            else
            {
                result += output.Select(x => translated.FindIndex(y => x == y)).Aggregate((agg, cur) => agg * 10 + cur);
            }
        }

        return result;
    }
}