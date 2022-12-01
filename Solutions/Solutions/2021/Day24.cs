namespace Solutions.Solutions._2021;

public class Day24
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
        var nums1 = new List<int>();
        var nums2 = new List<int>();
        var nums3 = new List<int>();
        for (var i = 0; i < input.Length; i++)
        {
            if (i % 18 == 4) nums1.Add(int.Parse(input[i].Split()[2]));
            if (i % 18 == 5) nums2.Add(int.Parse(input[i].Split()[2]));
            if (i % 18 == 15) nums3.Add(int.Parse(input[i].Split()[2]));
        }

        var newToCheck = new Dictionary<string, int> {[""] = 0};
        for (var i = 0; i < nums1.Count; i++)
        {
            var toCheck = newToCheck.OrderBy(x => x.Value).ToList();
            newToCheck.Clear();
            toCheck = Prune(toCheck);
            foreach (var (str, z) in toCheck)
                for (var w = 1; w < 10; w++)
                    newToCheck[str + w] = w == nums2[i] + z % 26 ? z / nums1[i] : z / nums1[i] * 26 + w + nums3[i];
        }

        var result = newToCheck.Where(x => x.Value == 0);
        return long.Parse(part == 1 ? result.Max(x => x.Key)! : result.Min(x => x.Key)!);
    }

    private static List<KeyValuePair<string, int>> Prune(List<KeyValuePair<string, int>> list)
    {
        int? prevValue = null;
        foreach (var cur in list)
        {
            var (_, value) = cur;
            if (prevValue != null && value > prevValue * 10) return list.Where(x => x.Value < value).ToList();

            prevValue = value;
        }

        return list;
    }
}