namespace Solutions.Solutions._2024;

public class Day07
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
        var equations = input.Select(x => x.Split(": ")).Select(x => (Result: long.Parse(x[0]), Operands: x[1].Split(" ").Select(long.Parse).ToArray()));
        
        return equations.Where(x => IsValid(x.Result, x.Operands, 0, part)).Sum(x => x.Result);
    }

    private static bool IsValid(long result, long[] operands, long cur, int part)
    {
        if (!operands.Any())
        {
            return cur == result;
        }
        
        var next = operands[0];
        operands = operands.Skip(1).ToArray();

        return IsValid(result, operands, cur + next, part) || 
               cur != 0 && IsValid(result, operands, cur * next, part) ||
               (cur != 0 && part == 2 && IsValid(result, operands, long.Parse($"{cur}{next}"), part));
    }
}