namespace Solutions.Solutions._2022;

public class Day04
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
            var numbers = line.Split('-', ',').Select(int.Parse).ToList();
            if (part == 1)
            {
                if ((numbers[0] >= numbers[2] && numbers[1] <= numbers[3]) ||
                    (numbers[2] >= numbers[0] && numbers[3] <= numbers[1]))
                {
                    result++;
                }
            }
            else
            {
                if (numbers[1] >= numbers[2] && numbers[0] <= numbers[3])
                {
                    result++;
                }
            }
        }

        return result;
    }
}