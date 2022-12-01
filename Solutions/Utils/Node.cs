namespace Solutions.Utils;

public class Node<T>
{
    public int X { get; init; }
    public int Y { get; init; }
    public T Value { get; set; } = default!;
    public IEnumerable<Node<T>> Neighbors { get; set; } = null!;
}