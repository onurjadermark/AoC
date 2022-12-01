namespace Solutions.Solutions._2021;

public class Day21
{
    public long Part1(string[] input)
    {
        var pos = Parse(input);

        var score = new[] {0, 0};

        var dice = 0;
        var toPlay = 0;
        var countThrown = 0;

        while (true)
        {
            for (var i = 0; i < 3; i++)
            {
                dice++;
                if (dice > 100) dice = 1;
                pos[toPlay] += dice;
                while (pos[toPlay] > 10) pos[toPlay] -= 10;
                countThrown++;
            }

            score[toPlay] += pos[toPlay];
            if (score[toPlay] >= 1000) return score[1 - toPlay] * countThrown;

            toPlay = 1 - toPlay;
        }
    }

    public long Part2(string[] input)
    {
        var pos = Parse(input);
        var memo =
            new Dictionary<(int score1, int score2, int pos1, int pos2, int toPlay, int timesThrown), (long X, long Y
                )>();
        var result = Play(pos, new[] {0, 0}, 0, 0, memo);
        return Math.Max(result.X, result.Y);
    }

    private (long X, long Y) Play(int[] pos, int[] score, int toPlay, int timesThrown,
        Dictionary<(int score1, int score2, int pos1, int pos2, int toPlay, int timesThrown), (long X, long Y)> memo)
    {
        if (memo.ContainsKey((score[0], score[1], pos[0], pos[1], toPlay, timesThrown)))
            return memo[(score[0], score[1], pos[0], pos[1], toPlay, timesThrown)];

        var (x1, y1) = Play(pos.ToArray(), score.ToArray(), toPlay, 1, timesThrown, memo);
        var (x2, y2) = Play(pos.ToArray(), score.ToArray(), toPlay, 2, timesThrown, memo);
        var (x3, y3) = Play(pos.ToArray(), score.ToArray(), toPlay, 3, timesThrown, memo);

        var result = (X: x1 + x2 + x3, Y: y1 + y2 + y3);
        memo[(score[0], score[1], pos[0], pos[1], toPlay, timesThrown)] = result;
        return result;
    }

    private (long X, long Y) Play(int[] pos, int[] score, int toPlay, int dice, int timesThrown,
        Dictionary<(int score1, int score2, int pos1, int pos2, int toPlay, int timesThrown), (long X, long Y)> memo)
    {
        pos[toPlay] += dice;
        while (pos[toPlay] > 10) pos[toPlay] -= 10;
        timesThrown++;
        if (timesThrown == 3)
        {
            timesThrown = 0;
            score[toPlay] += pos[toPlay];
            toPlay = 1 - toPlay;
        }

        if (score[0] < 21 && score[1] < 21) return Play(pos, score, toPlay, timesThrown, memo);

        return (toPlay, 1 - toPlay);
    }

    private static int[] Parse(string[] input)
    {
        var pos = new[]
        {
            int.Parse(input[0].Split()[^1]),
            int.Parse(input[1].Split()[^1])
        };
        return pos;
    }
}