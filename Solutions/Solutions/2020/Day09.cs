namespace Solutions.Solutions._2020;

public class Day09
{
    public long Part1(string[] input)
    {
        var numbers = input.Select(long.Parse).ToList();
        var preambleLength = input.Length == 20 ? 5 : 25;

        var preamble = numbers.Take(preambleLength).ToList();
        for (var i = preambleLength; i < numbers.Count(); i++)
        {
            var current = numbers[i];
            var valid = false;
            for (var j = 0; j < preamble.Count; j++)
            for (var k = 0; k < preamble.Count; k++)
                if (preamble[j] + preamble[k] == current)
                    valid = true;

            if (!valid) return current;
            preamble.Add(current);
            preamble.Remove(preamble.First());
        }

        return -1;
    }

    public long Part2(string[] input)
    {
        var target = Part1(input);
        var numbers = input.Select(long.Parse).ToList();

        var partialSums = CalculatePartialSums(numbers);

        for (var i = 0; i < numbers.Count; i++)
        for (var j = i; j < numbers.Count; j++)
        {
            var sum = GetPartialSum(partialSums, i, j);

            if (sum == target)
            {
                var smallest = long.MaxValue;
                var largest = long.MinValue;
                for (var k = i; k <= j; k++)
                {
                    if (numbers[k] < smallest) smallest = numbers[k];

                    if (numbers[k] > largest) largest = numbers[k];
                }

                return smallest + largest;
            }
        }

        return -1;
    }

    private long GetPartialSum(List<long> partialSums, int i, int j)
    {
        if (i == 0) return partialSums[j];

        return partialSums[j] - partialSums[i - 1];
    }

    private List<long> CalculatePartialSums(List<long> numbers)
    {
        var result = new List<long> {numbers[0]};

        for (var i = 1; i < numbers.Count; i++) result.Add(result[i - 1] + numbers[i]);

        return result;
    }
}