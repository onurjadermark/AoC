namespace Solutions.Solutions._2022;

public class Day02
{
    public int Part1(string[] input)
    {
        var score = 0;
        foreach (var line in input)
        {
            var roundScore = 0;
            var split = line.Split(" ");
            var opponent = split[0][0] - 'A';
            var me = split[1][0] - 'X';
            
            roundScore += me + 1;
            if ((opponent + 1) % 3 == me)
            {
                roundScore += 6;
            }
            else if (opponent == me)
            {
                roundScore += 3;
            }
            
            score += roundScore;
        }
        
        return score;
    }

    public int Part2(string[] input)
    {
        var score = 0;
        foreach (var line in input)
        {
            var roundScore = 0;
            var split = line.Split(" ");
            var opponent = split[0][0] - 'A';
            var result = split[1][0] - 'X';
            
            roundScore += result * 3;
            var me = result switch
            {
                2 => (opponent + 1) % 3,
                1 => opponent,
                _ => (opponent + 2) % 3
            };
            roundScore += me + 1;

            score += roundScore;
        }
        
        return score;
    }
}