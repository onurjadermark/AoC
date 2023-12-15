namespace Solutions.Solutions._2023;

public class Day15
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private static int Solve(string[] input, int part)
    {
        var operations = input[0].Split(',').ToList();
        if (part == 1)
        {
            return operations.Sum(GetHash);
        }

        var boxes = Enumerable.Repeat(0, 256).Select(_ => new List<(string Lens, int FocalLength)>()).ToArray();
        foreach (var operation in operations)
        {
            ProcessOperation(boxes, operation);
        }

        return boxes.Select((x, i) => x.Select((y, j) => (i + 1) * (j + 1) * y.FocalLength).Sum()).Sum();
    }

    private static void ProcessOperation(List<(string Label, int FocalLength)>[] boxes, string operation)
    {
        var label = operation.Split('-', '=')[0];
        var boxIndex = GetHash(label);
        var lensIndex = boxes[boxIndex].FindIndex(x => x.Label == label);

        if (operation.Contains('='))
        {
            var focalLength = int.Parse(operation.Split('-', '=')[1]);
            if (lensIndex == -1)
            {
                boxes[boxIndex].Add((label, focalLength));
            }
            else
            {
                boxes[boxIndex][lensIndex] = (label, focalLength);
            }
        }
        else
        {
            if (lensIndex != -1)
            {
                boxes[boxIndex].RemoveAt(lensIndex);
            }
        }
    }

    private static int GetHash(string str)
    {
        return str.Aggregate(0, (x, y) => (x + y) * 17 % 256);
    }
}