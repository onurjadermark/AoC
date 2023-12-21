namespace Solutions.Utils;

public class Coordinate
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public Coordinate Move((int X, int Y) dir)
    {
        return new Coordinate(X + dir.X, Y + dir.Y);
    }
}