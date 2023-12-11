﻿namespace Solutions.Utils;

public class Node<T>
{
    public int Id { get; init; }
    public int X { get; init; }
    public int Y { get; init; }
    public T Value { get; set; } = default!;
    public IEnumerable<Node<T>> Neighbors { get; set; } = null!;

    public Node<T>? Up => Neighbors.SingleOrDefault(x => x.X == X && x.Y == Y - 1);
    public Node<T>? UpRight => Neighbors.SingleOrDefault(x => x.X == X + 1 && x.Y == Y - 1);
    public Node<T>? Right => Neighbors.SingleOrDefault(x => x.X == X + 1 && x.Y == Y);
    public Node<T>? DownRight => Neighbors.SingleOrDefault(x => x.X == X + 1 && x.Y == Y + 1);
    public Node<T>? Down => Neighbors.SingleOrDefault(x => x.X == X && x.Y == Y + 1);
    public Node<T>? DownLeft => Neighbors.SingleOrDefault(x => x.X == X - 1 && x.Y == Y + 1);
    public Node<T>? Left => Neighbors.SingleOrDefault(x => x.X == X - 1 && x.Y == Y);
    public Node<T>? UpLeft => Neighbors.SingleOrDefault(x => x.X == X - 1 && x.Y == Y - 1);

    public override string ToString()
    {
        return Value?.ToString() ?? " ";
    }
    
    public int ManhattanDistance(Node<T> other)
    {
        return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    }
}