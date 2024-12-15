namespace Solutions.Utils;

public abstract class DirectionUtils
{
    public static (int X, int Y) TurnLeft((int X, int Y) direction)
    {
        return (direction.Y, -direction.X);
    }
    
    public static (int X, int Y) TurnRight((int X, int Y) direction)
    {
        return (-direction.Y, direction.X);
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

    public static (int X, int Y) FromChar(char position)
    {
        return position switch
        {
            '^' => (0, -1),
            '>' => (1, 0),
            'v' => (0, 1),
            '<' => (-1, 0),
            _ => throw new ArgumentException()
        };
    }
    
    public static readonly char[] DirectionChars = ['^', '>', 'v', '<'];
}

public static class TupleExtensions
{
    public static (int X, int Y) Add(this (int X, int Y) tuple1, (int X, int Y) tuple2)
    {
        return (tuple1.X + tuple2.X, tuple1.Y + tuple2.Y);
    }
}