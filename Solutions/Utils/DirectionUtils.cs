namespace Solutions.Utils;

public abstract class DirectionUtils
{
    public static (int X, int Y) TurnLeft((int X, int Y) direction)
    {
        return (-direction.Y, direction.X);
    }
    
    public static (int X, int Y) TurnRight((int X, int Y) direction)
    {
        return (direction.Y, -direction.X);
    }
    
    public static (int X, int Y) TurnAround((int X, int Y) direction)
    {
        return (-direction.X, -direction.Y);
    }

    public static List<(int X, int Y)> GetOrthogonalDirections()
    {
        return [(0, 1), (1, 0), (0, -1), (-1, 0)];
    }

    public static List<(int X, int Y)> GetDiagonalDirections()
    {
        return [(1, 1), (1, -1), (-1, 1), (-1, -1)];
    }

    public static List<(int X, int Y)> GetAllDirections()
    {
        return GetOrthogonalDirections().Concat(GetDiagonalDirections()).ToList();
    }
}