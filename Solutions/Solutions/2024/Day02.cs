namespace Solutions.Solutions._2024;

public class Day02
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
        var count = 0;
        foreach (var numbers in input.Select(x => x.Split().Select(int.Parse).ToArray()).ToArray())
        {
            var valid = IsValid(numbers);
            for (var j = 1; j < numbers.Length; j++)
            {
                if (valid || part == 1) break;
                valid = IsValid(RemoveElementAt(numbers, j));
            }

            if (valid) count++;
        }

        return count;
    }

    private static int[] RemoveElementAt(int[] numbers, int index)
    {
        return numbers.Where((_, k) => k != index).ToArray();
    }

    private static bool IsValid(int[] numbers)
    {
        var diffs = numbers.Zip(numbers.Skip(1), (x, y) => y - x).ToArray();
        if (diffs.Any(x => Math.Abs(x) > 3 || x == 0)) return false;
        return diffs.All(x => x > 0) || diffs.All(x => x < 0);
    }
}