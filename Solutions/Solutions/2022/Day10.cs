using System.Text;

namespace Solutions.Solutions._2022;

public class Day10
{
    public int Part1(string[] input)
    {
        var values = GetValues(input);
        var times = new int[] {20, 60, 100, 140, 180, 220};
        var result = 0;
        foreach (var time in times)
        {
            result += time * values[time];
        }
        return result;
    }

    public string Part2(string[] input)
    {
        var values = GetValues(input);
        var strings = new List<string>();
        for (var i = 0; i < 6; i++)
        {
            var sb = new StringBuilder();
            for (var j = 0; j < 40; j++)
            {
                sb.Append(Math.Abs(values[i*40+j + 1] - j) <= 1 ? "#" : ".");
            }
            strings.Add(sb.ToString());
        }

        return string.Join(Environment.NewLine, strings);
    }

    private static int[] GetValues(string[] input)
    {
        var curTime = 0;
        var values = new int[300];
        for (var i = 0; i < values.Length; i++)
        {
            values[i] = 1;
        }
        foreach (var line in input)
        {
            curTime++;
            if (!line.StartsWith("addx")) continue;
            curTime++;
            for (var i = curTime + 1; i < 300; i++)
            {
                values[i] += int.Parse(line.Split(" ")[1]);
            }
        }

        return values;
    }
}