namespace Solutions.Solutions._2020;

public class Day17
{
    public long Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static long Solve(string[] input, int part)
    {
        var size = input.Length;
        var actives = new HashSet<(int X, int Y, int Z, int T)>();
        var newActives = new HashSet<(int X, int Y, int Z, int T)>();

        for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            if (input[j].Trim().ElementAt(i) == '#')
            {
                actives.Add((i, j, 0, 0));
                newActives.Add((i, j, 0, 0));
            }

        var a = 0;
        while (true)
        {
            var minX = actives.Min(x => x.X);
            var minY = actives.Min(x => x.Y);
            var minZ = actives.Min(x => x.Z);
            var minT = actives.Min(x => x.T);
            var maxX = actives.Max(x => x.X);
            var maxY = actives.Max(x => x.Y);
            var maxZ = actives.Max(x => x.Z);
            var maxT = actives.Max(x => x.T);
            for (var i = minX - 1; i <= maxX + 1; i++)
            for (var j = minY - 1; j <= maxY + 1; j++)
            for (var k = minZ - 1; k <= maxZ + 1; k++)
            for (var q = minT - 1; q <= maxT + 1; q++)
            {
                var countActive = 0;
                for (var l = -1; l < 2; l++)
                for (var m = -1; m < 2; m++)
                for (var n = -1; n < 2; n++)
                for (var o = part == 1 ? 0 : -1; o < (part == 1 ? 1 : 2); o++)
                {
                    if (l == 0 && m == 0 && n == 0 && o == 0) continue;

                    if (actives.Contains((i + l, j + m, k + n, q + o))) countActive++;
                }

                if (actives.Contains((i, j, k, q)))
                {
                    if (!(countActive == 2 || countActive == 3)) newActives.Remove((i, j, k, q));
                }
                else
                {
                    if (countActive == 3) newActives.Add((i, j, k, q));
                }
            }

            actives.Clear();
            foreach (var cur in newActives)
                if ((part == 1 && cur.T == 0) || part == 2)
                    actives.Add(cur);

            if (a == 5) return actives.Count;

            a++;
        }
    }
}