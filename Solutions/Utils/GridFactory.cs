namespace Solutions.Utils;

public abstract class GridFactory
{
    public static Grid<char> FromInputStrings(string[] input)
    {
        var grid = new Grid<char>(input[0].Length, input.Length, false);
        grid.Nodes.ForEach(x => x.Value = input[x.Y][x.X]);
        return grid;
    }
    
    public static Grid<int> FromInputStringsToInt(string[] input)
    {
        var grid = new Grid<int>(input[0].Length, input.Length, false);
        grid.Nodes.ForEach(x => x.Value = input[x.Y][x.X] - '0');
        return grid;
    }
}