namespace Solutions.Solutions._2024;

public class Day13
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
        var result = 0L;
        
        for (var i = 0; i < input.Length; i += 4)
        {
            var buttonA = (X: long.Parse(input[i].Split("X+")[1].Split(",")[0]), Y: long.Parse(input[i].Split("Y+")[1]));
            var buttonB = (X: long.Parse(input[i + 1].Split("X+")[1].Split(",")[0]), Y: long.Parse(input[i + 1].Split("Y+")[1]));
            var prize = (X: long.Parse(input[i + 2].Split("X=")[1].Split(",")[0]), Y: long.Parse(input[i + 2].Split("Y=")[1]));

            if (part == 2) prize = (prize.X + 10000000000000, prize.Y + 10000000000000);
            
            var determinant = (double) buttonA.X * buttonB.Y - buttonA.Y * buttonB.X;
            var countA = (prize.X * buttonB.Y - prize.Y * buttonB.X) / determinant;
            var countB = (buttonA.X * prize.Y - buttonA.Y * prize.X) / determinant;
            
            if (Math.Abs(countA % 1) > 0.0000001 || Math.Abs(countB % 1) > 0.0000001) continue;
            
            result += (long) countA * 3 + (long) countB;
        }
        
        return result;
    }
}
