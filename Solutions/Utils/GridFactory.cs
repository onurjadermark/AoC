﻿namespace Solutions.Utils;

public abstract class GridFactory
{
    public static Grid<char> FromInputStrings(string[] input)
    {
        var grid = new Grid<char>(input[0].Length, input.Length, false);
        grid.Nodes.ForEach(x => x.Value = input[x.Y][x.X]);
        return grid;
    }
}