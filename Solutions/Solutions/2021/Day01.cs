namespace Solutions.Solutions._2021;

public class Day01
{
    public int Part1(string[] input)
    {
        var numbers = input.Select(int.Parse).ToList();
        var count = 0;
        for (var i = 0; i < numbers.Count() - 1; i++)
            if (numbers[i + 1] > numbers[i])
                count++;

        return count;
    }

    public int Part2(string[] input)
    {
        var numbers = input.Select(int.Parse).ToList();
        var count = 0;
        var previousSum = 0;
        for (var i = 0; i < numbers.Count() - 3; i++)
        {
            var sum = 0;
            for (var j = 0; j < 3; j++)
                if (i - j >= 0)
                    sum += numbers[i - j];

            if (previousSum < sum) count++;

            previousSum = sum;
        }

        return count;
    }
}