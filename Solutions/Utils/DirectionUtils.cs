namespace Solutions.Utils;

public class DirectionUtils
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
}