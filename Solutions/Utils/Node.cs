namespace Solutions.Utils;

public class Node<T>
{
    private Node<T>? _down;
    private Node<T>? _downLeft;
    private Node<T>? _downRight;
    private Node<T>? _left;
    private Node<T>? _right;
    private Node<T>? _up;
    private Node<T>? _upLeft;
    private Node<T>? _upRight;
    public int Id { get; init; }
    public int X { get; init; }
    public int Y { get; init; }
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
}