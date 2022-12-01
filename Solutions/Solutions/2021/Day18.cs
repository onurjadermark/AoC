using System.Text.RegularExpressions;

namespace Solutions.Solutions._2021;

public class Day18
{
    public long Part1(string[] input)
    {
        var cur = input[0];
        for (var i = 1; i < input.Length; i++) cur = Sum(cur, input[i]);

        return Reduce(cur);
    }

    public long Part2(string[] input)
    {
        var maxSum = int.MinValue;
        for (var i = 0; i < input.Length; i++)
            maxSum = input.Where((_, j) => i != j).Select(x => Reduce(Sum(input[i], x))).Append(maxSum).Max();

        return maxSum;
    }

    private static string Sum(string first, string second)
    {
        var str = $"[{first},{second}]";
        var hasExploded = true;
        var hasSplit = true;
        while (hasExploded || hasSplit)
        {
            hasExploded = false;
            hasSplit = false;
            str = Explode(str, ref hasExploded);
            if (hasExploded) continue;
            str = Split(str, ref hasSplit);
        }

        return str;
    }

    private static string Explode(string cur, ref bool hasExploded)
    {
        const string groupPattern = @"\[\d+,\d+\]";
        var groupRegex = new Regex(groupPattern);
        const string numberPattern = @"\d+";
        var numberRegex = new Regex(numberPattern);

        var level = 0;
        for (var j = 0; j < cur.Length; j++)
        {
            level = cur[j] == '[' ? level + 1 : cur[j] == ']' ? level - 1 : level;
            if (level != 5) continue;

            hasExploded = true;
            var groupMatch = groupRegex.Match(cur, j, cur.Length - j);
            var numbers = cur.Substring(groupMatch.Index + 1, groupMatch.Value.Length - 2).Split(",").Select(int.Parse)
                .ToList();
            cur = cur.Remove(groupMatch.Index, groupMatch.Value.Length).Insert(groupMatch.Index, "0");

            var nextNumberMatch = numberRegex.Match(cur, j + 1, cur.Length - j - 1);
            if (nextNumberMatch.Success)
                cur = cur.Remove(nextNumberMatch.Index, nextNumberMatch.Value.Length)
                    .Insert(nextNumberMatch.Index, (int.Parse(nextNumberMatch.Value) + numbers[1]).ToString());
            var prevNumberMatch =
                Regex.Match(cur.Substring(0, groupMatch.Index), numberPattern, RegexOptions.RightToLeft);

            if (prevNumberMatch.Success)
                cur = cur.Remove(prevNumberMatch.Index, prevNumberMatch.Value.Length)
                    .Insert(prevNumberMatch.Index, (int.Parse(prevNumberMatch.Value) + numbers[0]).ToString());
            break;
        }

        return cur;
    }

    private static string Split(string cur, ref bool hasSplit)
    {
        const string severalDigitNumberPattern = @"\d\d+";
        var severalDigitNumberRegex = new Regex(severalDigitNumberPattern);

        var match = severalDigitNumberRegex.Match(cur);
        if (!match.Success) return cur;

        hasSplit = true;
        var number = int.Parse(cur.Substring(match.Index, match.Value.Length));
        cur = cur.Remove(match.Index, match.Value.Length)
            .Insert(match.Index, $"[{number / 2},{number / 2 + number % 2}]");
        return cur;
    }

    private static int Reduce(string cur)
    {
        while (!char.IsNumber(cur[0]))
        {
            var groupPattern = @"\[\d+,\d+\]";
            var groupRegex = new Regex(groupPattern);
            var match = groupRegex.Match(cur);
            var index = match.Index;
            var value = match.Value;
            var split = value.Replace("[", "").Replace("]", "").Split(",").Select(int.Parse).ToList();
            var first = split[0];
            var second = split[1];
            cur = cur.Remove(index, value.Length).Insert(index, (3 * first + 2 * second).ToString());
        }

        return int.Parse(cur);
    }
}