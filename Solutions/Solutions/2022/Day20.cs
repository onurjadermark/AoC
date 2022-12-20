namespace Solutions.Solutions._2022;

public class Day20
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string[] input, int part)
    {
        var numbers = input.Select(int.Parse).Select((x, i) => (Id: i, Value: part == 2 ? (long) x * 811589153 : x)).ToList();
        var mixOrder = numbers.ToList();
        var count = input.Length;
        for (var i = 0; i < (part == 2 ? 10 : 1); i++)
        {
            foreach (var number in mixOrder)
            {
                var oldIndex = numbers.IndexOf(number);
                var newIndex = (int) ((oldIndex + number.Value) % (count - 1));
                if (newIndex < 0) newIndex += (count - 1);
                numbers.RemoveAt(oldIndex);
                numbers.Insert(newIndex, number);
            }
        }

        var zeroIndex = numbers.IndexOf(numbers.Single(x => x.Value == 0));
        return numbers[(zeroIndex + 1000) % count].Value + numbers[(zeroIndex + 2000) % count].Value + numbers[(zeroIndex + 3000) % count].Value;
    }
}