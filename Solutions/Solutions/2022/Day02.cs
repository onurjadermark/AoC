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
            if (split[0] == "A")
            {
                if (split[1] == "Z")
                {
                    roundScore += 3;
                }
                else if (split[1] == "X")
                {
                    roundScore += 3;
                    roundScore += 1;
                }
                else
                {
                    roundScore += 6;
                    
                    roundScore += 2;
                }
            }
            else if (split[0] == "B")
            {
                if (split[1] == "X")
                {
                    roundScore += 1;
                }
                else if (split[1] == "Y")
                {
                    roundScore += 3;
                    roundScore += 2;
                }
                else
                {
                    
                    roundScore += 6;
                    roundScore += 3;
                }
            }
            else if (split[0] == "C")
            {
                if (split[1] == "Y")
                {
                    roundScore += 2;
                }
                else if (split[1] == "Z")
                {
                    roundScore += 3;
                    roundScore += 3;
                }
                else
                {
                    roundScore += 6;
                    roundScore += 1;
                }
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
            if (split[0] == "A")
            {
                if (split[1] == "X")
                {
                    roundScore += 3;
                }
                else if (split[1] == "Y")
                {
                    roundScore += 1;
                    roundScore += 3;
                }
                else if (split[1] == "Z")
                {
                    roundScore += 2;
                    roundScore += 6;
                }
            }
            else if (split[0] == "B")
            {
                if (split[1] == "X")
                {
                    roundScore += 1;
                }
                else if (split[1] == "Y")
                {
                    roundScore += 2;
                    roundScore += 3;
                }
                else if (split[1] == "Z")
                {
                    roundScore += 3;
                    roundScore += 6;
                }
            }
            else if (split[0] == "C")
            {
                if (split[1] == "X")
                {
                    roundScore += 2;
                }
                else if (split[1] == "Y")
                {
                    roundScore += 3;
                    roundScore += 3;
                }
                else if (split[1] == "Z")
                {
                    roundScore += 1;
                    roundScore += 6;
                }
            }

            score += roundScore;
        }
        
        return score;
    }
}