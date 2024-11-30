namespace Solutions.Solutions._2020;

public class Day01
{
    public int Part1(string[] input)
    {
        var numbers = input.Select(int.Parse).ToList();
        var value = numbers.First(x => numbers.Any(y => y + x == 2020));
        var result = value * (2020 - value);
        return result;
    }

    public int Part2(string[] input)
    {
        var numbers = input.Select(int.Parse).ToList();
        var value = numbers.First(x => numbers.Any(y => numbers.Any(z => z + y + x == 2020)));
        var secondValue = numbers.First(x => numbers.Any(y => x + y == 2020 - value));
        return value * (2020 - value - secondValue) * secondValue;
    }
}