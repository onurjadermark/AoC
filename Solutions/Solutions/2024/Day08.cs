using Solutions.Utils;

namespace Solutions.Solutions._2024;

public class Day08
{
    public int Part1(string[] input)
    {
        return Solve(input, 1);
    }

    public int Part2(string[] input)
    {
        return Solve(input, 2);
    }

    private int Solve(string[] input, int part)
    {
        var grid = GridFactory.FromInputStrings(input);
        var antennas = grid.Nodes.Where(x => x.Value != '.').GroupBy(x => x.Value).ToList();
        var uniqueLocations = new HashSet<Node<char>>();
        
        foreach (var grouping in antennas)
        {
            foreach (var antenna1 in grouping)
            {
                foreach (var antenna2 in grouping)
                {
                    if (antenna1.Id >= antenna2.Id) continue;

                    var xDiff = antenna2.X - antenna1.X;
                    var yDiff = antenna2.Y - antenna1.Y;

                    if (part == 2)
                    {
                        var gcd = Utilities.GCD(xDiff, yDiff);
                        xDiff /= gcd;
                        yDiff /= gcd;
                    }

                    for (var i = 1; i < Math.Max(grid.Width, grid.Height); i++)
                    {
                        var nodes = new[]
                        {
                            grid.GetNode(antenna1.X + xDiff * i, antenna1.Y + yDiff * i),
                            grid.GetNode(antenna1.X - xDiff * i, antenna1.Y - yDiff * i),
                            grid.GetNode(antenna2.X + xDiff * i, antenna2.Y + yDiff * i),
                            grid.GetNode(antenna2.X - xDiff * i, antenna2.Y - yDiff * i)
                        };
                        
                        if (nodes.All(x => x == null)) break;

                        if (part == 1)
                        {
                            nodes.Where(x => x != null && x != antenna1 && x != antenna2).ToList()
                                .ForEach(x => uniqueLocations.Add(x!));
                            break;
                        }
                        
                        nodes.Where(x => x != null).ForEach(x => uniqueLocations.Add(x!));
                    }
                }
            }
        }

        return uniqueLocations.Count;
    }
}