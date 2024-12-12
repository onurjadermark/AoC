namespace Solutions.Utils;

public class Node<T>(int x, int y, int id, Grid<T> grid)
{
    private Node<T>? _down;
    private Node<T>? _downLeft;
    private Node<T>? _downRight;
    private Node<T>? _left;

    private List<Node<T>>? _orthogonalNeighbors;
    private Node<T>? _right;
    private Node<T>? _up;
    private Node<T>? _upLeft;
    private Node<T>? _upRight;
    public int Id { get; init; } = id;
    public int X { get; init; } = x;
    public int Y { get; init; } = y;
    public T Value { get; set; } = default!;
    public IEnumerable<Node<T>> Neighbors { get; set; } = null!;
    public Node<T>? Up => _up ??= Neighbors.SingleOrDefault(x => x.X == X && x.Y == Y - 1);
    public Node<T>? UpRight => _upRight ??= Neighbors.SingleOrDefault(x => x.X == X + 1 && x.Y == Y - 1);
    public Node<T>? Right => _right ??= Neighbors.SingleOrDefault(x => x.X == X + 1 && x.Y == Y);
    public Node<T>? DownRight => _downRight ??= Neighbors.SingleOrDefault(x => x.X == X + 1 && x.Y == Y + 1);
    public Node<T>? Down => _down ??= Neighbors.SingleOrDefault(x => x.X == X && x.Y == Y + 1);
    public Node<T>? DownLeft => _downLeft ??= Neighbors.SingleOrDefault(x => x.X == X - 1 && x.Y == Y + 1);
    public Node<T>? Left => _left ??= Neighbors.SingleOrDefault(x => x.X == X - 1 && x.Y == Y);
    public Node<T>? UpLeft => _upLeft ??= Neighbors.SingleOrDefault(x => x.X == X - 1 && x.Y == Y - 1);

    public override string ToString()
    {
        return Value?.ToString() ?? " ";
    }

    public int ManhattanDistance(Node<T> other)
    {
        return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    }

    public Node<T>? Move((int X, int Y) direction)
    {
        return direction switch
        {
            (0, 1) => Down,
            (1, 0) => Right,
            (0, -1) => Up,
            (-1, 0) => Left,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public long ManDistance(Node<int> goal)
    {
        return Math.Abs(goal.X - X) + Math.Abs(goal.Y - Y);
    }

    public Node<T>? GetNeighbor((int x, int y) direction)
    {
        return grid.GetNeighbor(this, direction);
    }

    public IEnumerable<Node<T>> GetOrthogonalNeighbors() => _orthogonalNeighbors ??= Neighbors.Where(x => x.X == X || x.Y == Y).ToList();
}