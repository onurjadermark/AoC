namespace Solutions.Solutions._2020;

public class Day15
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(IReadOnlyList<string> input, int part)
    {
        var size = part == 1 ? 2020 : 30000000;
        var numbers = input[0].Split(',').Select(int.Parse).ToList();
        var indexes = new int[size + 1];
        for (var i = 0; i < indexes.Length; i++) indexes[i] = -1;

        for (var i = 0; i < numbers.Count; i++)
        {
            var number = numbers[i];
            indexes[number] = i;
        }

        var count = numbers.Count;
        var lastNumber = numbers.Last();
        var prevIndex = Enumerable.SkipLast(numbers, 1).ToList().LastIndexOf(lastNumber);
        while (true)
        {
            var num = 0;
            if (prevIndex == -1)
                num = 0;
            else
                num = count - prevIndex - 1;
            prevIndex = indexes[num];
            indexes[num] = count;

            count++;
            if (count == size) return num;
        }
    }
}