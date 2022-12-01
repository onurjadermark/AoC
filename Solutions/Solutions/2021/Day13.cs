using System.Text;
using Solutions.Utils;

namespace Solutions.Solutions._2021;

public class Day13
{
    public static string Part2Answer = @"
#..#.#....###..#..#.###...##..####.###..
#..#.#....#..#.#..#.#..#.#..#.#....#..#.
####.#....###..#..#.###..#....###..#..#.
#..#.#....#..#.#..#.#..#.#.##.#....###..
#..#.#....#..#.#..#.#..#.#..#.#....#.#..
#..#.####.###...##..###...###.#....#..#.";

    public string Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public string Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private string Solve(string[] input, int part)
    {
        var dots = input.TakeWhile(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x.Split(",").Select(int.Parse).ToList())
            .Select(x => new Coordinate(x[0], x[1])).ToList();
        var folds = input.SkipWhile(x => !string.IsNullOrWhiteSpace(x)).Skip(1).Select(x => x.Split("="))
            .Select(x => (Direction: x[0].Last(), Index: int.Parse(x[1]))).ToList();

        var width = dots.Max(x => x.X);
        var height = dots.Max(x => x.Y);

        foreach (var (direction, index) in folds)
        {
            var isHorizontal = direction == 'x';
            width = isHorizontal ? width / 2 : width;
            height = !isHorizontal ? height / 2 : height;
            foreach (var dot in dots)
                switch (isHorizontal)
                {
                    case true when dot.X > index:
                        dot.X -= 2 * (dot.X - index);
                        break;
                    case false when dot.Y > index:
                        dot.Y -= 2 * (dot.Y - index);
                        break;
                }

            if (part == 1) return dots.GroupBy(x => (x.X, x.Y)).Count().ToString();
        }

        var sb = new StringBuilder();
        for (var j = 0; j < height; j++)
        {
            sb.Append(Environment.NewLine);
            for (var i = 0; i < width; i++) sb.Append(dots.Any(x => x.X == i && x.Y == j) ? "#" : ".");
        }

        return sb.ToString();
    }
}