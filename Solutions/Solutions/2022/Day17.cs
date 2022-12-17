namespace Solutions.Solutions._2022;

public class Day17
{
    private static readonly string[][] Rocks =
    {
        new[] {"@@@@"},
        new[] {".@.", "@@@", ".@."},
        new[] {"..@", "..@", "@@@"},
        new[] {"@", "@", "@", "@"},
        new[] {"@@", "@@"}
    };

    public long Part1(string[] input)
    {
        return Solve(input, 2022);
    }

    public long Part2(string[] input)
    {
        return Solve(input, 1000000000000);
    }

    private static long Solve(string[] input, long numRocks)
    {
        var jet = input[0];
        var chamber = new bool[7, 10000000];
        var jetIndex = 0;
        var chamberHighestRockY = -1;
        var prevChamberHighestRockY = -1;
        var prevDiff = 0;
        var rockIndexPrev = -1;
        var chamberHighestRockYs = new int[10000000];
        var loopsHeight = 0L;
        for (var i = 0; i < numRocks; i++)
        {
            var curRock = Rocks[i % Rocks.Length];
            var curX = 2;
            var curY = chamberHighestRockY + 4;
            while (true)
            {
                if (i > 0 && jetIndex % (jet.Length * Rocks.Length) == 0)
                {
                    if (chamberHighestRockY - prevChamberHighestRockY == prevDiff)
                    {
                        var rocksToFall = numRocks - i;
                        var loopSize = i - rockIndexPrev;
                        var numLoops = rocksToFall / loopSize;
                        var prevHeight = chamberHighestRockYs[i - 2 * loopSize];
                        var curHeight = chamberHighestRockYs[i - loopSize];
                        var heightDiff = curHeight - prevHeight;
                        loopsHeight = numLoops * heightDiff;
                        numRocks -= numLoops * loopSize;
                    }

                    prevDiff = chamberHighestRockY - prevChamberHighestRockY;
                    prevChamberHighestRockY = chamberHighestRockY;
                    rockIndexPrev = i;
                }

                var curJet = jet[jetIndex % jet.Length];
                jetIndex++;

                if (curJet == '<')
                {
                    curX = Math.Max(0, curX - 1);
                    if (IsBlocked(curRock, chamber, curX, curY)) curX++;
                }
                else
                {
                    curX = Math.Min(6 - curRock.Max(x => x.Length) + 1, curX + 1);
                    if (IsBlocked(curRock, chamber, curX, curY)) curX--;
                }

                curY--;
                if (IsBlocked(curRock, chamber, curX, curY))
                {
                    curY++;
                    var highestPlacedY = UpdateChamber(curRock, chamber, curX, curY);
                    if (highestPlacedY > chamberHighestRockY) chamberHighestRockY = highestPlacedY;
                    chamberHighestRockYs[i] = chamberHighestRockY;
                    break;
                }
            }
        }

        for (var i = 0; i < 1000000; i++)
        {
            var emptyRow = true;
            for (var j = 0; j < 7; j++)
            {
                if (chamber[j, i]) emptyRow = false;
            }

            if (emptyRow)
            {
                return i + loopsHeight;
            }
        }

        return 0;
    }

    private static int UpdateChamber(string[] curRock, bool[,] chamber, int curX, int curY)
    {
        var highestPlacedY = 0;
        for (var j = 0; j < curRock.Length; j++)
        {
            var curRockSlice = curRock[curRock.Length - 1 - j];
            for (var k = 0; k < curRockSlice.Length; k++)
            {
                var curRockPiece = curRockSlice[k];
                if (curRockPiece == '.')
                {
                    continue;
                }

                chamber[curX + k, curY + j] = true;
                if (highestPlacedY < curY + j) highestPlacedY = curY + j;
            }
        }

        return highestPlacedY;
    }

    private static bool IsBlocked(string[] curRock, bool[,] chamber, int curX, int curY)
    {
        if (curY < 0) return true;

        var blocked = false;
        for (var j = 0; j < curRock.Length; j++)
        {
            var curRockSlice = curRock[curRock.Length - 1 - j];
            for (var k = 0; k < curRockSlice.Length; k++)
            {
                var curRockPiece = curRockSlice[k];
                if (curRockPiece == '.')
                {
                    continue;
                }

                if (chamber[curX + k, curY + j])
                {
                    blocked = true;
                }
            }
        }

        return blocked;
    }
}