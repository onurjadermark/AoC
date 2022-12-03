namespace Solutions.Solutions._2022;

public class Day03
{
    public int Part1(string[] input)
    {
        var total = 0;
        foreach (var line in input)
        {
            var first = line.Skip(line.Length / 2);
            var second = line.Take(line.Length / 2);
            var common = first.First(x => second.Contains(x));
            total += GetValue(common);
        }

        return total;
    }

    public int Part2(string[] input)
    {
        var total = 0;
        var group = new List<string>();
        foreach (var t in input)
        {
            group.Add(t);
            if (group.Count != 3) continue;
            var common = group[0].First(x => group[1].Contains(x) && group[2].Contains(x));
            total += GetValue(common);
            group.Clear();
        }

        return total;
    }

    private static int GetValue(char letter)
    {
        var result = letter - 'a' + 1;
        return result <= 0 ? letter - 'A' + 27 : result;
    }
}