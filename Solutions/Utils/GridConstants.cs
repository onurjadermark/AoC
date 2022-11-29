namespace Solutions.Utils;

public static class GridConstants
{
    public static readonly List<(int X, int Y)> Neighbours = new()
    {
        (1, 0),
        (1, 1),
        (0, 1),
        (-1, 1),
        (-1, 0),
        (-1, -1),
        (0, -1),
        (1, -1)
    };
}