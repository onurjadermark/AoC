namespace Solutions.Solutions._2023;

public class Day05
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
        var seeds = input[0].Split(" ").Skip(1).Select(long.Parse).ToArray();
        var values = part == 1
            ? seeds.Select(x => (Start: x, Length: 1L)).ToList()
            : Enumerable.Range(0, seeds.Length / 2).Select(x => (Start: seeds[2 * x], Length: seeds[2 * x + 1])).ToList();
        
        var curIndex = 2;
        while (true)
        {
            var nextIndex = Array.IndexOf(input, input.Skip(curIndex + 1).FirstOrDefault(x => x.Contains("map")));
            var mapRows = input.Skip(curIndex + 1).Take(nextIndex == -1 ? input.Length : nextIndex - curIndex - 2);
            var map = mapRows.Select(x => x.Split(" ").Select(long.Parse).ToArray()).OrderBy(x => x[1]).ToArray();
            values = Transform(values, map);
            curIndex = nextIndex;
            if (nextIndex == -1) break;
        }

        return values.MinBy(x => x.Start).Start;
    }

    private static List<(long Start, long Length)> Transform(List<(long Start, long Length)> values, long[][] mapRows)
    {
        var result = new List<(long Start, long Length)>();

        foreach (var value in values)
        {
            var cur = value.Start;
            var length = value.Length;
            while (length > 0)
            {
                var map = mapRows.SingleOrDefault(x => x[1] <= cur && cur < x[1] + x[2]);
                long next;
                long lengthToTake;
                
                if (map == null)
                {
                    var nextMap = mapRows.FirstOrDefault(x => x[1] >= cur);
                    next = cur;
                    lengthToTake = nextMap == null ? length : Math.Min(length, nextMap[1] - cur);
                }
                else
                {
                    next = map[0] + cur - map[1];
                    lengthToTake = Math.Min(length, map[1] + map[2] - cur);
                }
                
                result.Add((next, lengthToTake));
                length -= lengthToTake;
                cur += lengthToTake;
            }
        }

        return result.ToList();
    }
}