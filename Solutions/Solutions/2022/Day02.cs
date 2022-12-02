namespace Solutions.Solutions._2022;

public class Day02
{
    private readonly Dictionary<int, int> _rockPaperScissors = new()
    {
        {0, 1},
        {1, 2},
        {2, 0}
    };
    
    private readonly Dictionary<int, int> _loseRockPaperScissors = new()
    {
        {0, 2},
        {1, 0},
        {2, 1}
    };

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
            
            if (_rockPaperScissors[opponent] == me)
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
            var result = split[1][0];
            
            roundScore += (result - 'X') * 3;
            
            var me = result == 'Z' ? _rockPaperScissors[opponent] :
                result == 'Y' ? opponent : _loseRockPaperScissors[opponent];

            roundScore += me + 1;

            score += roundScore;
        }
        
        return score;
    }
}