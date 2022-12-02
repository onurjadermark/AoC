namespace Solutions.Solutions._2022;

public class Day02
{
    public int Part1(string[] input)
    {
        var score = 0;
        foreach (var line in input)
        {
            var opponent = (Move) ExtractToken(line, 0);
            var me = (Move) ExtractToken(line, 1);
            var result = GetResult(opponent, me);
            score += GetScore(result, me);
        }

        return score;
    }

    public int Part2(string[] input)
    {
        var score = 0;
        foreach (var line in input)
        {
            var opponent = (Move) ExtractToken(line, 0);
            var result = (Result) ExtractToken(line, 1);
            var me = GetMyMove(result, opponent);
            score += GetScore(result, me);
        }

        return score;
    }

    private static Move GetMyMove(Result result, Move opponent)
    {
        return result switch
        {
            Result.Win => (Move) (((int) opponent + 1) % 3),
            Result.Draw => opponent,
            Result.Lose => (Move) (((int) opponent + 2) % 3),
            _ => throw new NotImplementedException()
        };
    }

    private static Result GetResult(Move opponent, Move me)
    {
        if (((int) opponent + 1) % 3 == (int) me)
        {
            return Result.Win;
        }

        return opponent == me ? Result.Draw : Result.Lose;
    }

    private static int GetScore(Result result, Move me) => (int) me + 1 + (int) result * 3;

    private static int ExtractToken(string line, int part) => line.Split(" ")[part][0] - (part == 0 ? 'A' : 'X');

    private enum Move
    {
        Rock = 0,
        Paper = 1,
        Scissor = 2
    }

    private enum Result
    {
        Lose = 0,
        Draw = 1,
        Win = 2
    }
}