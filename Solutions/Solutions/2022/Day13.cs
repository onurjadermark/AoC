using Newtonsoft.Json.Linq;

namespace Solutions.Solutions._2022;

public class Day13
{
    public int Part1(string[] input)
    {
        var result = 0;
        var index = 1;
        
        for (var i = 0; i < input.Length; i+=3)
        {
            var first = input[i];
            var second = input[i + 1];
            if (Compare(JToken.Parse(first), JToken.Parse(second)) < 0) result += index;
            index++;
        }
        
        return result;
    }

    public int Part2(string[] input)
    {
        var dividerPackets = new[] {"[[2]]", "[[6]]"}.Select(JToken.Parse).ToList();
        var packets = input.Where(x => !string.IsNullOrEmpty(x)).Select(JToken.Parse).Concat(dividerPackets).ToList();

        for (var i = 0; i < packets.Count; i++)
        {
            for (var j = i + 1; j < packets.Count; j++)
            {
                if (Compare(packets[i], packets[j]) > 0)
                {
                    (packets[j], packets[i]) = (packets[i], packets[j]);
                }
            }
        }

        return dividerPackets.Select(x => packets.IndexOf(x) + 1).Aggregate((x, y) => x * y);
    }

    private static int Compare(JToken first, JToken second)
    {
        if (first is JValue && second is JValue)
        {
            return first.Value<int>().CompareTo(second.Value<int>());
        }
        
        if (first is not JArray)
        {
            first = JToken.Parse($"[{first}]");
        }

        if (second is not JArray)
        {
            second = JToken.Parse($"[{second}]");
        }

        for (var i = 0; i < Math.Max(first.Count(), second.Count()); i++)
        {
            if (first.Count() == i) return -1;
            var curFirst = first[i];
            if (second.Count() == i) return 1;
            var curSecond = second[i];
            var comparison = Compare(curFirst, curSecond);
            if (comparison == 0) continue;
            return comparison;
        }

        return 0;
    }
}