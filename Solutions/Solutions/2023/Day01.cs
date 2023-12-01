namespace Solutions.Solutions._2023;

public class Day01
{
    private static readonly string[] Digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

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
        var sum = 0;

        foreach (var line in input)
        {
            var digits = new List<int>();

            for (var i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    digits.Add(line[i] - '0');
                }

                if (part == 1) continue;

                var digit = Array.IndexOf(Digits, Digits.FirstOrDefault(x => line.Substring(i, Math.Min(x.Length, line.Length - i)) == x));
                if (digit != -1)
                {
                    digits.Add(digit);
                }
            }

            sum += digits.First() * 10 + digits.Last();
        }

        return sum;
    }
}