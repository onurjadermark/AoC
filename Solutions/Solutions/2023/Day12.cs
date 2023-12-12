namespace Solutions.Solutions._2023;

public class Day12
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private long Solve(string[] input, long part)
    {
        var sum = 0L;

        var dict = new Dictionary<string, long>();
        foreach (var line in input)
        {
            var parts = line.Split(' ');
            var str = parts[0];
            var groups = parts[1].Split(',').Select(int.Parse).ToList();
            if (part == 2)
            {
                str = string.Join("?", Enumerable.Repeat(str, 5));
                groups = Enumerable.Repeat(groups, 5).SelectMany(item => item).ToList();
            }

            var count = Solve(str, groups, 0, dict);
            sum += count;
        }

        return sum;
    }

    private long Solve(string str, List<int> groups, int index, Dictionary<string, long> dict)
    {
        if (dict.TryGetValue(GetKey(str, groups), out var val))
        {
            return val;
        }

        var split = str.Split('.', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Length).ToList();
        var next = str.IndexOf('?');

        if (next == -1)
        {
            var result = groups.SequenceEqual(split) ? 1 : 0;
            dict[GetKey(str, groups)] = result;
            return result;
        }

        if (next > index)
        {
            var result = Solve(str, groups, next, dict);
            dict[GetKey(str, groups)] = result;
            return result;
        }

        var donePart = new string(str.TakeWhile(x => x != '?').ToArray());
        split = donePart.Split('.', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Length).ToList();
        var valid = true;
        if (split.Count > groups.Count)
        {
            dict[GetKey(str, groups)] = 0;
            return 0;
        }

        var mustContinue = false;
        for (var i = 0; i < split.Count; i++)
        {
            if (split[i] != groups[i])
            {
                if (i == split.Count - 1)
                {
                    valid = split[i] < groups[i] && str[index] != '.';
                    mustContinue = true;
                    break;
                }

                valid = false;
                break;
            }
        }

        if (!valid)
        {
            dict[GetKey(str, groups)] = 0;
            return 0;
        }

        if (split.Count > 1)
        {
            var indexOf = str.IndexOf('#');
            str = new string(str.Skip(indexOf).ToArray());
            var count = str.IndexOf('.');
            str = new string(str.Skip(count).ToArray());
            groups = groups.Skip(1).ToList();
            index -= indexOf + count;
        }

        var remainingPart = new string(str.SkipWhile(x => x != '?').ToArray());
        var remainingGroups = groups.TakeLast(groups.Count - split.Count - 1).ToList();
        var remainingMinimumLength = remainingGroups.Sum() + remainingGroups.Count();
        if (remainingPart.Length < remainingMinimumLength)
        {
            dict[GetKey(str, groups)] = 0;
            return 0;
        }

        if (mustContinue)
        {
            var arr2 = str.ToCharArray();
            arr2[index] = '#';
            var result = Solve(new string(arr2), groups, index + 1, dict);
            dict[GetKey(str, groups)] = result;
            return result;
        }

        var arr = str.ToCharArray();
        arr[index] = '#';
        var result1 = Solve(new string(arr), groups, index + 1, dict);
        arr[index] = '.';
        var result2 = Solve(new string(arr), groups, index + 1, dict);
        var result3 = result1 + result2;
        dict[GetKey(str, groups)] = result3;
        return result3;
    }

    private static string GetKey(string str, List<int> groups)
    {
        return str + "x" + string.Join("-", groups);
    }
}