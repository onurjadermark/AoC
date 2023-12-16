using System.Text;

namespace Solutions.Utils;

public class Grid<T>
{
    public Grid(int width, int height, bool allowDiagonal)
    {
        Width = width;
        Height = height;

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                Dict[(i, j)] = new Node<T>(i, j, i * width + j, this);
            }
        }

        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                var neighbors = new List<Node<T>>();
                if (i < width - 1) neighbors.Add(Dict[(i + 1, j)]);
                if (j < height - 1) neighbors.Add(Dict[(i, j + 1)]);
                if (i != 0) neighbors.Add(Dict[(i - 1, j)]);
                if (j != 0) neighbors.Add(Dict[(i, j - 1)]);
                if (allowDiagonal && i != 0 && j != 0) neighbors.Add(Dict[(i - 1, j - 1)]);
                if (allowDiagonal && i != 0 && j < height - 1) neighbors.Add(Dict[(i - 1, j + 1)]);
                if (allowDiagonal && i < width - 1 && j != 0) neighbors.Add(Dict[(i + 1, j - 1)]);
                if (allowDiagonal && i < width - 1 && j < height - 1) neighbors.Add(Dict[(i + 1, j + 1)]);
                Dict[(i, j)].Neighbors = neighbors;
            }
        }
    }

    public int Width { get; }
    public int Height { get; }
    public IEnumerable<Node<T>> Nodes => Dict.Values.AsEnumerable();
    private Dictionary<(int X, int Y), Node<T>> Dict { get; } = new();
    public Node<T> this[int x, int y] => Dict[(x, y)];

    public override string ToString()
    {
        var str = new StringBuilder();
        for (var j = 0; j < Height; j++)
        {
            for (var i = 0; i < Width; i++)
            {
                str.Append(Dict[(i, j)].Value);
            }

            str.Append(Environment.NewLine);
        }

        return str.ToString();
    }

    public bool IsOnBoundary(Node<char> node)
    {
        return node.X == 0 || node.Y == 0 || node.X == Width - 1 || node.Y == Height - 1;
    }
}