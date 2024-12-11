namespace Solutions.Solutions._2024;

public class Day11
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(string[] input, int part)
    {
        var stones = input[0].Split(' ').Select(long.Parse).ToList();
        return stones.Sum(stone => Solve(stone, part == 1 ? 25 : 75, new Dictionary<(long, int), long>()));
    }

    private long Solve(long stone, int blinks, Dictionary<(long, int), long> dict)
    {
        if (dict.ContainsKey((stone, blinks))) return dict[(stone, blinks)];
        var stones = Blink(stone);
        return dict[(stone, blinks)] = blinks == 1 ? stones.Count : stones.Sum(x => Solve(x, blinks - 1, dict));
    }

    private static List<long> Blink(long stone)
    {
        var stones = new List<long>();
        var str = stone.ToString();
        var length = str.Length;
        if (stone == 0)
        {
            stones.Add(1);
        }
        else if (str.Length % 2 == 0)
        {
            stones.Add(long.Parse(str[..(length / 2)]));
            stones.Add(long.Parse(str[(length / 2)..]));
        }
        else
        {
            stones.Add(stone * 2024);
        }

        return stones;
    }
}