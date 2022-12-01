namespace Solutions.Solutions._2018;

public class Day02
{
    public int Part1(string[] input)
    {
        var chars = "qwertyuiopasdfghjklzxcvbnm";
        var exactlyTwice = input.Count(x => chars.Any(y => x.Count(z => z == y) == 2));
        var exactlyThrice = input.Count(x => chars.Any(y => x.Count(z => z == y) == 3));
        return exactlyThrice * exactlyTwice;
    }

    public string Part2(string[] input)
    {
        var sorted = input.ToList();
        sorted.Sort();
        for (var i = 0; i < sorted.Count - 1; i++)
            if (DiffersByOne(sorted[i], sorted[i + 1]))
                return string.Join("", sorted[i].Where((x, j) => sorted[i + 1].ElementAt(j) == x));

        return "";
    }

    private bool DiffersByOne(string first, string second)
    {
        var count = 0;
        for (var i = 0; i < first.Length; i++)
            if (first[i] != second[i])
                count++;

        return count == 1;
    }
}