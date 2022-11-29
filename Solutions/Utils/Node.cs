namespace Solutions.Utils;

public class Node<T>
{
    public int X { get; set; }
    public int Y { get; set; }
    public T Value { get; set; } = default!;
    public IEnumerable<Node<T>> Neighbors { get; set; } = null!;
}