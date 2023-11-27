using Newtonsoft.Json.Linq;

namespace Solutions.Solutions._2022;

public class Day13
{
    public int Part1(string[] input)
    {
        var result = 0;
        var index = 1;

        for (var i = 0; i < input.Length; i += 3)
        {
            var first = input[i];
            var second = input[i + 1];
            if (new Packet(JToken.Parse(first)).CompareTo(new Packet(JToken.Parse(second))) < 0)
            {
                result += index;
            }

            index++;
        }

        return result;
    }

    public int Part2(string[] input)
    {
        var dividerPackets = new[] {"[[2]]", "[[6]]"}.Select(JToken.Parse).ToList();
        var packets = input.Where(x => !string.IsNullOrEmpty(x)).Select(JToken.Parse).Concat(dividerPackets)
            .Select(x => new Packet(x)).ToList();

        packets.Sort();

        return packets.Where(x => dividerPackets.Contains(x.Token)).Select(x => packets.IndexOf(x) + 1)
            .Aggregate((x, y) => x * y);
    }

    private class Packet : IComparable<Packet>
    {
        public Packet(JToken token)
        {
            Token = token;
        }

        public JToken Token { get; }

        public int CompareTo(Packet? other)
        {
            var first = Token;
            var second = other!.Token;

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
                var comparison = new Packet(curFirst!).CompareTo(new Packet(curSecond!));
                if (comparison == 0) continue;
                return comparison;
            }

            return 0;
        }
    }
}