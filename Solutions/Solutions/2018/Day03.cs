using System.Drawing;

namespace Solutions.Solutions._2018;

public class Day03
{
    public int Part1(string[] input)
    {
        var rectangles = input.Select(GetRectangle).Select(x => x.Rectangle).ToList();
        var matrix = new int[1000, 1000];

        var count = 0;
        foreach (var rectangle in rectangles)
            for (var i = rectangle.Left; i < rectangle.Right; i++)
            for (var j = rectangle.Top; j < rectangle.Bottom; j++)
            {
                if (matrix[i, j] == 1) count++;
                matrix[i, j]++;
            }

        return count;
    }

    public int Part2(string[] input)
    {
        var rectangles = input.Select(GetRectangle).ToList();

        foreach (var (id, rectangle) in rectangles)
            if (rectangles.All(x => x.Id == id || !rectangle.IntersectsWith(x.Rectangle)))
                return id;

        return -1;
    }

    private (int Id, System.Drawing.Rectangle Rectangle) GetRectangle(string line)
    {
        var split = line.Split('#', ' ', '@', ',', ':', 'x').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse)
            .ToArray();
        var rectangle = new Rectangle(split[1], split[2], split[3], split[4]);
        return (split[0], rectangle);
    }
}