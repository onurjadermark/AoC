namespace Solutions.Solutions._2018;

public class Day11
{
    public string Part1(string input)
    {
        var grid = new int[300, 300];
        var sn = int.Parse(input);

        for (var i = 0; i < 300; i++)
        for (var j = 0; j < 300; j++)
            grid[i, j] = CalculateFuelCellPower(i, j, sn);

        var maxPower = int.MinValue;
        var topLeftX = 0;
        var topLeftY = 0;
        for (var i = 0; i < 300 - 2; i++)
        for (var j = 0; j < 300 - 2; j++)
        {
            var power = grid[i, j] + grid[i + 1, j] + grid[i + 2, j]
                        + grid[i, j + 1] + grid[i + 1, j + 1] + grid[i + 2, j + 1]
                        + grid[i, j + 2] + grid[i + 1, j + 2] + grid[i + 2, j + 2];
            if (power > maxPower)
            {
                maxPower = power;
                topLeftX = i;
                topLeftY = j;
            }
        }

        return topLeftX + "," + topLeftY;
    }

    public string Part2(string input)
    {
        var grid = new int[300, 300];
        var sn = int.Parse(input);

        for (var i = 0; i < 300; i++)
        for (var j = 0; j < 300; j++)
            grid[i, j] = CalculateFuelCellPower(i, j, sn);

        var partialSums = CalculatePartialSums(grid);

        var maxPower = int.MinValue;
        var topLeftX = 0;
        var topLeftY = 0;
        var chosenSize = 0;
        for (var size = 1; size <= 300; size++)
        for (var i = 0; i < 300 - size; i++)
        for (var j = 0; j < 300 - size; j++)
        {
            var power = GetSum(partialSums, i, j, size);
            if (power > maxPower)
            {
                maxPower = power;
                topLeftX = i;
                topLeftY = j;
                chosenSize = size;
            }
        }

        return topLeftX + "," + topLeftY + "," + chosenSize;
    }

    private int GetSum(int[,] partialSums, int i, int j, int size)
    {
        if (i == 0 && j == 0) return partialSums[i, j];

        if (i == 0) return partialSums[i, j] - partialSums[i, j - 1];

        if (j == 0) return partialSums[i, j] - partialSums[i - 1, j];

        return partialSums[i + size - 1, j + size - 1]
               - partialSums[i + size - 1, j - 1]
               - partialSums[i - 1, j + size - 1]
               + partialSums[i - 1, j - 1];
    }

    private int[,] CalculatePartialSums(int[,] grid)
    {
        var result = new int[300, 300];
        result[0, 0] = grid[0, 0];
        for (var i = 1; i < 300; i++)
        {
            result[i, 0] = result[i - 1, 0] + grid[i, 0];
            result[0, i] = result[0, i - 1] + grid[0, i];
        }

        for (var i = 1; i < 300; i++)
        for (var j = 1; j < 300; j++)
            result[i, j] = -result[i - 1, j - 1]
                           + result[i, j - 1]
                           + result[i - 1, j]
                           + grid[i, j];

        return result;
    }

    public int CalculateFuelCellPower(int i, int j, int sn)
    {
        return ((i + 10) * j + sn) * (i + 10) / 100 % 10 - 5;
    }
}