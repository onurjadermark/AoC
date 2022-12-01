namespace Solutions.Solutions._2021;

public class Day17
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
        var split = input.Single().Split('=', '.', ',', ' ').Where(x => x.Length > 1 && char.IsNumber(x[1]))
            .Select(int.Parse).ToList();
        var targetXMin = split[0];
        var targetXMax = split[1];
        var targetYMin = split[2];
        var targetYMax = split[3];
        var maxYPosition = int.MinValue;
        var possibilities = 0;

        for (var i = 0; i <= targetXMax; i++)
        for (var j = -120; j < 250; j++)
        {
            var curPosX = 0;
            var curPosY = 0;
            var curSpeedX = i;
            var curSpeedY = j;
            var curMaxYPos = int.MinValue;
            var reachedTarget = false;
            for (var t = 0; t < 1000; t++)
            {
                if (curPosY > curMaxYPos) curMaxYPos = curPosY;

                curPosX += curSpeedX;
                curPosY += curSpeedY;
                curSpeedX = Math.Max(0, curSpeedX - 1);
                curSpeedY--;

                if (curPosX >= targetXMin && curPosX <= targetXMax && curPosY >= targetYMin && curPosY <= targetYMax)
                    reachedTarget = true;

                if (curPosX > targetXMax || curPosY < targetYMin) break;
            }

            if (reachedTarget && curMaxYPos > maxYPosition) maxYPosition = curMaxYPos;

            if (reachedTarget) possibilities++;
        }

        return part == 1 ? maxYPosition : possibilities;
    }
}