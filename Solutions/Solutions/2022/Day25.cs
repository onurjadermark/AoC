using System.Numerics;
using System.Text;

namespace Solutions.Solutions._2022;

public class Day25
{
    public string Part1(string[] input)
    {
        double result = 0;

        foreach (var line in input)
        {
            double num = 0;
            double x = 1;
            foreach (var ch in line.Reverse())
            {
                num += GetNum(ch) * x;
                x *= 5;
            }

            result += num;
        }

        var pows = Enumerable.Range(0, 30).OrderByDescending(x => x).Select(x => Math.Pow(5, x));
        double cur = 0;
        var sb = new StringBuilder();
        foreach (var pow in pows)
        {
            var closest = double.MaxValue;
            var chosen = (int?) null;
            for (var i = -2; i <= 2; i++)
            {
                var test = i * pow + cur;
                if (Math.Abs(test - result) >= closest) continue;
                closest = Math.Abs(test - result);
                chosen = i;
            }

            cur += chosen!.Value * pow;
            sb.Append(GetChar(chosen.Value));
        }

        return sb.ToString().TrimStart('0');
    }

    private static int GetNum(char ch)
    {
        if (ch == '2') return 2;
        if (ch == '1') return 1;
        if (ch == '0') return 0;
        if (ch == '-') return -1;
        if (ch == '=') return -2;
        throw new Exception();
    }

    private string GetChar(int i)
    {
        if (i == 2) return "2";
        if (i == 1) return "1";
        if (i == 0) return "0";
        if (i == -1) return "-";
        if (i == -2) return "=";
        throw new Exception();
    }
}