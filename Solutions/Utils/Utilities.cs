namespace Solutions.Utils;

public static class Utilities
{
    public static Direction GetDirection(int x, int y)
    {
        return x switch
        {
            0 when y == -1 => Direction.N,
            1 when y == 0 => Direction.E,
            0 when y == 1 => Direction.S,
            -1 when y == 0 => Direction.W,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    public static Direction Flip(this Direction direction)
    {
        return (Direction) (((int) direction + 2) % 4);
    }
}