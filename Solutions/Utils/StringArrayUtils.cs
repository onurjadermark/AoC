﻿namespace Solutions.Utils;

public class StringArrayUtils
{
    public static string[] RotateStringArray(string[] arr)
    {
        var numRows = arr.Length;
        var numCols = arr[0].Length;

        var rotated = new string[numCols];

        for (var i = 0; i < numCols; i++)
        {
            var newRow = "";
            for (var j = numRows - 1; j >= 0; j--)
            {
                newRow += arr[j][i];
            }

            rotated[i] = newRow;
        }

        return rotated;
    }
}