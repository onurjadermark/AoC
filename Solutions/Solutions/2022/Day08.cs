namespace Solutions.Solutions._2022;

public class Day08
{
    private int _visibleCount;
    private int _highestScore;
    private readonly (int x, int y)[] _validMoves = {(1, 0), (0, 1), (-1, 0), (0, -1)};

    public int Part1(string[] input)
    {
        Solve(input);
        return _visibleCount;
    }

    public int Part2(string[] input)
    {
        Solve(input);
        return _highestScore;
    }

    private void Solve(string[] input)
    {
        var size = input.Length;
        var grid = new int[size, size];
        for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            grid[j, i] = input[i][j] - '0';

        for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
        {
            var score = 1;
            var valid = false;
            for (var k = 0; k < 4; k++)
            {
                var curX = i;
                var curY = j;
                while (true)
                {
                    curX += _validMoves[k].x;
                    curY += _validMoves[k].y;
                    
                    if (curX == -1 || curY == -1 || curX == size || curY == size)
                    {
                        valid = true;
                        curX = Math.Clamp(curX, 0, size - 1);
                        curY = Math.Clamp(curY, 0, size - 1);
                        break;
                    }

                    if (grid[j, i] <= grid[curY, curX])
                    {
                        break;
                    }
                }

                var dist = i == curX ? Math.Abs(j - curY) : Math.Abs(i - curX);
                score *= dist;
            }

            if (valid) _visibleCount++;
            if (score > _highestScore) _highestScore = score;
        }
    }
}