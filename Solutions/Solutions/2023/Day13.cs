using Solutions.Utils;

namespace Solutions.Solutions._2023;

public class Day13
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static int Solve(string[] input, int part)
    {
        var grids = StringArrayUtils.SplitByNewline(input);
        var sum = grids.Sum(grid => SolveGrid(grid, part));
        return sum;
    }

    private static int SolveGrid(string[] grid, int part)
    {
        var sum = 0;
        sum += 100 * GetMirrorIndex(grid, part);
        grid = StringArrayUtils.RotateStringArray(grid);
        sum += GetMirrorIndex(grid, part);
        return sum;
    }

    private static int GetMirrorIndex(string[] grid, int part)
    {
        for (var mid = 0; mid < grid.Length - 1; mid++)
        {
            if (IsMirrorLocationValid(grid, mid, part == 1 ? 0 : 1))
            {
                return mid + 1;
            }
        }

        return 0;
    }

    private static bool IsMirrorLocationValid(string[] grid, int mid, int countSmudges)
    {
        for (var i = 1;; i++)
        {
            var firstIndex = mid - i + 1;
            var secondIndex = mid + i;

            if (firstIndex < 0 || secondIndex < 0 || firstIndex >= grid.Length || secondIndex >= grid.Length)
            {
                break;
            }

            var mismatchCount = grid[firstIndex].Zip(grid[secondIndex], (c1, c2) => c1 == c2 ? 0 : 1).Sum();

            if (mismatchCount > countSmudges)
            {
                return false;
            }

            countSmudges -= mismatchCount;
        }

        return countSmudges == 0;
    }
}